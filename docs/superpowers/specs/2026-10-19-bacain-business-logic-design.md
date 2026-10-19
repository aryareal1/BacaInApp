# BacaIn Business Logic & Database Implementation Spec

## 1. System Overview

BacaIn is a school-library Windows Forms application for students and librarians, backed by PostgreSQL (`postgres://postgres@localhost/bacain`) and accessed using `Npgsql`.
The user interface is built with Guna.UI2 controls and WinForms standard layouts. This specification defines the complete database schema, service layer, business workflows derived from `docs/plan.drawio`, and the integration and cleanup of all user-facing forms and pages.

---

## 2. Database Schema & Migration

### 2.1 Connection
- Connection string: `Host=localhost;Database=bacain;Username=postgres;Password=postgres;` (or `postgres://postgres@localhost/bacain` parsed via `NpgsqlConnectionStringBuilder`).
- Database migration and seeding executes automatically during application startup before the main UI displays.

### 2.2 Table Definitions

```sql
-- Users
CREATE TABLE IF NOT EXISTS users (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    username VARCHAR(255) NOT NULL UNIQUE,
    password_hash TEXT NOT NULL,
    display_name VARCHAR(255),
    role VARCHAR(50) NOT NULL, -- 'student', 'admin'
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ,
    deleted_at TIMESTAMPTZ
);

-- Bibliographies (Books)
CREATE TABLE IF NOT EXISTS bibliographies (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
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

-- Exemplars (Physical copies)
CREATE TABLE IF NOT EXISTS exemplars (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    bibliography_id UUID NOT NULL REFERENCES bibliographies(id) ON DELETE CASCADE,
    barcode VARCHAR(50) NOT NULL UNIQUE,
    status VARCHAR(50) NOT NULL DEFAULT 'AVAILABLE', -- 'AVAILABLE', 'BORROWED', 'DAMAGED', 'LOST'
    condition VARCHAR(50) NOT NULL DEFAULT 'GOOD', -- 'NEW', 'GOOD', 'FAIR', 'POOR'
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ,
    deleted_at TIMESTAMPTZ
);

-- Loans
CREATE TABLE IF NOT EXISTS loans (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    student_id UUID NOT NULL REFERENCES users(id),
    exemplar_id UUID NOT NULL REFERENCES exemplars(id),
    borrowed_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    due_at TIMESTAMPTZ NOT NULL,
    returned_at TIMESTAMPTZ,
    status VARCHAR(50) NOT NULL DEFAULT 'ACTIVATE', -- 'ACTIVATE', 'RETURNED'
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ
);

-- Reservations
CREATE TABLE IF NOT EXISTS reservations (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    student_id UUID NOT NULL REFERENCES users(id),
    bibliography_id UUID NOT NULL REFERENCES bibliographies(id),
    reserved_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    status VARCHAR(50) NOT NULL DEFAULT 'PENDING', -- 'PENDING', 'READY', 'FULFILLED', 'CANCELLED', 'EXPIRED'
    queue_position INT NOT NULL DEFAULT 1,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ
);

-- CheckIns (Daily library visits)
CREATE TABLE IF NOT EXISTS check_ins (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    student_id UUID NOT NULL REFERENCES users(id),
    checked_in_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
);
```

### 2.3 Seed Data
When tables are initialized and no users exist, automatically seed:
- **Admin account**: `admin` / `admin123` (display name: "Head Librarian", role: "admin")
- **Student account**: `aji` / `aji123` (display name: "Aji Pratama", role: "student")
- **Sample Bibliographies**:
  1. *Laskar Pelangi* (ISBN: 9789793062792, Andrea Hirata, Bentang Pustaka, 2005)
  2. *Bumi Manusia* (ISBN: 9789799731234, Pramoedya Ananta Toer, Hasta Mitra, 1980)
  3. *Negeri 5 Menara* (ISBN: 9789792248616, Ahmad Fuadi, Gramedia Pustaka Utama, 2009)
