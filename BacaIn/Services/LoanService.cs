using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BacaIn.Data;
using BacaIn.Models;
using Npgsql;

namespace BacaIn.Services
{
    public class LoanService
    {
        private static LoanService? _instance;
        public static LoanService Instance => _instance ??= new LoanService();

        public async Task<List<User>> GetActiveStudentsAsync(string? keyword = null)
        {
            var list = new List<User>();
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            var sql = @"
                SELECT id, username, display_name
                FROM users
                WHERE role = 'student' AND deleted_at IS NULL
            ";

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sql += " AND (LOWER(username) LIKE @kw OR LOWER(display_name) LIKE @kw)";
            }

            sql += " ORDER BY username ASC;";

            await using var cmd = new NpgsqlCommand(sql, conn);
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                cmd.Parameters.AddWithValue("kw", "%" + keyword.Trim().ToLowerInvariant() + "%");
            }

            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new User
                {
                    Id = reader.GetGuid(0),
                    Username = reader.GetString(1),
                    DisplayName = reader.IsDBNull(2) ? reader.GetString(1) : reader.GetString(2),
                    Role = "student"
                });
            }

            return list;
        }

        public async Task<List<Loan>> GetLoansForStudentAsync(Guid studentId, string? filter = null)
        {
            var list = new List<Loan>();
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            var sql = @"
                SELECT l.id, l.student_id, u.display_name, u.username,
                       l.exemplar_id, e.barcode, b.title, b.author,
                       l.borrowed_at, l.due_at, l.returned_at, l.status
                FROM loans l
                JOIN users u ON l.student_id = u.id
                JOIN exemplars e ON l.exemplar_id = e.id
                JOIN bibliographies b ON e.bibliography_id = b.id
                WHERE l.student_id = @studentId
            ";

            if (string.Equals(filter, "Active", StringComparison.OrdinalIgnoreCase))
            {
                sql += " AND l.status = 'ACTIVATE' AND l.due_at >= NOW()";
            }
            else if (string.Equals(filter, "Overdue", StringComparison.OrdinalIgnoreCase))
            {
                sql += " AND l.status = 'ACTIVATE' AND l.due_at < NOW()";
            }
            else if (string.Equals(filter, "Returned", StringComparison.OrdinalIgnoreCase))
            {
                sql += " AND l.status = 'RETURNED'";
            }

            sql += " ORDER BY l.borrowed_at DESC;";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("studentId", studentId);

            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new Loan
                {
                    Id = reader.GetGuid(0),
                    StudentId = reader.GetGuid(1),
                    StudentName = reader.IsDBNull(2) ? reader.GetString(3) : reader.GetString(2),
                    StudentUsername = reader.GetString(3),
                    ExemplarId = reader.GetGuid(4),
                    Barcode = reader.GetString(5),
                    BookTitle = reader.GetString(6),
                    Author = reader.GetString(7),
                    BorrowedAt = reader.GetDateTime(8),
                    DueAt = reader.GetDateTime(9),
                    ReturnedAt = reader.IsDBNull(10) ? null : reader.GetDateTime(10),
                    Status = reader.GetString(11)
                });
            }

            return list;
        }

        public async Task<bool> HasOverdueLoansAsync(Guid studentId)
        {
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            const string sql = @"
                SELECT 1
                FROM loans
                WHERE student_id = @studentId
                  AND status = 'ACTIVATE'
                  AND due_at < NOW()
                LIMIT 1;
            ";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("studentId", studentId);

            var result = await cmd.ExecuteScalarAsync();
            return result != null;
        }

        public async Task<List<Exemplar>> GetAvailableExemplarsAsync(string? keyword = null)
        {
            var list = new List<Exemplar>();
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            var sql = @"
                SELECT e.id, e.bibliography_id, e.barcode, e.status, e.condition, b.title, b.author
                FROM exemplars e
                JOIN bibliographies b ON e.bibliography_id = b.id
                WHERE e.status = 'AVAILABLE'
                  AND e.deleted_at IS NULL
                  AND b.deleted_at IS NULL
            ";

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sql += " AND (LOWER(b.title) LIKE @kw OR LOWER(b.author) LIKE @kw OR LOWER(e.barcode) LIKE @kw)";
            }

            sql += " ORDER BY b.title ASC, e.barcode ASC;";

            await using var cmd = new NpgsqlCommand(sql, conn);
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                cmd.Parameters.AddWithValue("kw", "%" + keyword.Trim().ToLowerInvariant() + "%");
            }

            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new Exemplar
                {
                    Id = reader.GetGuid(0),
                    BibliographyId = reader.GetGuid(1),
                    Barcode = reader.GetString(2),
                    Status = reader.GetString(3),
                    Condition = reader.GetString(4),
                    BookTitle = reader.GetString(5),
                    BookAuthor = reader.GetString(6)
                });
            }

            return list;
        }

        public async Task<Loan> CreateLoanAsync(Guid studentId, Guid exemplarId, int durationDays = 14)
        {
            if (await HasOverdueLoansAsync(studentId))
            {
                throw new InvalidOperationException("Student has overdue loans. Cannot borrow until existing overdue loans are returned.");
            }

            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();
            await using var tx = await conn.BeginTransactionAsync();

            try
            {
                // 1. Verify copy is AVAILABLE
                const string checkExemplarSql = @"
                    SELECT status FROM exemplars WHERE id = @exemplarId AND deleted_at IS NULL FOR UPDATE;
                ";
                await using (var checkCmd = new NpgsqlCommand(checkExemplarSql, conn, tx))
                {
                    checkCmd.Parameters.AddWithValue("exemplarId", exemplarId);
                    var status = (string?)await checkCmd.ExecuteScalarAsync();
                    if (status != "AVAILABLE")
                    {
                        throw new InvalidOperationException("Selected book copy is no longer available.");
                    }
                }

                // 2. Insert Loan
                var loan = new Loan
                {
                    Id = Guid.NewGuid(),
                    StudentId = studentId,
                    ExemplarId = exemplarId,
                    BorrowedAt = DateTime.UtcNow,
                    DueAt = DateTime.UtcNow.AddDays(durationDays),
                    Status = "ACTIVATE"
                };

                const string insertLoanSql = @"
                    INSERT INTO loans (id, student_id, exemplar_id, borrowed_at, due_at, status)
                    VALUES (@id, @studentId, @exemplarId, @borrowedAt, @dueAt, 'ACTIVATE');
                ";
                await using (var insertCmd = new NpgsqlCommand(insertLoanSql, conn, tx))
                {
                    insertCmd.Parameters.AddWithValue("id", loan.Id);
                    insertCmd.Parameters.AddWithValue("studentId", loan.StudentId);
                    insertCmd.Parameters.AddWithValue("exemplarId", loan.ExemplarId);
                    insertCmd.Parameters.AddWithValue("borrowedAt", loan.BorrowedAt);
                    insertCmd.Parameters.AddWithValue("dueAt", loan.DueAt);
                    await insertCmd.ExecuteNonQueryAsync();
                }

                // 3. Mark exemplar as BORROWED
                const string updateExSql = @"
                    UPDATE exemplars SET status = 'BORROWED', updated_at = NOW() WHERE id = @exemplarId;
                ";
                await using (var updateCmd = new NpgsqlCommand(updateExSql, conn, tx))
                {
                    updateCmd.Parameters.AddWithValue("exemplarId", exemplarId);
                    await updateCmd.ExecuteNonQueryAsync();
                }

                await tx.CommitAsync();
                return loan;
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }

        public async Task<(bool isLate, int overdueDays, decimal fineAmount)> ReturnLoanAsync(Guid loanId)
        {
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();
            await using var tx = await conn.BeginTransactionAsync();

            try
            {
                // 1. Fetch loan details
                const string getLoanSql = @"
                    SELECT l.exemplar_id, l.due_at, l.status, e.bibliography_id
                    FROM loans l
                    JOIN exemplars e ON l.exemplar_id = e.id
                    WHERE l.id = @loanId FOR UPDATE;
                ";

                Guid exemplarId;
                DateTime dueAt;
                string currentStatus;
                Guid bibId;

                await using (var cmd = new NpgsqlCommand(getLoanSql, conn, tx))
                {
                    cmd.Parameters.AddWithValue("loanId", loanId);
                    await using var reader = await cmd.ExecuteReaderAsync();
                    if (!await reader.ReadAsync())
                    {
                        throw new InvalidOperationException("Loan not found.");
                    }

                    exemplarId = reader.GetGuid(0);
                    dueAt = reader.GetDateTime(1);
                    currentStatus = reader.GetString(2);
                    bibId = reader.GetGuid(3);
                }

                if (currentStatus == "RETURNED")
                {
                    throw new InvalidOperationException("This loan is already returned.");
                }

                var now = DateTime.UtcNow;
                var isLate = now > dueAt;
                var overdueDays = isLate ? Math.Max(1, (int)Math.Ceiling((now - dueAt).TotalDays)) : 0;
                var fineAmount = overdueDays * 1000m;

                // 2. Mark loan returned
                const string returnLoanSql = @"
                    UPDATE loans
                    SET status = 'RETURNED',
                        returned_at = NOW(),
                        updated_at = NOW()
                    WHERE id = @loanId;
                ";
                await using (var retCmd = new NpgsqlCommand(returnLoanSql, conn, tx))
                {
                    retCmd.Parameters.AddWithValue("loanId", loanId);
                    await retCmd.ExecuteNonQueryAsync();
                }

                // 3. Mark exemplar available
                const string availExSql = @"
                    UPDATE exemplars
                    SET status = 'AVAILABLE',
                        updated_at = NOW()
                    WHERE id = @exemplarId;
                ";
                await using (var exCmd = new NpgsqlCommand(availExSql, conn, tx))
                {
                    exCmd.Parameters.AddWithValue("exemplarId", exemplarId);
                    await exCmd.ExecuteNonQueryAsync();
                }

                // 4. Promote reservation if one is waiting
                const string promoteResSql = @"
                    UPDATE reservations
                    SET status = 'READY',
                        updated_at = NOW()
                    WHERE id = (
                        SELECT id FROM reservations
                        WHERE bibliography_id = @bibId AND status = 'PENDING'
                        ORDER BY queue_position ASC, reserved_at ASC
                        LIMIT 1
                    );
                ";
                await using (var resCmd = new NpgsqlCommand(promoteResSql, conn, tx))
                {
                    resCmd.Parameters.AddWithValue("bibId", bibId);
                    await resCmd.ExecuteNonQueryAsync();
                }

                await tx.CommitAsync();
                return (isLate, overdueDays, fineAmount);
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }
    }
}
