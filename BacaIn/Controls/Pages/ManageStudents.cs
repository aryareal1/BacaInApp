using BacaIn.Data;
using BacaIn.Models;
using Microsoft.EntityFrameworkCore;

namespace BacaIn.Controls;

public partial class ManageStudents : UserControl
{
    private List<StudentRow> _students = new();

    /// <summary>Raised when the admin clicks "Loans &amp; Returns" for a selected student.</summary>
    public event EventHandler<User>? OpenLoansRequested;

    public ManageStudents()
    {
        InitializeComponent();

        btnSearch.Click += (_, _) => ApplyFilter();
        txtSearch.TextChanged += (_, _) => ApplyFilter();
        btnCreate.Click += (_, _) => CreateStudent();
        btnEdit.Click += (_, _) => EditSelectedStudent();
        btnDelete.Click += (_, _) => DeleteSelectedStudent();
        btnLoans.Click += (_, _) => OpenLoansForSelectedStudent();
        dataGridView1.CellDoubleClick += (_, e) =>
        {
            if (e.RowIndex >= 0)
                EditSelectedStudent();
        };
        dataGridView1.SelectionChanged += (_, _) => UpdateActionButtons();

        UpdateActionButtons();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (DesignMode)
            return;

        LoadStudents();
    }

    /// <summary>Reloads student accounts and summary counts from the database.</summary>
    public void LoadStudents(int? selectStudentId = null)
    {
        try
        {
            using var db = new AppDbContext();
            var now = DateTime.UtcNow;

            _students = db.Users.AsNoTracking()
                .Where(u => u.Role == UserRole.Student)
                .OrderBy(u => u.DisplayName ?? u.Username)
                .ThenBy(u => u.Id)
                .Select(u => new StudentRow
                {
                    Id = u.Id,
                    Username = u.Username,
                    DisplayName = u.DisplayName ?? "-",
                    ActiveLoans = u.Loans.Count(l => l.Status == LoanStatus.Active),
                    OverdueLoans = u.Loans.Count(l => l.Status == LoanStatus.Active && l.DueAt < now),
                    CheckIns = u.CheckIns.Count,
                })
                .ToList();
        }
        catch (Exception ex)
        {
            _students = new();
            MessageBox.Show($"Could not load students:\n{ex.Message}", "BacaIn",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        ApplyFilter(selectStudentId);
    }

    private void ApplyFilter(int? selectStudentId = null)
    {
        var term = txtSearch.Text.Trim();
        var matches = term.Length == 0
            ? _students
            : _students.Where(s =>
                s.Username.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                s.DisplayName.Contains(term, StringComparison.OrdinalIgnoreCase))
                .ToList();

        dataGridView1.DataSource = matches;

        if (selectStudentId.HasValue)
            SelectRowById(selectStudentId.Value);

        UpdateActionButtons();
    }

    private void CreateStudent()
    {
        using var dialog = new StudentDialog();
        if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
            LoadStudents(dialog.SavedStudentId);
    }

    private void EditSelectedStudent()
    {
        if (SelectedStudentRow is not { } row)
            return;

        using var dialog = new StudentDialog(row.Id);
        if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
            LoadStudents(dialog.SavedStudentId);
    }

    private void DeleteSelectedStudent()
    {
        if (SelectedStudentRow is not { } row)
            return;

        var confirm = MessageBox.Show(
            $"Are you sure you want to delete student \"{row.DisplayName}\" (@{row.Username})?",
            "Delete Student",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (confirm != DialogResult.Yes)
            return;

        try
        {
            using var db = new AppDbContext();
            var hasActiveLoans = db.Loans.AsNoTracking()
                .Any(l => l.StudentId == row.Id && l.Status == LoanStatus.Active);

            if (hasActiveLoans)
            {
                MessageBox.Show(
                    $"\"{row.DisplayName}\" cannot be deleted while they have active loans.",
                    "Delete Student",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var student = db.Users.FirstOrDefault(u => u.Id == row.Id && u.Role == UserRole.Student);
            if (student is null)
            {
                LoadStudents();
                return;
            }

            db.Users.Remove(student);
            db.SaveChanges();
            LoadStudents();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not delete student:\n{ex.Message}", "BacaIn",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void OpenLoansForSelectedStudent()
    {
        if (SelectedStudentRow is not { } row)
            return;

        try
        {
            using var db = new AppDbContext();
            var user = db.Users.AsNoTracking().FirstOrDefault(u => u.Id == row.Id);
            if (user is not null)
                OpenLoansRequested?.Invoke(this, user);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not open student loans:\n{ex.Message}", "BacaIn",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private StudentRow? SelectedStudentRow
    {
        get
        {
            if (IsDisposed || Disposing || dataGridView1.IsDisposed || dataGridView1.Disposing)
                return null;

            if (dataGridView1.CurrentRow is not { Index: >= 0 } row || row.Index >= dataGridView1.Rows.Count)
                return null;

            return row.DataBoundItem as StudentRow;
        }
    }

    private void SelectRowById(int studentId)
    {
        foreach (DataGridViewRow gridRow in dataGridView1.Rows)
        {
            if (gridRow.DataBoundItem is StudentRow row && row.Id == studentId)
            {
                gridRow.Selected = true;
                dataGridView1.CurrentCell = gridRow.Cells[1]; // Column 0 (Id) is hidden
                break;
            }
        }
    }

    private void UpdateActionButtons()
    {
        if (IsDisposed || Disposing)
            return;

        var hasSelection = SelectedStudentRow is not null;
        btnEdit.Enabled = hasSelection;
        btnDelete.Enabled = hasSelection;
        btnLoans.Enabled = hasSelection;
    }

    private sealed class StudentRow
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string DisplayName { get; set; } = "";
        public int ActiveLoans { get; set; }
        public int OverdueLoans { get; set; }
        public int CheckIns { get; set; }
    }
}