- **Sample Exemplars**:
  - *Laskar Pelangi*: BK-001 (AVAILABLE, GOOD), BK-002 (BORROWED, GOOD), BK-003 (AVAILABLE, NEW), BK-004 (DAMAGED, FAIR)
  - *Bumi Manusia*: BK-005 (AVAILABLE, GOOD), BK-006 (BORROWED, GOOD), BK-007 (BORROWED, FAIR), BK-008 (BORROWED, POOR)
  - *Negeri 5 Menara*: BK-009 (AVAILABLE, NEW), BK-010 (AVAILABLE, GOOD), BK-011 (AVAILABLE, GOOD), BK-012 (RETURNED past loan)
- **Sample Loans for Aji**:
  - Active loan: *Laskar Pelangi* (BK-002), borrowed 7 days ago, due in 7 days (Active).
  - Overdue loan: *Bumi Manusia* (BK-008), borrowed 20 days ago, due 6 days ago (Overdue).
  - Returned loan: *Negeri 5 Menara* (BK-012), borrowed 30 days ago, returned 16 days ago (Returned).
- **Sample Reservations**:
  - *Bumi Manusia* for Aji: Status `PENDING`, Queue 2.
- **Sample Check-ins for Aji**:
  - Visit records across the last two weeks matching wireframe dates.

---

## 3. Architecture & Service Layer

### 3.1 Project Dependencies
- Package: `Npgsql` (v9.x or matching .NET 10).
- Standard runtime libraries: `System.Security.Cryptography` (password hashing), `System.Net.Http` (OpenLibrary API), `System.Drawing.Printing` (native reports print/PDF).

### 3.2 Services & Responsibilities

1. **`DatabaseContext`**
   - Holds the configured connection string.
   - Manages connection lifecycle (`NpgsqlConnection`), transactions, parameter binding, and query execution.
   - Runs `MigrateAndSeedAsync()` on application boot.

2. **`AuthService` & `CurrentUser`**
   - Password hashing with salted SHA-256 / PBKDF2.
   - `LoginAsync(username, password)`: authenticates credentials against `users` table where `deleted_at IS NULL`.
   - `CurrentUser.Current`: tracks authenticated user ID, username, display name, and role.
   - `Logout()`: clears session.

3. **`BookService`**
   - `SearchBibliographiesAsync(keyword)`: filters title, author, isbn, publisher.
   - `GetBibliographyByIdAsync(id)`: retrieves book details with copy counts (total copies, available copies).
   - `CreateBibliographyAsync(book)`: inserts record.
   - `UpdateBibliographyAsync(book)`: updates record and sets `updated_at`.
   - `DeleteBibliographyAsync(id)`: soft-deletes (`deleted_at = NOW()`).
   - `LookupIsbnAsync(isbn)`: calls `https://openlibrary.org/api/books?bibkeys=ISBN:{isbn}&format=json&jscmd=data`. Parses Title, Authors, Publishers, Publish Date, and Cover URL. Gracefully falls back on failure.
   - `GetExemplarsAsync(bibliographyId)`: retrieves physical copies.
   - `AddExemplarAsync(bibliographyId, barcode, condition)`: adds copy with status `AVAILABLE`.
   - `UpdateExemplarAsync(exemplarId, status, condition)`: updates copy attributes.
   - `DeleteExemplarAsync(exemplarId)`: soft-deletes copy.

4. **`LoanService`**
   - `GetLoansByStudentIdAsync(studentId, filter)`: retrieves loans for student filtered by `All`, `Active`, `Overdue`, `Returned`.
   - `GetAllLoansAsync(searchKeyword)`: retrieves loans with student name, book title, and barcode.
   - `HasOverdueLoansAsync(studentId)`: returns `true` if any loan for student has `status = 'ACTIVATE'` and `due_at < NOW()`.
   - `CreateLoanAsync(studentId, exemplarId, durationDays = 14)`:
     - Validates student has no overdue loans.
     - Validates copy status is `AVAILABLE`.
     - Inserts loan (`borrowed_at = NOW()`, `due_at = NOW() + 14 days`, `status = 'ACTIVATE'`).
     - Updates copy status to `BORROWED`.
   - `ReturnLoanAsync(loanId)`:
     - Checks if overdue: `isLate = (NOW() > due_at)`.
     - Calculates fine: `fineAmount = overdueDays * 1000`.
     - Updates loan: `status = 'RETURNED'`, `returned_at = NOW()`.
     - Updates copy status to `AVAILABLE`.
     - Triggers reservation queue check on the book.

