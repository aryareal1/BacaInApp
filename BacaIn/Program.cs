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