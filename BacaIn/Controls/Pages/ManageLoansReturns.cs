using System.Globalization;
using BacaIn.Data;
using BacaIn.Models;
using Microsoft.EntityFrameworkCore;

namespace BacaIn.Controls;

public partial class ManageLoansReturns : UserControl
{
    private const decimal FinePerDay = 1_000m;

    private List<LoanRow> _loans = new();
    private User? _currentUser;

    public ManageLoansReturns()
    {
        InitializeComponent();
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        selectUser.UserSelected += SelectUser_UserSelected;
        btnSearch.Click += (_, _) => ApplyFilter();
        txtSearch.TextChanged += (_, _) => ApplyFilter();
        btnCreate.Click += (_, _) => CreateLoan();
        btnEdit.Click += (_, _) => ReturnSelectedLoan();
        dataGridView1.SelectionChanged += (_, _) => UpdateActionButtons();

        UpdateActionButtons();
    }

    /// <summary>Shows the select user control and brings it to the front.</summary>
    public void ShowSelectUser()
    {
        selectUser.BringToFront();
    }

    /// <summary>Opens the loans &amp; returns view directly for the specified student.</summary>
    public void ShowLoansForUser(User user)
    {
        _currentUser = user;
        txtSearch.Clear();
        pnlMain.BringToFront();
        LoadLoans(user);
    }

    private void SelectUser_UserSelected(object? sender, EventArgs e)
    {
        if (selectUser.SelectedUser is not { } user)
            return;

        _currentUser = user;
        txtSearch.Clear();
        pnlMain.BringToFront();
        LoadLoans(user);
    }

    private void LoadLoans(User user)
    {
        try
        {
            using var db = new AppDbContext();
            var now = DateTime.UtcNow;
            var rows = db.Loans.AsNoTracking()
                .Where(l => l.StudentId == user.Id)
                .OrderBy(l => l.Status)
                .ThenByDescending(l => l.BorrowedAt)
                .Select(l => new
                {
                    l.Id,
                    l.Exemplar.Barcode,
                    l.Exemplar.Bibliography.Title,
                    l.Exemplar.Bibliography.Author,
                    l.BorrowedAt,
                    l.DueAt,
                    l.ReturnedAt,
                    l.Status,
                })
                .ToList();

            _loans = rows.Select(l =>
            {
                var isActive = l.Status == LoanStatus.Active;
                var isOverdue = isActive && l.DueAt < now;
                return new LoanRow
                {
                    Id = l.Id,
                    Barcode = l.Barcode,
                    Title = l.Title,
                    Author = l.Author,
                    Borrowed = l.BorrowedAt.ToLocalTime().ToString("yyyy-MM-dd"),
                    Due = l.DueAt.ToLocalTime().ToString("yyyy-MM-dd"),
                    Returned = l.ReturnedAt?.ToLocalTime().ToString("yyyy-MM-dd") ?? "-",
                    Status = isOverdue ? "Overdue" : l.Status.ToString(),
                    IsActive = isActive,
                };
            }).ToList();
        }
        catch (Exception ex)
        {
            _loans = new();
            MessageBox.Show($"Could not load loans:\n{ex.Message}", "BacaIn",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        ApplyFilter();
    }

    private void ApplyFilter()
    {
        var term = txtSearch.Text.Trim();
        var matches = term.Length == 0
            ? _loans
            : _loans.Where(l =>
                l.Title.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                l.Author.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                l.Barcode.Contains(term, StringComparison.OrdinalIgnoreCase)).ToList();

        dataGridView1.DataSource = matches;
        if (dataGridView1.Columns["Id"] is { } idCol)
            idCol.Visible = false;
        if (dataGridView1.Columns["IsActive"] is { } activeCol)
            activeCol.Visible = false;

        UpdateActionButtons();
    }

    private void CreateLoan()
    {
        if (_currentUser is not { } user)
            return;

        try
        {
            using var db = new AppDbContext();
            var now = DateTime.UtcNow;
            var hasOverdue = db.Loans.AsNoTracking()
                .Any(l => l.StudentId == user.Id && l.Status == LoanStatus.Active && l.DueAt < now);

            if (hasOverdue)
            {
                MessageBox.Show(
                    $"{user.DisplayName ?? user.Username} has overdue loan(s). Please return overdue books before creating a new loan.",
                    "Create Loan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not verify student loans:\n{ex.Message}", "BacaIn",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        using var dialog = new CreateLoanDialog(user.Id, user.DisplayName ?? user.Username);
        if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
            LoadLoans(user);
    }

    private void ReturnSelectedLoan()
    {
        if (_currentUser is not { } user || SelectedLoanRow is not { IsActive: true } row)
            return;

        try
        {
            using var db = new AppDbContext();
            var loan = db.Loans
                .Include(l => l.Exemplar)
                .FirstOrDefault(l => l.Id == row.Id);

            if (loan is null || loan.Status != LoanStatus.Active)
            {
                MessageBox.Show("This loan is no longer active.", "Return Book",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLoans(user);
                return;
            }

            var now = DateTime.UtcNow;
            string prompt;
            if (now > loan.DueAt)
            {
                var lateDays = Math.Max(1, (int)Math.Ceiling((now - loan.DueAt).TotalDays));
                var fine = lateDays * FinePerDay;
                var formattedFine = fine.ToString("N0", CultureInfo.GetCultureInfo("id-ID"));
                prompt =
                    $"Book: {row.Title} ({row.Barcode})\n" +
                    $"Due Date: {loan.DueAt.ToLocalTime():yyyy-MM-dd}\n" +
                    $"Overdue: {lateDays} day(s)\n" +
                    $"Fine: Rp {formattedFine}\n\n" +
                    "Confirm book return?";
            }
            else
            {
                prompt = $"Confirm return of \"{row.Title}\" ({row.Barcode})?";
            }

            var confirm = MessageBox.Show(
                prompt,
                "Confirm Return",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            loan.Status = LoanStatus.Returned;
            loan.ReturnedAt = now;
            loan.UpdatedAt = now;

            loan.Exemplar.Status = ExemplarStatus.Available;
            loan.Exemplar.UpdatedAt = now;

            db.SaveChanges();
            LoadLoans(user);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not complete return:\n{ex.Message}", "BacaIn",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private LoanRow? SelectedLoanRow
    {
        get
        {
            if (IsDisposed || Disposing || dataGridView1.IsDisposed || dataGridView1.Disposing)
                return null;

            if (dataGridView1.CurrentRow is not { Index: >= 0 } row || row.Index >= dataGridView1.Rows.Count)
                return null;

            return row.DataBoundItem as LoanRow;
        }
    }

    private void UpdateActionButtons()
    {
        if (IsDisposed || Disposing)
            return;

        btnCreate.Enabled = _currentUser is not null;
        btnEdit.Enabled = SelectedLoanRow is { IsActive: true };
    }

    private sealed class LoanRow
    {
        public int Id { get; set; }
        public string Barcode { get; set; } = "";
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string Borrowed { get; set; } = "";
        public string Due { get; set; } = "";
        public string Returned { get; set; } = "";
        public string Status { get; set; } = "";
        public bool IsActive { get; set; }
    }
}
