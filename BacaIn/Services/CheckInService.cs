using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BacaIn.Data;
using BacaIn.Models;
using Npgsql;

namespace BacaIn.Services
{
    public class CheckInService
    {
        private static CheckInService? _instance;
        public static CheckInService Instance => _instance ??= new CheckInService();

        public async Task<CheckIn> CheckInAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Please enter a student username or scan card.", nameof(username));
            }

            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            // 1. Verify student exists
            const string findUserSql = @"
                SELECT id, username, display_name
                FROM users
                WHERE LOWER(username) = LOWER(@username)
                  AND role = 'student'
                  AND deleted_at IS NULL
                LIMIT 1;
            ";

            Guid studentId;
            string studentName;
            string studentUsername;

            await using (var cmd = new NpgsqlCommand(findUserSql, conn))
            {
                cmd.Parameters.AddWithValue("username", username.Trim());
                await using var reader = await cmd.ExecuteReaderAsync();
                if (!await reader.ReadAsync())
                {
                    throw new InvalidOperationException("Student not found. Please verify your username.");
                }

                studentId = reader.GetGuid(0);
                studentUsername = reader.GetString(1);
                studentName = reader.IsDBNull(2) ? studentUsername : reader.GetString(2);
            }

            // 2. Check if already checked in today
            const string checkDuplicateSql = @"
                SELECT 1
                FROM check_ins
                WHERE student_id = @studentId
                  AND checked_in_at::date = CURRENT_DATE
                LIMIT 1;
            ";

            await using (var cmd = new NpgsqlCommand(checkDuplicateSql, conn))
            {
                cmd.Parameters.AddWithValue("studentId", studentId);
                var exists = await cmd.ExecuteScalarAsync();
                if (exists != null)
                {
                    throw new InvalidOperationException($"Student '{studentName}' has already checked in today.");
                }
            }

            // 3. Insert check_in record
            var checkIn = new CheckIn
            {
                Id = Guid.NewGuid(),
                StudentId = studentId,
                StudentName = studentName,
                StudentUsername = studentUsername,
                CheckedInAt = DateTime.UtcNow
            };

            const string insertSql = @"
                INSERT INTO check_ins (id, student_id, checked_in_at)
                VALUES (@id, @studentId, @checkedInAt);
            ";

            await using (var cmd = new NpgsqlCommand(insertSql, conn))
            {
                cmd.Parameters.AddWithValue("id", checkIn.Id);
                cmd.Parameters.AddWithValue("studentId", checkIn.StudentId);
                cmd.Parameters.AddWithValue("checkedInAt", checkIn.CheckedInAt);
                await cmd.ExecuteNonQueryAsync();
            }

            return checkIn;
        }

        public async Task<List<CheckIn>> GetHistoryAsync(Guid studentId, DateTime fromDate, DateTime toDate)
        {
            var list = new List<CheckIn>();
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            var startUtc = DateTime.SpecifyKind(fromDate.Date, DateTimeKind.Utc);
            var endUtc = DateTime.SpecifyKind(toDate.Date.AddDays(1).AddTicks(-1), DateTimeKind.Utc);

            const string sql = @"
                SELECT c.id, c.student_id, u.display_name, u.username, c.checked_in_at
                FROM check_ins c
                JOIN users u ON c.student_id = u.id
                WHERE c.student_id = @studentId
                  AND c.checked_in_at >= @startUtc
                  AND c.checked_in_at <= @endUtc
                ORDER BY c.checked_in_at DESC;
            ";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("studentId", studentId);
            cmd.Parameters.AddWithValue("startUtc", startUtc);
            cmd.Parameters.AddWithValue("endUtc", endUtc);

            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new CheckIn
                {
                    Id = reader.GetGuid(0),
                    StudentId = reader.GetGuid(1),
                    StudentName = reader.IsDBNull(2) ? reader.GetString(3) : reader.GetString(2),
                    StudentUsername = reader.GetString(3),
                    CheckedInAt = reader.GetDateTime(4)
                });
            }

            return list;
        }
    }
}
