using BacaIn.Data;
using BacaIn.Models;
using Microsoft.EntityFrameworkCore;

namespace BacaIn.Controls;

public partial class ManageLoansReturns : UserControl
{
    private List<LoanRow> _loans = new();

    public ManageLoansReturns()
    {
        InitializeComponent();
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        selectUser.UserSelected += SelectUser_UserSelected;
        btnSearch.Click += (_, _) => ApplyFilter();
        txtSearch.TextChanged += (_, _) => ApplyFilter();
    }

    /// <summary>Shows the select user control and brings it to the front.</summary>
    public void ShowSelectUser()
    {
        selectUser.BringToFront();
    }

    private void SelectUser_UserSelected(object? sender, EventArgs e)
    {
        if (selectUser.SelectedUser is not { } user)
            return;

        txtSearch.Clear();
        pnlMain.BringToFront();
        LoadLoans(user);
    }

    private void LoadLoans(User user)
    {
        try
        {
            using var db = new AppDbContext();
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

            _loans = rows.Select(l => new LoanRow
            {
                Id = l.Id,
                Barcode = l.Barcode,
                Title = l.Title,
                Author = l.Author,
                Borrowed = l.BorrowedAt.ToLocalTime().ToString("yyyy-MM-dd"),
                Due = l.DueAt.ToLocalTime().ToString("yyyy-MM-dd"),
                Returned = l.ReturnedAt?.ToLocalTime().ToString("yyyy-MM-dd") ?? "-",
                Status = l.Status.ToString(),
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
    }
}
