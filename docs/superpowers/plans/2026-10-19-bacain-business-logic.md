# BacaIn Business Logic & Database Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Implement PostgreSQL database integration via Npgsql, complete business logic services derived from `docs/plan.drawio`, and wire/clean up all Windows Forms pages and dialogs for ready use.

**Architecture:** A lightweight direct Npgsql data layer with parameterized SQL queries powers dedicated domain services (`AuthService`, `BookService`, `LoanService`, `ReservationService`, `CheckInService`, `ReportService`). Forms and UserControls consume these services asynchronously, keeping designer files serialization-clean while removing preview placeholders and adding dialogs for book editing, lending, returns, check-in, and reports.

**Tech Stack:** C# 12 / .NET 10 WinForms, Npgsql (v9.x), Guna.UI2.WinForms, System.Drawing.Printing (Native PrintDocument).

**Spec:** `docs/superpowers/specs/2026-10-19-bacain-business-logic-design.md`

## Global Constraints
- Target Framework: `net10.0-windows` with `<Nullable>enable</Nullable>`.
- Database connection string: `Host=localhost;Database=bacain;Username=postgres;Password=postgres;` (matching `postgres://postgres@localhost/bacain`).
- Loan duration: 14 days fixed interval (`due_at = borrowed_at + 14 days`).
- Overdue fine rate: Rp 1.000 per day late.
- Check-in entrance: Dedicated `CheckinForm` accessible via `--kiosk` / `--checkin` CLI arguments or `Ctrl+Shift+K` on `LoginForm` with no visible hints on `LoginForm`.
- Reports Print/Save PDF: Native WinForms `PrintDocument` with `PrintPreviewDialog` / `PrintDialog`.
- UI Design Guide: Light theme adhering to `DESIGN.md`. All `previewLabel` controls across all pages removed or hidden.
- WinForms Designer Safety: Never place business logic or lambdas in `*.Designer.cs`. Put all event handling, async data calls, and wiring in the main partial classes.

## Review Focus
1. PostgreSQL connection failure on startup: Handle gracefully with descriptive user alert rather than crashing.
2. Concurrent check-ins on the same day: Strict date-truncation deduplication (`checked_in_at::date = CURRENT_DATE`).
3. Loan creation when student has overdue books: Prevent checkout if any active loan is past its `due_at`.
4. Exemplar status synchronization: Exemplar becomes `BORROWED` on checkout and `AVAILABLE` on return; reservations promoted to `READY` when copies become available.
5. ISBN Lookup timeout or invalid response: Gracefully handle network errors or missing books from OpenLibrary without blocking manual entry.

---

### Task 1: Package Setup, Database Models, and DatabaseContext with Auto-Migration

**Files:**
- Modify: `BacaIn/BacaIn.csproj`
- Create: `BacaIn/Models/User.cs`
- Create: `BacaIn/Models/Bibliography.cs`
- Create: `BacaIn/Models/Exemplar.cs`
- Create: `BacaIn/Models/Loan.cs`
- Create: `BacaIn/Models/Reservation.cs`
- Create: `BacaIn/Models/CheckIn.cs`
- Create: `BacaIn/Data/DatabaseContext.cs`

**Interfaces:**
- Produces: `DatabaseContext.Instance`, `DatabaseContext.MigrateAndSeedAsync()`, `DatabaseContext.CreateConnection()`, Domain model types.

- [ ] **Step 1: Add Npgsql package reference to BacaIn.csproj**

Add `<PackageReference Include="Npgsql" Version="9.0.3" />` inside `<ItemGroup>`.

- [ ] **Step 2: Create Model files**

