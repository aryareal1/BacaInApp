using BacaIn.Data;
using BacaIn.Models;
using Microsoft.EntityFrameworkCore;

namespace BacaIn.Controls;

/// <summary>Modal dialog for selecting an exemplar and creating a 14-day loan for a student.</summary>
public partial class CreateLoanDialog : Form
{
    public const int LoanDurationDays = 14;

    private readonly int _studentId;
    private readonly string _studentName;
    private List<ExemplarOption> _exemplars = new();

    public CreateLoanDialog() : this(0, string.Empty)
    {
    }

    public CreateLoanDialog(int studentId, string studentName)
    {
        _studentId = studentId;
        _studentName = studentName;
        InitializeComponent();

        lblStudent.Text = studentName;
        lblDueInfo.Text = $"Due date: {DateTime.Now.AddDays(LoanDurationDays):yyyy-MM-dd} ({LoanDurationDays} days)";
    }

    private void CreateLoanDialog_Load(object? sender, EventArgs e)
    {
        if (DesignMode)
            return;

        LoadExemplars();
    }

    private void LoadExemplars()
    {
        try
        {
            using var db = new AppDbContext();
            _exemplars = db.Exemplars.AsNoTracking()
                .Where(ex => ex.Bibliography.DeletedAt == null)
                .OrderBy(ex => ex.Status != ExemplarStatus.Available)
                .ThenBy(ex => ex.Bibliography.Title)
                .ThenBy(ex => ex.Barcode)
                .Select(ex => new ExemplarOption
                {
                    Id = ex.Id,
                    Barcode = ex.Barcode,
                    Title = ex.Bibliography.Title,
                    Author = ex.Bibliography.Author,
                    Isbn = ex.Bibliography.Isbn ?? "",
                    Condition = ex.Condition.ToString(),
                    Status = ex.Status,
                    StatusText = ex.Status.ToString(),
                })
                .ToList();
        }
        catch (Exception ex)
        {
            _exemplars = new();
            MessageBox.Show($"Could not load exemplars:\n{ex.Message}", "BacaIn",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        ApplyFilter();
    }

    private void ApplyFilter()
    {
        var term = txtSearch.Text.Trim();
        var matches = term.Length == 0
            ? _exemplars
            : _exemplars.Where(ex =>
                ex.Barcode.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                ex.Title.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                ex.Author.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                ex.Isbn.Contains(term, StringComparison.OrdinalIgnoreCase))
                .ToList();

        dgvExemplars.DataSource = matches;
    }

    private void txtSearch_TextChanged(object? sender, EventArgs e) => ApplyFilter();

    private void btnSearch_Click(object? sender, EventArgs e) => ApplyFilter();

    private void dgvExemplars_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
            ConfirmCreateLoan();
    }

    private void btnCreate_Click(object? sender, EventArgs e) => ConfirmCreateLoan();

    private void ConfirmCreateLoan()
    {
        if (dgvExemplars.CurrentRow?.DataBoundItem is not ExemplarOption selected)
        {
            MessageBox.Show("Please select an exemplar.", "Create Loan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (selected.Status != ExemplarStatus.Available)
        {
            MessageBox.Show(
                $"Exemplar {selected.Barcode} is currently {selected.StatusText} and cannot be borrowed.",
                "Create Loan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        try
        {
            using var db = new AppDbContext();
            var now = DateTime.UtcNow;

            var hasOverdue = db.Loans.AsNoTracking()
                .Any(l => l.StudentId == _studentId && l.Status == LoanStatus.Active && l.DueAt < now);

            if (hasOverdue)
            {
                MessageBox.Show(
                    $"{_studentName} has overdue loan(s) that must be returned before borrowing another book.",
                    "Create Loan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var exemplar = db.Exemplars.FirstOrDefault(ex => ex.Id == selected.Id);
            if (exemplar is null || exemplar.Status != ExemplarStatus.Available)
            {
                MessageBox.Show(
                    $"Exemplar {selected.Barcode} is no longer available.",
                    "Create Loan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                LoadExemplars();
                return;
            }

            db.Loans.Add(new Loan
            {
                StudentId = _studentId,
                ExemplarId = exemplar.Id,
                BorrowedAt = now,
                DueAt = now.AddDays(LoanDurationDays),
                Status = LoanStatus.Active,
                CreatedAt = now,
            });

            exemplar.Status = ExemplarStatus.Borrowed;
            exemplar.UpdatedAt = now;

            db.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not create loan:\n{ex.Message}", "BacaIn",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private sealed class ExemplarOption
    {
        public int Id { get; set; }
        public string Barcode { get; set; } = "";
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string Isbn { get; set; } = "";
        public string Condition { get; set; } = "";
        public ExemplarStatus Status { get; set; }
        public string StatusText { get; set; } = "";
    }
}
