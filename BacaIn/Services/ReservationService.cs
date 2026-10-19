using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BacaIn.Data;
using BacaIn.Models;
using Npgsql;

namespace BacaIn.Services
{
    public class ReservationService
    {
        private static ReservationService? _instance;
        public static ReservationService Instance => _instance ??= new ReservationService();

        public async Task<List<Reservation>> GetStudentReservationsAsync(Guid studentId, string? filter = null)
        {
            var list = new List<Reservation>();
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            var sql = @"
                SELECT r.id, r.student_id, u.display_name, r.bibliography_id, b.title,
                       r.reserved_at, r.status, r.queue_position, r.created_at, r.updated_at
                FROM reservations r
                JOIN users u ON r.student_id = u.id
                JOIN bibliographies b ON r.bibliography_id = b.id
                WHERE r.student_id = @studentId
            ";

            if (!string.IsNullOrWhiteSpace(filter) && !string.Equals(filter, "All", StringComparison.OrdinalIgnoreCase))
            {
                sql += " AND UPPER(r.status) = @status";
            }

            sql += " ORDER BY r.reserved_at DESC;";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("studentId", studentId);
            if (!string.IsNullOrWhiteSpace(filter) && !string.Equals(filter, "All", StringComparison.OrdinalIgnoreCase))
            {
                cmd.Parameters.AddWithValue("status", filter.Trim().ToUpperInvariant());
            }

            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new Reservation
                {
                    Id = reader.GetGuid(0),
                    StudentId = reader.GetGuid(1),
                    StudentName = reader.IsDBNull(2) ? null : reader.GetString(2),
                    BibliographyId = reader.GetGuid(3),
                    BookTitle = reader.GetString(4),
                    ReservedAt = reader.GetDateTime(5),
                    Status = reader.GetString(6),
                    QueuePosition = reader.GetInt32(7),
                    CreatedAt = reader.GetDateTime(8),
                    UpdatedAt = reader.IsDBNull(9) ? null : reader.GetDateTime(9)
                });
            }

            return list;
        }

        public async Task<Reservation> MakeReservationAsync(Guid studentId, Guid bibliographyId)
        {
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            // 1. Check if user already has an active reservation for this book
            const string checkSql = @"
                SELECT 1
                FROM reservations
                WHERE student_id = @studentId
                  AND bibliography_id = @bibId
                  AND status IN ('PENDING', 'READY')
                LIMIT 1;
            ";

            await using (var checkCmd = new NpgsqlCommand(checkSql, conn))
            {
                checkCmd.Parameters.AddWithValue("studentId", studentId);
                checkCmd.Parameters.AddWithValue("bibId", bibliographyId);
                var exists = await checkCmd.ExecuteScalarAsync();
                if (exists != null)
                {
                    throw new InvalidOperationException("You already have an active reservation for this book.");
                }
            }

            // 2. Calculate queue position
            const string queueSql = @"
                SELECT COUNT(*)
                FROM reservations
                WHERE bibliography_id = @bibId
                  AND status = 'PENDING';
            ";

            int queuePosition = 1;
            await using (var queueCmd = new NpgsqlCommand(queueSql, conn))
            {
                queueCmd.Parameters.AddWithValue("bibId", bibliographyId);
                var count = Convert.ToInt32(await queueCmd.ExecuteScalarAsync());
                queuePosition = count + 1;
            }

            // 3. Insert reservation
            var reservation = new Reservation
            {
                Id = Guid.NewGuid(),
                StudentId = studentId,
                BibliographyId = bibliographyId,
                ReservedAt = DateTime.UtcNow,
                Status = "PENDING",
                QueuePosition = queuePosition,
                CreatedAt = DateTime.UtcNow
            };

            const string insertSql = @"
                INSERT INTO reservations (id, student_id, bibliography_id, reserved_at, status, queue_position, created_at)
                VALUES (@id, @studentId, @bibId, @reservedAt, @status, @queue, @createdAt);
            ";

            await using (var insertCmd = new NpgsqlCommand(insertSql, conn))
            {
                insertCmd.Parameters.AddWithValue("id", reservation.Id);
                insertCmd.Parameters.AddWithValue("studentId", reservation.StudentId);
                insertCmd.Parameters.AddWithValue("bibId", reservation.BibliographyId);
                insertCmd.Parameters.AddWithValue("reservedAt", reservation.ReservedAt);
                insertCmd.Parameters.AddWithValue("status", reservation.Status);
                insertCmd.Parameters.AddWithValue("queue", reservation.QueuePosition);
                insertCmd.Parameters.AddWithValue("createdAt", reservation.CreatedAt);
                await insertCmd.ExecuteNonQueryAsync();
            }

            return reservation;
        }

        public async Task CancelReservationAsync(Guid reservationId)
        {
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            const string sql = @"
                UPDATE reservations
                SET status = 'CANCELLED',
                    updated_at = NOW()
                WHERE id = @id;
            ";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", reservationId);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task CheckAndNotifyReservationsAsync(Guid bibliographyId)
        {
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            const string sql = @"
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

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("bibId", bibliographyId);
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