Create records/classes in `BacaIn/Models/`:
- `User`: `Id`, `Username`, `PasswordHash`, `DisplayName`, `Role`, `CreatedAt`, `UpdatedAt`, `DeletedAt`.
- `Bibliography`: `Id`, `Title`, `Isbn`, `Author`, `Publisher`, `PublisherYear`, `Description`, `CoverUrl`, `TotalCopies`, `AvailableCopies`.
- `Exemplar`: `Id`, `BibliographyId`, `Barcode`, `Status`, `Condition`, `CreatedAt`.
- `Loan`: `Id`, `StudentId`, `StudentName`, `ExemplarId`, `Barcode`, `BookTitle`, `Author`, `BorrowedAt`, `DueAt`, `ReturnedAt`, `Status`, `IsOverdue`, `DaysOverdue`, `FineAmount`.
- `Reservation`: `Id`, `StudentId`, `BibliographyId`, `BookTitle`, `ReservedAt`, `Status`, `QueuePosition`.
- `CheckIn`: `Id`, `StudentId`, `StudentName`, `CheckedInAt`.

- [ ] **Step 3: Create DatabaseContext.cs**

Implement connection string handling, `CreateConnection()`, table creation scripts for all 6 tables, index creation, and initial seed insertion (admin, aji, 3 books, copies, sample loans, reservations, check-ins).

- [ ] **Step 4: Verify migration and seeding**

Run `dotnet build BacaIn/BacaIn.csproj`. Execute one-off runner or verification script to verify tables are created and seeded in PostgreSQL.

- [ ] **Step 5: Commit**

```bash
git add BacaIn/BacaIn.csproj BacaIn/Models/ BacaIn/Data/
git commit -m "feat(db): add Npgsql, domain models, and DatabaseContext migration"
```

---

### Task 2: AuthService, Session State, and LoginForm Integration

**Files:**
- Create: `BacaIn/Services/AuthService.cs`
- Create: `BacaIn/Services/CurrentUser.cs`
- Modify: `BacaIn/LoginForm.cs`
- Modify: `BacaIn/AdminForm.cs`
- Modify: `BacaIn/StudentForm.cs`

**Interfaces:**
- Consumes: `DatabaseContext`, `User`.
- Produces: `AuthService.LoginAsync(username, password)`, `AuthService.HashPassword(password)`, `CurrentUser.Current`, `CurrentUser.Logout()`.

- [ ] **Step 1: Implement AuthService and CurrentUser**

`AuthService`:
- Uses PBKDF2 / SHA256 with salt for hashing.
- `LoginAsync(string username, string password)`: queries `users` table, verifies hash, sets `CurrentUser.Current`, returns `User?`.
- `RegisterStudentAsync(string username, string displayName, string password)`: creates student user.

- [ ] **Step 2: Wire LoginForm**

In `LoginForm.cs`:
- On `loginButton.Click` or Enter key in textboxes: validate inputs not empty, call `await authService.LoginAsync(username, password)`.
- If invalid: set `accessHelpLabel.ForeColor = Color.Red`, `accessHelpLabel.Text = "Invalid username or password."`.
- If valid:
  - If admin: open `AdminForm`, hide `LoginForm`.
  - If student: open `StudentForm`, hide `LoginForm`.
- Wire `FormClosed` on opened forms or logout event to show `LoginForm` again and clear fields.

- [ ] **Step 3: Wire Logout in AdminForm and StudentForm**

- In `AdminForm.cs`: connect `logoutButton.Click` -> confirm with `MessageBox.Show("Are you sure you want to log out?", ...)`. If yes, clear `CurrentUser`, close/hide `AdminForm`, show `LoginForm`.
- In `StudentForm.cs`: connect `logoutButton.Click` similarly.

- [ ] **Step 4: Verify login and role navigation**

Build and verify login with `admin`/`admin123` opens AdminForm and `aji`/`aji123` opens StudentForm.

- [ ] **Step 5: Commit**

```bash
git add BacaIn/Services/AuthService.cs BacaIn/Services/CurrentUser.cs BacaIn/LoginForm.cs BacaIn/AdminForm.cs BacaIn/StudentForm.cs
git commit -m "feat(auth): implement AuthService and wire LoginForm with role routing"
```