5. **`ReservationService`**
   - `GetStudentReservationsAsync(studentId, filter)`: lists student reservations with queue position.
   - `MakeReservationAsync(studentId, bibliographyId)`:
     - Checks if student already has an active reservation for this book.
     - Calculates queue position (`COUNT(active_reservations) + 1`).
     - Inserts reservation with status `PENDING`.
   - `CancelReservationAsync(reservationId)`:
     - Sets status to `CANCELLED`.
     - Re-indexes remaining queue positions for that book.
   - `CheckAndNotifyReservationsAsync(bibliographyId)`:
     - Called when a copy becomes available.
     - Promotes the #1 `PENDING` reservation to `READY`.

6. **`CheckInService`**
   - `CheckInAsync(username)`:
     - Finds active student by username. Throws if not found or if user is not a student.
     - Checks if check-in already recorded today (`checked_in_at::date = CURRENT_DATE`). Throws if already recorded.
     - Inserts `check_ins` record.
   - `GetCheckInHistoryAsync(studentId, fromDate, toDate)`:
     - Retrieves visit records within date range, ordered newest first.

7. **`ReportService`**
   - Aggregates report data for 4 categories:
     - `Loans & Returns`: Books, loans issued count, returns count in range. Summary: Total loans, total returns, current overdue.
     - `Inventory`: Books, total copies, available copies, borrowed copies, damaged/lost copies.
     - `Reservations`: Total reservations made, fulfilled count, cancelled count, currently pending.
     - `Check-ins`: Daily visitor count, unique student visitors, peak days.
   - Native `PrintDocument` renderer: renders formatted header, summary cards, and clean tabular rows with pagination support.

---

## 4. UI Design & Interaction

### 4.1 Login & Kiosk Entry
- `LoginForm`:
  - Username & Password inputs wired to `AuthService.LoginAsync`.
  - Enter key triggers Log In.
  - Error messages display cleanly without dialog popups.
  - Role dispatch: admin opens `AdminForm`; student opens `StudentForm`.
  - Hidden hotkey: `Ctrl+Shift+K` opens `CheckinForm`. No buttons or text hints on `LoginForm`.
- `CheckinForm`:
  - Standalone modal or kiosk form.
  - Can be launched directly via CLI flag `--kiosk` or `--checkin` in `Program.cs`.
  - Single input for username / barcode scan with Check In button and Enter key trigger.
  - Immediate clear visual feedback:
    - Success: Green card with Student Name, Time, and "Check-in successful".
    - Error: Red card with "Student not found" or "Already checked in today".
    - Resets input field after 3 seconds for next student.

### 4.2 Administration (`AdminForm`)
- UI Cleanup: Hide/remove all `previewLabel` ("Design preview — no records loaded...").
- Logout button: Prompts confirmation, resets session, closes `AdminForm`, displays `LoginForm`.
- **Books Page**:
  - Instant search filtering on title, author, publisher, ISBN.
  - "Add Book" button: Opens `BookEditDialog` in create mode.
  - "Modify" grid button: Opens `BookEditDialog` in edit mode.
  - "Delete" grid button: Prompts confirmation, soft-deletes book.
  - `BookEditDialog`:
    - Fields: ISBN, Title, Author, Publisher, Publication Year, Description, Cover URL.
    - "Lookup ISBN" button: fetches OpenLibrary data and auto-populates fields.
    - Exemplars grid: lists physical copies (Barcode, Condition, Status).
    - Add Exemplar button: adds barcode and condition.
    - Remove Exemplar button: removes copy.
- **Loans & Returns Page**:
  - Left panel: student search and selection list. Selecting student sets active lending context.
  - Right panel: active loans for selected student.
  - "Create Loan" button:
    - Verifies student has no overdue loans (displays warning if overdue).
    - Opens dialog to select available book exemplar.
    - Confirms and creates loan with 14-day due date.
  - "Return" grid button:
    - If loan is overdue, calculates fine (`Rp 1.000 / day`).
    - Displays confirmation dialog showing days overdue and fine amount.
    - On confirm: marks loan returned, marks copy available, refreshes grid.
