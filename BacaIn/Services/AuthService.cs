using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BacaIn.Data;
using BacaIn.Models;
using Npgsql;

namespace BacaIn.Services
{
    public class AuthService
    {
        private static AuthService? _instance;
        public static AuthService Instance => _instance ??= new AuthService();

        public async Task<User?> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            var hash = DatabaseContext.HashPassword(password.Trim());
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            const string sql = @"
                SELECT id, username, password_hash, display_name, role, created_at, updated_at
                FROM users
                WHERE LOWER(username) = LOWER(@username)
                  AND password_hash = @hash
                  AND deleted_at IS NULL
                LIMIT 1;
            ";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("username", username.Trim());
            cmd.Parameters.AddWithValue("hash", hash);

            await using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                var user = new User
                {
                    Id = reader.GetGuid(0),
                    Username = reader.GetString(1),
                    PasswordHash = reader.GetString(2),
                    DisplayName = reader.IsDBNull(3) ? null : reader.GetString(3),
                    Role = reader.GetString(4),
                    CreatedAt = reader.GetDateTime(5),
                    UpdatedAt = reader.IsDBNull(6) ? null : reader.GetDateTime(6)
                };

                CurrentUser.Current = user;
                return user;
            }

            return null;
        }

        public async Task<User> RegisterStudentAsync(string username, string displayName, string password)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("Username cannot be empty.", nameof(username));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password cannot be empty.", nameof(password));

            var hash = DatabaseContext.HashPassword(password.Trim());
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = username.Trim(),
                DisplayName = displayName?.Trim(),
                PasswordHash = hash,
                Role = "student",
                CreatedAt = DateTime.UtcNow
            };

            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            const string sql = @"
                INSERT INTO users (id, username, password_hash, display_name, role, created_at)
                VALUES (@id, @username, @hash, @displayName, 'student', @createdAt);
            ";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", user.Id);
            cmd.Parameters.AddWithValue("username", user.Username);
            cmd.Parameters.AddWithValue("hash", user.PasswordHash);
            cmd.Parameters.AddWithValue("displayName", (object?)user.DisplayName ?? DBNull.Value);
            cmd.Parameters.AddWithValue("createdAt", user.CreatedAt);

            await cmd.ExecuteNonQueryAsync();
            return user;
        }

        public async Task<List<User>> GetStudentsAsync(string? keyword = null)
        {
            var list = new List<User>();
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            var sql = @"
                SELECT id, username, password_hash, display_name, role, created_at, updated_at
                FROM users
                WHERE role = 'student' AND deleted_at IS NULL
            ";

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sql += @" AND (LOWER(username) LIKE @kw OR LOWER(display_name) LIKE @kw)";
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
                    PasswordHash = reader.GetString(2),
                    DisplayName = reader.IsDBNull(3) ? null : reader.GetString(3),
                    Role = reader.GetString(4),
                    CreatedAt = reader.GetDateTime(5),
                    UpdatedAt = reader.IsDBNull(6) ? null : reader.GetDateTime(6)
                });
            }

            return list;
        }

        public async Task UpdateStudentAsync(Guid id, string displayName, string? newPassword)
        {
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            string sql;
            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                sql = @"
                    UPDATE users
                    SET display_name = @displayName,
                        password_hash = @hash,
                        updated_at = NOW()
                    WHERE id = @id;
                ";
            }
            else
            {
                sql = @"
                    UPDATE users
                    SET display_name = @displayName,
                        updated_at = NOW()
                    WHERE id = @id;
                ";
            }

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("displayName", (object?)displayName?.Trim() ?? DBNull.Value);
            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                cmd.Parameters.AddWithValue("hash", DatabaseContext.HashPassword(newPassword.Trim()));
            }

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            const string sql = "UPDATE users SET deleted_at = NOW() WHERE id = @id;";
            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", id);
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