---

### Task 3: CheckinForm Kiosk and Entrance Launch Integration

**Files:**
- Create: `BacaIn/CheckinForm.cs`
- Create: `BacaIn/CheckinForm.Designer.cs`
- Create: `BacaIn/Services/CheckInService.cs`
- Modify: `BacaIn/Program.cs`
- Modify: `BacaIn/LoginForm.cs`

**Interfaces:**
- Consumes: `DatabaseContext`, `CheckIn`.
- Produces: `CheckInService.CheckInAsync(username)`, `CheckInService.GetHistoryAsync(studentId, from, to)`, `CheckinForm`.

- [ ] **Step 1: Implement CheckInService**

In `BacaIn/Services/CheckInService.cs`:
- `CheckInAsync(string username)`:
  - Finds student in `users` table (`role = 'student' AND deleted_at IS NULL`). If not found, throw `InvalidOperationException("Student account not found.")`.
  - Queries `SELECT 1 FROM check_ins WHERE student_id = @id AND checked_in_at::date = CURRENT_DATE`. If found, throw `InvalidOperationException("Already checked in today.")`.
  - Inserts `check_ins` record. Returns created `CheckIn` record with student display name and timestamp.
- `GetHistoryAsync(Guid studentId, DateTime fromDate, DateTime toDate)`: queries records between dates ordered by `checked_in_at DESC`.

- [ ] **Step 2: Create CheckinForm designer & class**

In `BacaIn/CheckinForm.cs` and `CheckinForm.Designer.cs`:
- Clean, focused entrance kiosk form with BacaIn logo, title "Library Check-In Kiosk".
- Labeled `Guna2TextBox` for Username / Card scan.
- Primary "Check In" button.
- Status feedback card (initially hidden, shows student name and entry time in green on success, or error message in red on failure).
- Auto-focus input, auto-clear after 3 seconds.

- [ ] **Step 3: Wire CLI arguments and LoginForm hotkey**

- In `Program.cs`:
  ```csharp
  if (args.Contains("--kiosk") || args.Contains("--checkin"))
  {
      Application.Run(new CheckinForm());
      return;
  }
  ```
- In `LoginForm.cs`:
  - Set `KeyPreview = true;`.
  - Handle `KeyDown`: if `e.Control && e.Shift && e.KeyCode == Keys.K`, open new `CheckinForm().Show();`.
  - Ensure zero hints or labels are added to LoginForm.

- [ ] **Step 4: Verify CheckinForm**

Run verification check testing username check-in and duplicate check-in prevention on the same calendar day.

- [ ] **Step 5: Commit**

```bash
git add BacaIn/CheckinForm* BacaIn/Services/CheckInService.cs BacaIn/Program.cs BacaIn/LoginForm.cs
git commit -m "feat(checkin): add CheckinForm kiosk, CheckInService, and entrance CLI/hotkey"
```

---

### Task 4: BookService, OpenLibrary ISBN Lookup, and BookEditDialog

**Files:**
- Create: `BacaIn/Services/BookService.cs`
- Create: `BacaIn/Controls/BookEditDialog.cs`
- Create: `BacaIn/Controls/BookEditDialog.Designer.cs`
- Modify: `BacaIn/Controls/BooksPage.cs`

**Interfaces:**
- Consumes: `DatabaseContext`, `Bibliography`, `Exemplar`.
- Produces: `BookService` CRUD methods, `BookEditDialog`.

- [ ] **Step 1: Implement BookService**