- **Students Page**:
  - Search students.
  - "Add Student" button: dialog to create student username, display name, password.
  - "Edit" grid button: update display name or reset password.
  - "Manage Loans & Returns" grid button: navigates to Loans & Returns page with that student selected.
- **Reports Page**:
  - Report type dropdown: Loans & Returns, Inventory, Reservations, Check-ins.
  - From and To date pickers + Apply button.
  - Summary cards: dynamically update with calculated counts.
  - Preview DataGridView: displays categorized metrics.
  - "Print / Save PDF" button: launches native `PrintPreviewDialog` with Print option (including native "Microsoft Print to PDF").

### 4.3 Student Portal (`StudentForm`)
- UI Cleanup: Hide/remove all `previewLabel` controls.
- Top header: Dynamically displays active student display name ("Student: {displayName}").
- Logout button: Prompts confirmation, resets session, returns to `LoginForm`.
- **Catalog Page**:
  - Keyword search + Availability filter (All / Available).
  - Books table with Title, Author, Available copy count.
  - "View Detail" button: switches view to `BookDetailPage` for selected book.
- **Book Detail Page**:
  - Displays book metadata, cover image (or stylized fallback), and available copy ratio ("Available copies: X of Y").
  - "Reserve Book" button: calls `ReservationService.MakeReservationAsync` and shows feedback with queue position.
  - Library copies table: Barcode, Condition, Status.
  - "Back to Catalog" button: returns to catalog list.
- **My Loans Page**:
  - Filter: All, Active, Overdue, Returned.
  - Summary count badges: Active count, Overdue count, Returned count.
  - Loans table: Book / Copy, Borrowed Date, Due Date, Returned Date, Status badge.
- **My Reservations Page**:
  - Status filter.
  - Summary chips: Pending count, Ready count.
  - Table: Book Title, Reserved Date, Status, Queue Position, and Cancel action.
  - "Cancel" button: confirms and cancels pending reservation.
- **Check-in History Page**:
  - From & To date pickers + Apply & Reset buttons.
  - Summary visit count badge.
  - Visits table: Date, Check-in Time.

---

## 5. Verification Plan

1. **Database & Migration Smoke Test**:
   - Verify connection to `postgres://postgres@localhost/bacain`.
   - Verify all 6 tables and indexes are created with correct constraints.
   - Verify seed accounts `admin` and `aji` are inserted and hashed properly.
2. **Authentication & Routing Test**:
   - Log in with `admin`/`admin123` -> launches `AdminForm`.
   - Log in with `aji`/`aji123` -> launches `StudentForm`.
   - Invalid credentials -> clean error message.
   - Logout from both forms returns to `LoginForm`.
3. **Kiosk Check-in Test**:
   - Press `Ctrl+Shift+K` on `LoginForm` -> opens `CheckinForm`.
   - Launch application with `--checkin` argument -> boots `CheckinForm`.
   - Type username `aji` -> successful check-in with timestamp.
   - Type `aji` again immediately -> rejects duplicate check-in today.
   - Type non-existent username -> shows student not found error.
4. **Catalog & Book Management Test**:
   - In Admin, add new book, test ISBN lookup via OpenLibrary, add physical copies.
   - Edit book, modify copies, test delete.
   - In Student portal, verify book appears in catalog and detail page.
5. **Lending & Returns Workflow Test**:
   - Create loan for student. Check copy status becomes `BORROWED`.
   - Verify overdue prevention: attempting to create another loan when user has overdue loans shows error.
   - Return book: verify late calculation prompts fine dialog. On confirm, copy becomes `AVAILABLE`.
6. **Reservation Workflow Test**:
   - Student reserves unavailable book -> queue position assigned.
   - Cancel reservation -> status becomes `CANCELLED`.
7. **Reports & Printing Test**:
   - Change report types, apply date ranges, verify summary metrics.
   - Click Print / Save PDF -> verify native print preview displays populated report.
