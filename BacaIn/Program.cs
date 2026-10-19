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
            if (args.Length > 0 && args[0] == "--test-books")
            {
                Data.DatabaseContext.Instance.MigrateAndSeedAsync().GetAwaiter().GetResult();
                var bookService = Services.BookService.Instance;
                var initialBooks = bookService.SearchBibliographiesAsync().GetAwaiter().GetResult();

                var newBook = new Models.Bibliography
                {
                    Title = "Test Book Automation",
                    Author = "Test Author",
                    Publisher = "Test Publisher",
                    PublisherYear = 2026,
                    Isbn = "9781234567897"
                };
                var created = bookService.CreateBibliographyAsync(newBook).GetAwaiter().GetResult();
                var copy = bookService.AddExemplarAsync(created.Id, "TEST-BARCODE-99", "NEW").GetAwaiter().GetResult();
                var copies = bookService.GetExemplarsAsync(created.Id).GetAwaiter().GetResult();
                
                // Clean up test book
                bookService.DeleteBibliographyAsync(created.Id).GetAwaiter().GetResult();
                var remaining = bookService.SearchBibliographiesAsync().GetAwaiter().GetResult();

                if (initialBooks.Count >= 3 && created != null && copies.Count == 1 && remaining.Count == initialBooks.Count)
                {
                    Console.WriteLine("BOOKS_TEST_PASS");
                }
                else
                {
                    Console.WriteLine("BOOKS_TEST_FAIL");
                }
                return;
            }
            if (args.Length > 0 && args[0] == "--test-loans")
            {
                Data.DatabaseContext.Instance.MigrateAndSeedAsync().GetAwaiter().GetResult();
                var loanService = Services.LoanService.Instance;
                var studentId = Guid.Parse("22222222-2222-2222-2222-222222222222"); // aji

                // 1. Check Aji has overdue loan
                var hasOverdue = loanService.HasOverdueLoansAsync(studentId).GetAwaiter().GetResult();

                // 2. Creating loan should throw due to overdue block
                bool blocked = false;
                var availCopies = loanService.GetAvailableExemplarsAsync().GetAwaiter().GetResult();
                try
                {
                    loanService.CreateLoanAsync(studentId, availCopies[0].Id).GetAwaiter().GetResult();
                }
                catch
                {
                    blocked = true;
                }

                // 3. Return the overdue loan
                var ajiLoans = loanService.GetLoansForStudentAsync(studentId).GetAwaiter().GetResult();
                var overdueLoan = ajiLoans.Find(x => x.IsOverdue);
                var returnResult = loanService.ReturnLoanAsync(overdueLoan!.Id).GetAwaiter().GetResult();

                // 4. Now create loan succeeds
                var newLoan = loanService.CreateLoanAsync(studentId, availCopies[0].Id).GetAwaiter().GetResult();

                if (hasOverdue && blocked && returnResult.isLate && returnResult.fineAmount > 0 && newLoan != null)
                {
                    Console.WriteLine("LOANS_TEST_PASS");
                }
                else
                {
                    Console.WriteLine("LOANS_TEST_FAIL");
                }
                return;
            }
            if (args.Length > 0 && args[0] == "--test-reservations")
            {
                Data.DatabaseContext.Instance.MigrateAndSeedAsync().GetAwaiter().GetResult();
                var resService = Services.ReservationService.Instance;
                var studentId = Guid.Parse("22222222-2222-2222-2222-222222222222"); // aji
                var book2Id = Guid.Parse("33333333-3333-3333-3333-333333333332");   // Bumi Manusia
                var book1Id = Guid.Parse("33333333-3333-3333-3333-333333333331");   // Laskar Pelangi

                // 1. Initial reservations for Aji
                var ajiRes = resService.GetStudentReservationsAsync(studentId).GetAwaiter().GetResult();

                // 2. Duplicate active reservation should throw
                bool duplicateBlocked = false;
                try
                {
                    resService.MakeReservationAsync(studentId, book2Id).GetAwaiter().GetResult();
                }
                catch
                {
                    duplicateBlocked = true;
                }

                // 3. New reservation for Book 1
                var newRes = resService.MakeReservationAsync(studentId, book1Id).GetAwaiter().GetResult();

                // 4. Cancel new reservation
                resService.CancelReservationAsync(newRes.Id).GetAwaiter().GetResult();
                var afterCancel = resService.GetStudentReservationsAsync(studentId).GetAwaiter().GetResult();
                var cancelledItem = afterCancel.Find(x => x.Id == newRes.Id);

                if (ajiRes.Count >= 1 && duplicateBlocked && newRes != null && cancelledItem?.Status == "CANCELLED")
                {
                    Console.WriteLine("RESERVATIONS_TEST_PASS");
                }
                else
                {
                    Console.WriteLine("RESERVATIONS_TEST_FAIL");
                }
                return;
            }
            if (args.Length > 0 && args[0] == "--test-student-portal")
            {
                Data.DatabaseContext.Instance.MigrateAndSeedAsync().GetAwaiter().GetResult();
                var studentId = Guid.Parse("22222222-2222-2222-2222-222222222222"); // aji
                var catalog = Services.BookService.Instance.SearchBibliographiesAsync(null, availableOnly: false).GetAwaiter().GetResult();
                var myLoans = Services.LoanService.Instance.GetLoansForStudentAsync(studentId).GetAwaiter().GetResult();
                var history = Services.CheckInService.Instance.GetHistoryAsync(studentId, DateTime.UtcNow.AddDays(-30), DateTime.UtcNow).GetAwaiter().GetResult();

                if (catalog.Count >= 3 && myLoans.Count >= 1 && history.Count >= 1)
                {
                    Console.WriteLine("STUDENT_PORTAL_TEST_PASS");
                }
                else
                {
                    Console.WriteLine("STUDENT_PORTAL_TEST_FAIL");
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