In `BacaIn/Services/BookService.cs`:
- `SearchBibliographiesAsync(string? keyword)`: returns list with copy counts.
- `GetBibliographyAsync(Guid id)`: returns single bibliography.
- `CreateBibliographyAsync(Bibliography book)`: inserts book.
- `UpdateBibliographyAsync(Bibliography book)`: updates book.
- `DeleteBibliographyAsync(Guid id)`: soft-deletes book.
- `LookupIsbnAsync(string isbn)`: calls OpenLibrary API via `HttpClient`, extracts title, author, publisher, publish year, and cover image URL.
- `GetExemplarsAsync(Guid bibliographyId)`: returns copies.
- `AddExemplarAsync(Guid bibliographyId, string barcode, string condition)`: inserts copy with status `AVAILABLE`.
- `UpdateExemplarAsync(Guid id, string status, string condition)`: updates copy.
- `DeleteExemplarAsync(Guid id)`: soft-deletes copy.

- [ ] **Step 2: Create BookEditDialog**

In `BacaIn/Controls/BookEditDialog.cs` (and `.Designer.cs`):
- Form modal matching the wireframe `Add & Modify Book`.
- Inputs: ISBN, Title, Author, Publisher, Publication Year, Description, Cover URL.
- "Lookup ISBN" button beside ISBN: calls `BookService.LookupIsbnAsync(isbn)`, populates fields, shows feedback.
- Exemplars table: lists copies (Barcode, Condition dropdown, Action).
- "Add Copy" input + button: generates/enters barcode, condition dropdown.
- "Save" and "Cancel" buttons.

- [ ] **Step 3: Connect BooksPage**

In `BacaIn/Controls/BooksPage.cs`:
- Hide `previewLabel`.
- In `OnLoad`: load bibliographies via `BookService.SearchBibliographiesAsync(null)`.
- `searchTextBox.TextChanged`: debounce/filter list.
- `addBookButton.Click`: open `BookEditDialog(null)`, reload on dialog OK.
- `booksGrid.CellContentClick`:
  - If `Modify`: open `BookEditDialog(selectedBookId)`, reload on dialog OK.
  - If `Delete`: confirm with `MessageBox.Show`, call `DeleteBibliographyAsync(selectedBookId)`, reload.

- [ ] **Step 4: Verify book management**

Build and verify book search, add, edit, ISBN lookup, and physical copies management.

- [ ] **Step 5: Commit**

```bash
git add BacaIn/Services/BookService.cs BacaIn/Controls/BookEditDialog* BacaIn/Controls/BooksPage.cs
git commit -m "feat(books): implement BookService, ISBN lookup, BookEditDialog, and BooksPage CRUD"
```

---

### Task 5: LoanService, CreateLoanDialog, and LoansReturnsPage

**Files:**
- Create: `BacaIn/Services/LoanService.cs`
- Create: `BacaIn/Controls/CreateLoanDialog.cs`
- Create: `BacaIn/Controls/CreateLoanDialog.Designer.cs`
- Modify: `BacaIn/Controls/LoansReturnsPage.cs`

**Interfaces:**
- Consumes: `DatabaseContext`, `Loan`, `Exemplar`.
- Produces: `LoanService` lending and return methods, `CreateLoanDialog`.

- [ ] **Step 1: Implement LoanService**

In `BacaIn/Services/LoanService.cs`:
- `GetActiveStudentsAsync(string? keyword)`: returns students for the selection list.
- `GetLoansForStudentAsync(Guid studentId, string? filter)`: returns active and past loans with calculated overdue flags and fine amounts.
- `HasOverdueLoansAsync(Guid studentId)`: checks if any active loan is past due date.
- `GetAvailableExemplarsAsync(string? keyword)`: returns copies where `status = 'AVAILABLE' AND deleted_at IS NULL`.
- `CreateLoanAsync(Guid studentId, Guid exemplarId, int durationDays = 14)`:
  - If `HasOverdueLoansAsync(studentId)`: throw `InvalidOperationException("Student has overdue loans. Cannot borrow until resolved.")`.
  - Creates loan (`borrowed_at = NOW()`, `due_at = NOW() + durationDays days`, `status = 'ACTIVATE'`).
  - Sets copy `status = 'BORROWED'`.
