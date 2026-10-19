namespace BacaIn
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0 && (args[0] == "--migrate" || args[0] == "--test-db"))
            {
                Data.DatabaseContext.Instance.MigrateAndSeedAsync().GetAwaiter().GetResult();
                Console.WriteLine("MIGRATION_SUCCESS");
                return;
            }
            if (args.Length > 0 && args[0] == "--test-auth")
            {
                Data.DatabaseContext.Instance.MigrateAndSeedAsync().GetAwaiter().GetResult();
                var auth = Services.AuthService.Instance;
                var adminUser = auth.LoginAsync("admin", "admin123").GetAwaiter().GetResult();
                var studentUser = auth.LoginAsync("aji", "aji123").GetAwaiter().GetResult();
                var badUser = auth.LoginAsync("admin", "wrongpassword").GetAwaiter().GetResult();
                var missingUser = auth.LoginAsync("nonexistent", "123").GetAwaiter().GetResult();

                if (adminUser != null && adminUser.IsAdmin &&
                    studentUser != null && studentUser.IsStudent &&
                    badUser == null && missingUser == null)
                {
                    Console.WriteLine("AUTH_TEST_PASS");
                }
                else
                {
                    Console.WriteLine("AUTH_TEST_FAIL");
                }
                return;
            }
            if (args.Length > 0 && args[0] == "--test-checkin")
            {
                Data.DatabaseContext.Instance.MigrateAndSeedAsync().GetAwaiter().GetResult();
                var service = Services.CheckInService.Instance;
                
                // Test 1: non-existent student should throw
                bool missingThrows = false;
                try { service.CheckInAsync("fake_user_404").GetAwaiter().GetResult(); }
                catch { missingThrows = true; }

                // Test 2: first check-in for aji should succeed (delete any today's record first for clean test)
                using (var conn = Data.DatabaseContext.Instance.CreateConnection())
                {
                    conn.Open();
                    using var del = new Npgsql.NpgsqlCommand("DELETE FROM check_ins WHERE student_id = '22222222-2222-2222-2222-222222222222' AND checked_in_at::date = CURRENT_DATE;", conn);
                    del.ExecuteNonQuery();
                }
                var first = service.CheckInAsync("aji").GetAwaiter().GetResult();

                // Test 3: duplicate check-in today should throw
                bool duplicateThrows = false;
                try { service.CheckInAsync("aji").GetAwaiter().GetResult(); }
                catch { duplicateThrows = true; }

                if (missingThrows && first != null && duplicateThrows)
                {
                    Console.WriteLine("CHECKIN_TEST_PASS");
                }
                else
                {
                    Console.WriteLine("CHECKIN_TEST_FAIL");
                }
                return;
            }
            if (args.Length > 0 && (args[0] == "--kiosk" || args[0] == "--checkin"))
            {
                ApplicationConfiguration.Initialize();
                try
                {
                    Data.DatabaseContext.Instance.MigrateAndSeedAsync().GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to initialize database: " + ex.Message, "Database Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Application.Run(new CheckinForm());
                return;
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            try
            {
                Data.DatabaseContext.Instance.MigrateAndSeedAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to initialize database: " + ex.Message, "Database Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Application.Run(new LoginForm());
        }
    }
}