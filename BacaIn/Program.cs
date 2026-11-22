using BacaIn.Data;
using Microsoft.EntityFrameworkCore;

namespace BacaIn
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// <remarks>Run with <c>--seed</c> to populate the database with sample data and exit.</remarks>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Contains("--seed", StringComparer.OrdinalIgnoreCase))
            {
                using var db = new AppDbContext();
                db.Database.Migrate();
                DatabaseSeeder.Seed(db);
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}