- `ReturnLoanAsync(Guid loanId)`:
  - Calculates overdue days and fine amount (`overdueDays * 1000`).
  - Sets loan `status = 'RETURNED'`, `returned_at = NOW()`.
  - Sets copy `status = 'AVAILABLE'`.
  - Calls `ReservationService.CheckAndNotifyReservationsAsync(bookId)`.

- [ ] **Step 2: Create CreateLoanDialog**

In `BacaIn/Controls/CreateLoanDialog.cs` (and `.Designer.cs`):
- Modal displaying selected student name.
- Search input for available book title / barcode.
- DataGridView of available exemplars (Title, Author, Barcode, Condition).
- "Issue Loan (14 Days)" primary button + "Cancel" button.

- [ ] **Step 3: Wire LoansReturnsPage**

In `BacaIn/Controls/LoansReturnsPage.cs`:
- Hide `studentsPreviewLabel` and `loansPreviewLabel`.
- In `OnLoad`: load students into `studentsGrid`.
- Selecting a student:
  - Updates `studentContextLabel.Text = "Student: " + selectedStudent.DisplayName`.
  - Loads that student's loans into `loansGrid`.
- `createLoanButton.Click`:
  - Check if student selected; check if student has overdue loans.
  - If overdue: show warning dialog.
  - Otherwise: open `CreateLoanDialog(selectedStudent)`, refresh loans on OK.
- `loansGrid.CellContentClick` on `Return` column:
  - If loan is already returned, ignore.
  - If overdue, prompt: `"Book is {days} days overdue. Calculated fine: Rp {fine:N0}. Confirm return and payment?"`.
  - If on time, prompt: `"Confirm book return?"`.
  - On confirm: call `LoanService.ReturnLoanAsync(loanId)`, refresh list.

- [ ] **Step 4: Verify loans and returns**

Build and verify checkout, overdue prevention, and return fine calculation.

- [ ] **Step 5: Commit**

```bash
git add BacaIn/Services/LoanService.cs BacaIn/Controls/CreateLoanDialog* BacaIn/Controls/LoansReturnsPage.cs
git commit -m "feat(loans): implement LoanService, CreateLoanDialog, and LoansReturnsPage lending workflow"
```

---

### Task 6: ReservationService and Student Portal Reservation Workflow

**Files:**
- Create: `BacaIn/Services/ReservationService.cs`
- Modify: `BacaIn/Controls/BookDetailPage.cs`
- Modify: `BacaIn/Controls/MyReservationsPage.cs`

**Interfaces:**
- Consumes: `DatabaseContext`, `Reservation`.
- Produces: `ReservationService` reservation operations.

- [ ] **Step 1: Implement ReservationService**

In `BacaIn/Services/ReservationService.cs`:
- `GetStudentReservationsAsync(Guid studentId, string? filter)`: returns reservations with book title, reserved date, status, queue position.
- `MakeReservationAsync(Guid studentId, Guid bibliographyId)`:
  - Checks if student already has active reservation for this book (`status IN ('PENDING', 'READY')`).
  - Calculates queue position (`COUNT(active) + 1`).
  - Inserts reservation with `status = 'PENDING'`. Returns queue position.
- `CancelReservationAsync(Guid reservationId)`: sets status to `CANCELLED`, adjusts queue numbers.
- `CheckAndNotifyReservationsAsync(Guid bibliographyId)`:
  - Finds oldest `PENDING` reservation for this book.
  - Updates status to `READY`.

- [ ] **Step 2: Wire BookDetailPage Reservation Button**

In `BacaIn/Controls/BookDetailPage.cs`:
- Hide `previewLabel`.
- Set book details and physical copies in `copiesGrid`.
- Update `availabilityLabel.Text = $"Available copies: {availableCount} of {totalCount}"`.
- `reserveButton.Click`:
  - Call `ReservationService.MakeReservationAsync(studentId, bookId)`.
  - Show confirmation message: `"Book reserved! Your queue position is #{queuePosition}."`.

