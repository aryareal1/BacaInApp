using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace BacaIn.Data
{
    public class DatabaseContext
    {
        private static DatabaseContext? _instance;
        public static DatabaseContext Instance => _instance ??= new DatabaseContext();

        public string ConnectionString { get; set; } = "Host=localhost;Database=bacain;Username=postgres;Password=postgres;Include Error Detail=true;";

        public DatabaseContext()
        {
            var envConn = Environment.GetEnvironmentVariable("BACA_IN_CONNECTION_STRING");
            if (!string.IsNullOrWhiteSpace(envConn))
            {
                ConnectionString = FormatConnectionString(envConn);
            }
        }

        public static string FormatConnectionString(string raw)
        {
            if (raw.StartsWith("postgres://") || raw.StartsWith("postgresql://"))
            {
                var uri = new Uri(raw);
                var userInfo = uri.UserInfo.Split(':');
                var user = userInfo.Length > 0 ? userInfo[0] : "postgres";
                var pass = userInfo.Length > 1 ? userInfo[1] : "";
                var port = uri.Port > 0 ? uri.Port : 5432;
                var db = uri.AbsolutePath.TrimStart('/');
                var csb = new NpgsqlConnectionStringBuilder
                {
                    Host = uri.Host,
                    Port = port,
                    Database = string.IsNullOrEmpty(db) ? "bacain" : db,
                    Username = user
                };
                if (!string.IsNullOrEmpty(pass))
                {
                    csb.Password = pass;
                }
                return csb.ConnectionString;
            }
            return raw;
        }

        public NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }

        public async Task MigrateAndSeedAsync()
        {
            await using var conn = CreateConnection();
            try
            {
                await conn.OpenAsync();
            }
            catch (NpgsqlException)
            {
                // Try without password if password authentication failed or wasn't needed
                if (ConnectionString.Contains("Password="))
                {
                    var csb = new NpgsqlConnectionStringBuilder(ConnectionString)
                    {
                        Password = null
                    };
                    ConnectionString = csb.ConnectionString;
                    await using var fallbackConn = CreateConnection();
                    await fallbackConn.OpenAsync();
                    await ExecuteMigrationAsync(fallbackConn);
                    return;
                }
                throw;
            }

            await ExecuteMigrationAsync(conn);
        }

        private async Task ExecuteMigrationAsync(NpgsqlConnection conn)
        {
            const string createTablesSql = @"
                CREATE TABLE IF NOT EXISTS users (
                    id UUID PRIMARY KEY,
                    username VARCHAR(255) NOT NULL UNIQUE,
                    password_hash TEXT NOT NULL,
                    display_name VARCHAR(255),
                    role VARCHAR(50) NOT NULL,
                    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
                    updated_at TIMESTAMPTZ,
                    deleted_at TIMESTAMPTZ
                );

                CREATE TABLE IF NOT EXISTS bibliographies (
                    id UUID PRIMARY KEY,
                    title VARCHAR(255) NOT NULL,
                    isbn VARCHAR(13),
                    author VARCHAR(255) NOT NULL,
                    publisher VARCHAR(255) NOT NULL,
                    publisher_year INT,
                    description TEXT,
                    cover_url TEXT,
                    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
                    updated_at TIMESTAMPTZ,
                    deleted_at TIMESTAMPTZ
                );

                CREATE TABLE IF NOT EXISTS exemplars (
                    id UUID PRIMARY KEY,
                    bibliography_id UUID NOT NULL REFERENCES bibliographies(id) ON DELETE CASCADE,
                    barcode VARCHAR(50) NOT NULL UNIQUE,
                    status VARCHAR(50) NOT NULL DEFAULT 'AVAILABLE',
                    condition VARCHAR(50) NOT NULL DEFAULT 'GOOD',
                    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
                    updated_at TIMESTAMPTZ,
                    deleted_at TIMESTAMPTZ
                );

                CREATE TABLE IF NOT EXISTS loans (
                    id UUID PRIMARY KEY,
                    student_id UUID NOT NULL REFERENCES users(id),
                    exemplar_id UUID NOT NULL REFERENCES exemplars(id),
                    borrowed_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
                    due_at TIMESTAMPTZ NOT NULL,
                    returned_at TIMESTAMPTZ,
                    status VARCHAR(50) NOT NULL DEFAULT 'ACTIVATE',
                    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
                    updated_at TIMESTAMPTZ
                );

                CREATE TABLE IF NOT EXISTS reservations (
                    id UUID PRIMARY KEY,
                    student_id UUID NOT NULL REFERENCES users(id),
                    bibliography_id UUID NOT NULL REFERENCES bibliographies(id),
                    reserved_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
                    status VARCHAR(50) NOT NULL DEFAULT 'PENDING',
                    queue_position INT NOT NULL DEFAULT 1,
                    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
                    updated_at TIMESTAMPTZ
                );

                CREATE TABLE IF NOT EXISTS check_ins (
                    id UUID PRIMARY KEY,
                    student_id UUID NOT NULL REFERENCES users(id),
                    checked_in_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
                );

                CREATE INDEX IF NOT EXISTS idx_users_username ON users(username);
                CREATE INDEX IF NOT EXISTS idx_exemplars_bib_id ON exemplars(bibliography_id);
                CREATE INDEX IF NOT EXISTS idx_exemplars_barcode ON exemplars(barcode);
                CREATE INDEX IF NOT EXISTS idx_loans_student_id ON loans(student_id);
                CREATE INDEX IF NOT EXISTS idx_loans_status ON loans(status);
                CREATE INDEX IF NOT EXISTS idx_reservations_bib_id ON reservations(bibliography_id);
                CREATE INDEX IF NOT EXISTS idx_reservations_student_id ON reservations(student_id);
                CREATE INDEX IF NOT EXISTS idx_check_ins_student_id ON check_ins(student_id);
            ";

            await using (var cmd = new NpgsqlCommand(createTablesSql, conn))
            {
                await cmd.ExecuteNonQueryAsync();
            }

            await SeedDataAsync(conn);
        }

        public static string HashPassword(string password)
        {
            // Consistent SHA-256 with project salt
            var salt = "BacaIn_Salt_2026";
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
            return Convert.ToHexString(bytes).ToLowerInvariant();
        }

        private async Task SeedDataAsync(NpgsqlConnection conn)
        {
            // Check if users already seeded
            await using (var countCmd = new NpgsqlCommand("SELECT COUNT(*) FROM users", conn))
            {
                var count = Convert.ToInt64(await countCmd.ExecuteScalarAsync());
                if (count > 0) return;
            }

            // Seed Users
            var adminId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var studentId = Guid.Parse("22222222-2222-2222-2222-222222222222");

            var adminHash = HashPassword("admin123");
            var ajiHash = HashPassword("aji123");

            await using (var insertUsers = new NpgsqlCommand(@"
                INSERT INTO users (id, username, password_hash, display_name, role) VALUES
                (@adminId, 'admin', @adminHash, 'Head Librarian', 'admin'),
                (@studentId, 'aji', @ajiHash, 'Aji Pratama', 'student');
            ", conn))
            {
                insertUsers.Parameters.AddWithValue("adminId", adminId);
                insertUsers.Parameters.AddWithValue("adminHash", adminHash);
                insertUsers.Parameters.AddWithValue("studentId", studentId);
                insertUsers.Parameters.AddWithValue("ajiHash", ajiHash);
                await insertUsers.ExecuteNonQueryAsync();
            }

            // Seed Bibliographies
            var book1Id = Guid.Parse("33333333-3333-3333-3333-333333333331");
            var book2Id = Guid.Parse("33333333-3333-3333-3333-333333333332");
            var book3Id = Guid.Parse("33333333-3333-3333-3333-333333333333");

            await using (var insertBooks = new NpgsqlCommand(@"
                INSERT INTO bibliographies (id, title, isbn, author, publisher, publisher_year, description) VALUES
                (@b1, 'Laskar Pelangi', '9789793062792', 'Andrea Hirata', 'Bentang Pustaka', 2005, 'A story of friendship and education on Belitung Island.'),
                (@b2, 'Bumi Manusia', '9789799731234', 'Pramoedya Ananta Toer', 'Hasta Mitra', 1980, 'First book of the Buru Quartet portraying Minke during Dutch colonial rule.'),
                (@b3, 'Negeri 5 Menara', '9789792248616', 'Ahmad Fuadi', 'Gramedia Pustaka Utama', 2009, 'Inspirational novel about six students in an Islamic boarding school in East Java.');
            ", conn))
            {
                insertBooks.Parameters.AddWithValue("b1", book1Id);
                insertBooks.Parameters.AddWithValue("b2", book2Id);
                insertBooks.Parameters.AddWithValue("b3", book3Id);
                await insertBooks.ExecuteNonQueryAsync();
            }

            // Seed Exemplars
            // Book 1: BK-001 (AVAILABLE), BK-002 (BORROWED), BK-003 (AVAILABLE), BK-004 (DAMAGED)
            var ex1 = Guid.Parse("44444444-4444-4444-4444-444444444401");
            var ex2 = Guid.Parse("44444444-4444-4444-4444-444444444402");
            var ex3 = Guid.Parse("44444444-4444-4444-4444-444444444403");
            var ex4 = Guid.Parse("44444444-4444-4444-4444-444444444404");

            // Book 2: BK-005 (AVAILABLE), BK-006 (BORROWED), BK-007 (BORROWED), BK-008 (BORROWED)
            var ex5 = Guid.Parse("44444444-4444-4444-4444-444444444405");
            var ex6 = Guid.Parse("44444444-4444-4444-4444-444444444406");
            var ex7 = Guid.Parse("44444444-4444-4444-4444-444444444407");
            var ex8 = Guid.Parse("44444444-4444-4444-4444-444444444408");

            // Book 3: BK-009 (AVAILABLE), BK-010 (AVAILABLE), BK-011 (AVAILABLE), BK-012 (AVAILABLE)
            var ex9 = Guid.Parse("44444444-4444-4444-4444-444444444409");
            var ex10 = Guid.Parse("44444444-4444-4444-4444-444444444410");
            var ex11 = Guid.Parse("44444444-4444-4444-4444-444444444411");
            var ex12 = Guid.Parse("44444444-4444-4444-4444-444444444412");

            await using (var insertEx = new NpgsqlCommand(@"
                INSERT INTO exemplars (id, bibliography_id, barcode, status, condition) VALUES
                (@e1, @b1, 'BK-001', 'AVAILABLE', 'GOOD'),
                (@e2, @b1, 'BK-002', 'BORROWED', 'GOOD'),
                (@e3, @b1, 'BK-003', 'AVAILABLE', 'NEW'),
                (@e4, @b1, 'BK-004', 'DAMAGED', 'FAIR'),

                (@e5, @b2, 'BK-005', 'AVAILABLE', 'GOOD'),
                (@e6, @b2, 'BK-006', 'BORROWED', 'GOOD'),
                (@e7, @b2, 'BK-007', 'BORROWED', 'FAIR'),
                (@e8, @b2, 'BK-008', 'BORROWED', 'POOR'),

                (@e9, @b3, 'BK-009', 'AVAILABLE', 'NEW'),
                (@e10, @b3, 'BK-010', 'AVAILABLE', 'GOOD'),
                (@e11, @b3, 'BK-011', 'AVAILABLE', 'GOOD'),
                (@e12, @b3, 'BK-012', 'AVAILABLE', 'GOOD');
            ", conn))
            {
                insertEx.Parameters.AddWithValue("b1", book1Id);
                insertEx.Parameters.AddWithValue("b2", book2Id);
                insertEx.Parameters.AddWithValue("b3", book3Id);
                insertEx.Parameters.AddWithValue("e1", ex1);
                insertEx.Parameters.AddWithValue("e2", ex2);
                insertEx.Parameters.AddWithValue("e3", ex3);
                insertEx.Parameters.AddWithValue("e4", ex4);
                insertEx.Parameters.AddWithValue("e5", ex5);
                insertEx.Parameters.AddWithValue("e6", ex6);
                insertEx.Parameters.AddWithValue("e7", ex7);
                insertEx.Parameters.AddWithValue("e8", ex8);
                insertEx.Parameters.AddWithValue("e9", ex9);
                insertEx.Parameters.AddWithValue("e10", ex10);
                insertEx.Parameters.AddWithValue("e11", ex11);
                insertEx.Parameters.AddWithValue("e12", ex12);
                await insertEx.ExecuteNonQueryAsync();
            }

            // Seed Loans for Aji matching wireframe:
            // 1. Active: Laskar Pelangi (BK-002), Borrowed: 7 days ago, Due: in 7 days
            // 2. Overdue: Bumi Manusia (BK-008), Borrowed: 20 days ago, Due: 6 days ago
            // 3. Returned: Negeri 5 Menara (BK-012), Borrowed: 30 days ago, Due: 16 days ago, Returned: 18 days ago
            var now = DateTime.UtcNow;
            await using (var insertLoans = new NpgsqlCommand(@"
                INSERT INTO loans (id, student_id, exemplar_id, borrowed_at, due_at, returned_at, status) VALUES
                (gen_random_uuid(), @studentId, @e2, @l1_b, @l1_d, NULL, 'ACTIVATE'),
                (gen_random_uuid(), @studentId, @e8, @l2_b, @l2_d, NULL, 'ACTIVATE'),
                (gen_random_uuid(), @studentId, @e12, @l3_b, @l3_d, @l3_r, 'RETURNED');
            ", conn))
            {
                insertLoans.Parameters.AddWithValue("studentId", studentId);
                insertLoans.Parameters.AddWithValue("e2", ex2);
                insertLoans.Parameters.AddWithValue("e8", ex8);
                insertLoans.Parameters.AddWithValue("e12", ex12);
                insertLoans.Parameters.AddWithValue("l1_b", now.AddDays(-7));
                insertLoans.Parameters.AddWithValue("l1_d", now.AddDays(7));
                insertLoans.Parameters.AddWithValue("l2_b", now.AddDays(-20));
                insertLoans.Parameters.AddWithValue("l2_d", now.AddDays(-6));
                insertLoans.Parameters.AddWithValue("l3_b", now.AddDays(-30));
                insertLoans.Parameters.AddWithValue("l3_d", now.AddDays(-16));
                insertLoans.Parameters.AddWithValue("l3_r", now.AddDays(-18));
                await insertLoans.ExecuteNonQueryAsync();
            }

            // Seed Reservations: Bumi Manusia for Aji (PENDING, Queue 2)
            await using (var insertRes = new NpgsqlCommand(@"
                INSERT INTO reservations (id, student_id, bibliography_id, reserved_at, status, queue_position) VALUES
                (gen_random_uuid(), @studentId, @b2, @r_time, 'PENDING', 2);
            ", conn))
            {
                insertRes.Parameters.AddWithValue("studentId", studentId);
                insertRes.Parameters.AddWithValue("b2", book2Id);
                insertRes.Parameters.AddWithValue("r_time", now.AddDays(-2));
                await insertRes.ExecuteNonQueryAsync();
            }

            // Seed Check-ins for Aji: visits matching wireframe
            await using (var insertCheckins = new NpgsqlCommand(@"
                INSERT INTO check_ins (id, student_id, checked_in_at) VALUES
                (gen_random_uuid(), @studentId, @c1),
                (gen_random_uuid(), @studentId, @c2),
                (gen_random_uuid(), @studentId, @c3);
            ", conn))
            {
                insertCheckins.Parameters.AddWithValue("studentId", studentId);
                insertCheckins.Parameters.AddWithValue("c1", now.AddDays(-10).Date.AddHours(8).AddMinutes(15));
                insertCheckins.Parameters.AddWithValue("c2", now.AddDays(-5).Date.AddHours(13).AddMinutes(40));
                insertCheckins.Parameters.AddWithValue("c3", now.AddDays(-1).Date.AddHours(9).AddMinutes(5));
                await insertCheckins.ExecuteNonQueryAsync();
            }
        }
    }
}