- [ ] **Step 3: Wire MyReservationsPage**

In `BacaIn/Controls/MyReservationsPage.cs`:
- Hide `previewLabel`.
- In `OnLoad`: load student reservations via `ReservationService.GetStudentReservationsAsync`.
- Update summary chips (`Pending: X`, `Ready: Y`).
- `statusComboBox.SelectedIndexChanged`: filter list.
- `reservationsGrid.CellContentClick` on `Cancel`:
  - Confirm with `MessageBox.Show("Are you sure you want to cancel this reservation?", ...)`.
  - On confirm: call `CancelReservationAsync(reservationId)`, refresh list.

- [ ] **Step 4: Verify reservations**

Build and verify reserving book, queue assignment, and canceling reservations.

- [ ] **Step 5: Commit**

```bash
git add BacaIn/Services/ReservationService.cs BacaIn/Controls/BookDetailPage.cs BacaIn/Controls/MyReservationsPage.cs
git commit -m "feat(reservations): implement ReservationService, queue tracking, and reservation UI"
```

---

### Task 7: Student Portal Integration & Cleanup (Catalog, MyLoans, CheckInHistory)

**Files:**
- Modify: `BacaIn/Controls/CatalogPage.cs`
- Modify: `BacaIn/Controls/BookDetailPage.cs`
- Modify: `BacaIn/Controls/MyLoansPage.cs`
- Modify: `BacaIn/Controls/CheckInHistoryPage.cs`
- Modify: `BacaIn/StudentForm.cs`

**Interfaces:**
- Consumes: `BookService`, `LoanService`, `CheckInService`, `CurrentUser`.

- [ ] **Step 1: Wire CatalogPage**

In `BacaIn/Controls/CatalogPage.cs`:
- Hide `previewLabel`.
- Search textbox and availability filter (`All` / `Available only`).
- Load books into `catalogGrid` (Title, Author, Available copy count).
- `catalogGrid.CellContentClick` on `View Detail`:
  - Pass selected `bookId` to `bookDetailPage.LoadBook(bookId)`.
  - Fire `ViewDetailRequested` to navigate to `BookDetailPage`.

- [ ] **Step 2: Wire MyLoansPage**

In `BacaIn/Controls/MyLoansPage.cs`:
- Hide `previewLabel`.
- Load student's loans using `LoanService.GetLoansForStudentAsync(CurrentUser.Current.Id, statusFilter)`.
- Update summary counts: `Active: X`, `Overdue: Y`, `Returned: Z`.
- Filter dropdown changes (`All`, `Active`, `Overdue`, `Returned`) refresh the grid.

- [ ] **Step 3: Wire CheckInHistoryPage**

In `BacaIn/Controls/CheckInHistoryPage.cs`:
- Hide `previewLabel`.
- Date pickers for `From` and `To` (defaulting to current month).
- `applyButton.Click`: calls `CheckInService.GetHistoryAsync(CurrentUser.Current.Id, from, to)`.
- `resetButton.Click`: resets dates and reloads.
- Update `summaryCountLabel.Text = $"Total visits: {history.Count}"`.
- Populate `historyGrid` (Date, Time).

- [ ] **Step 4: Update StudentForm dynamic header**

In `StudentForm.cs`:
- Update `studentLabel` in child pages with `$"Student: {CurrentUser.Current.DisplayName}"`.

- [ ] **Step 5: Verify student portal**

Build and verify student catalog navigation, personal loans list, reservation management, and check-in history.

- [ ] **Step 6: Commit**

```bash
git add BacaIn/Controls/CatalogPage.cs BacaIn/Controls/BookDetailPage.cs BacaIn/Controls/MyLoansPage.cs BacaIn/Controls/CheckInHistoryPage.cs BacaIn/StudentForm.cs
git commit -m "feat(student): wire student portal catalog, loans, visits, and header context"
```

---

### Task 8: StudentsPage Management and ReportsPage with Native Print/PDF

**Files:**
- Create: `BacaIn/Controls/StudentEditDialog.cs`
- Create: `BacaIn/Controls/StudentEditDialog.Designer.cs`
- Modify: `BacaIn/Controls/StudentsPage.cs`
- Create: `BacaIn/Services/ReportService.cs`
- Modify: `BacaIn/Controls/ReportsPage.cs`

**Interfaces:**
- Consumes: `DatabaseContext`, `AuthService`, `ReportService`.
- Produces: `ReportService`, `StudentEditDialog`.

- [ ] **Step 1: Implement StudentsPage & StudentEditDialog**

- `StudentEditDialog`: dialog to create or edit student account (Username, Display Name, Password).
- In `StudentsPage.cs`:
  - Hide `previewLabel`.
  - Search textbox: filters student grid.
  - "Add Student" button: opens `StudentEditDialog(null)`, inserts student.
  - Grid "Edit" button: opens `StudentEditDialog(studentId)`.
  - Grid "Manage Loans & Returns" button: switches to `loansReturnsPage` with selected student.

- [ ] **Step 2: Implement ReportService**

In `BacaIn/Services/ReportService.cs`:
- `GetReportDataAsync(string reportType, DateTime fromDate, DateTime toDate)`:
  - Generates summary metrics and table rows for Loans & Returns, Inventory, Reservations, or Check-ins.
- Formats tabular report rows and totals.

- [ ] **Step 3: Wire ReportsPage with native PrintDocument**

In `BacaIn/Controls/ReportsPage.cs`:
- Hide `previewLabel`.
- Report type dropdown (`Loans & Returns`, `Inventory`, `Reservations`, `Check-ins`).
- Date pickers + `applyButton.Click`: load aggregated metrics into cards (`loansValueLabel`, `returnsValueLabel`, `overdueValueLabel`) and populate `reportGrid`.
- `printButton.Click`:
  - Configure `PrintDocument`.
  - Draw header: "BacaIn • School Library Report", Report Type, Date Range, Summary Counts, and Table grid with headers and rows.
  - Launch `PrintPreviewDialog` with Print action (supporting native "Microsoft Print to PDF" or physical printers).

- [ ] **Step 4: Verify students management and reports printing**

Build and verify student CRUD, report aggregation across date ranges, and print preview generation.

- [ ] **Step 5: Commit**

```bash
git add BacaIn/Controls/StudentEditDialog* BacaIn/Controls/StudentsPage.cs BacaIn/Services/ReportService.cs BacaIn/Controls/ReportsPage.cs
git commit -m "feat(reports): implement student management and ReportsPage with native PrintDocument"
```

---

### Task 9: System Integration Smoke Testing & Final Polish

**Files:**
- Modify: `BacaIn/Program.cs` (Ensure startup initializes `DatabaseContext.MigrateAndSeedAsync()`)
- Modify: Any files with residual preview text or compiler warnings

- [ ] **Step 1: Verify database connection on startup**

In `Program.cs`, before `Application.Run(new LoginForm())`:
```csharp
try
{
    DatabaseContext.Instance.MigrateAndSeedAsync().GetAwaiter().GetResult();
}
catch (Exception ex)
{
    MessageBox.Show("Failed to initialize database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
```

- [ ] **Step 2: Run complete project build**

Run `dotnet build BacaIn/BacaIn.csproj` with `--nologo`. Verify 0 errors and 0 warnings.

- [ ] **Step 3: End-to-end smoke verification script**

Run verification exercising:
1. DB schema and seed accounts.
2. Login validation for admin and student.
3. Kiosk check-in with daily deduplication.
4. Book search, ISBN lookup, and copy management.
5. Loan issue, overdue block, and return fine calculation.
6. Reservation queue and cancellation.
7. Report calculation and print document rendering.

- [ ] **Step 4: Commit**

```bash
git add .
git commit -m "chore: complete end-to-end system integration and verification"
```
