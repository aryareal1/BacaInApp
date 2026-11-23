using System.ComponentModel.DataAnnotations;
using BacaIn.Data;
using BacaIn.Models;
using Microsoft.EntityFrameworkCore;

namespace BacaIn.Controls;

public partial class ManageBooks : UserControl
{
    private List<BookRow> _books = new();

    public ManageBooks()
    {
        InitializeComponent();
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        btnSearch.Click += (_, _) => ApplyFilter();
        txtSearch.TextChanged += (_, _) => ApplyFilter();
        btnCreate.Click += (_, _) => CreateBook();
        btnEdit.Click += (_, _) => EditSelectedBook();
        btnDelete.Click += (_, _) => DeleteSelectedBook();
        dataGridView1.CellDoubleClick += (_, e) =>
        {
            if (e.RowIndex >= 0)
                EditSelectedBook();
        };
        dataGridView1.SelectionChanged += (_, _) => UpdateActionButtons();

        UpdateActionButtons();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (DesignMode)
            return;

        LoadBooks();
    }

    /// <summary>Reloads bibliographies and their active copy counts from the database.</summary>
    public void LoadBooks(int? selectBibliographyId = null)
    {
        try
        {
            using var db = new AppDbContext();
            _books = db.Bibliographies.AsNoTracking()
                .OrderBy(b => b.Title)
                .ThenBy(b => b.Id)
                .Select(b => new BookRow
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Isbn = b.Isbn,
                    Publisher = b.Publisher,
                    Year = b.PublisherYear,
                    Copies = b.Exemplars.Count,
                })
                .ToList();
        }
        catch (Exception ex)
        {
            _books = new();
            MessageBox.Show($"Could not load books:\n{ex.Message}", "BacaIn",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        ApplyFilter(selectBibliographyId);
    }

    private void ApplyFilter(int? selectBibliographyId = null)
    {
        var term = txtSearch.Text.Trim();
        var matches = term.Length == 0
            ? _books
            : _books.Where(b =>
                b.Title.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                b.Author.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                b.Publisher.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                (b.Isbn?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (b.Year?.ToString().Contains(term, StringComparison.OrdinalIgnoreCase) ?? false))
                .ToList();

        bookRowBindingSource.DataSource = matches;

        if (selectBibliographyId.HasValue)
            SelectRowById(selectBibliographyId.Value);

        UpdateActionButtons();
    }

    private void CreateBook()
    {
        using var dialog = new BookDialog();
        if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
            LoadBooks(dialog.SavedBibliographyId);
    }

    private void EditSelectedBook()
    {
        if (SelectedBookRow is not { } row)
            return;

        using var dialog = new BookDialog(row.Id);
        if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
            LoadBooks(dialog.SavedBibliographyId);
    }

    private void DeleteSelectedBook()
    {
        if (SelectedBookRow is not { } row)
            return;

        var confirm = MessageBox.Show(
            $"Are you sure you want to delete \"{row.Title}\"?",
            "Delete Book",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (confirm != DialogResult.Yes)
            return;

        try
        {
            using var db = new AppDbContext();
            var hasActiveLoans = db.Loans.AsNoTracking()
                .Any(l => l.Exemplar.BibliographyId == row.Id && l.Status == LoanStatus.Active);

            if (hasActiveLoans)
            {
                MessageBox.Show(
                    $"\"{row.Title}\" cannot be deleted because one or more copies are currently borrowed.",
                    "Delete Book",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var book = db.Bibliographies
                .Include(b => b.Exemplars)
                .FirstOrDefault(b => b.Id == row.Id);

            if (book is null)
            {
                LoadBooks();
                return;
            }

            var now = DateTime.UtcNow;
            book.DeletedAt = now;
            book.UpdatedAt = now;

            foreach (var exemplar in book.Exemplars)
            {
                exemplar.DeletedAt = now;
                exemplar.UpdatedAt = now;
            }

            db.SaveChanges();
            LoadBooks();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not delete book:\n{ex.Message}", "BacaIn",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private BookRow? SelectedBookRow
    {
        get
        {
            if (IsDisposed || Disposing || dataGridView1.IsDisposed || dataGridView1.Disposing)
                return null;

            if (dataGridView1.CurrentRow is not { Index: >= 0 } row ||
                row.Index >= dataGridView1.Rows.Count ||
                row.Index >= bookRowBindingSource.Count)
                return null;

            return row.DataBoundItem as BookRow;
        }
    }

    private void SelectRowById(int bibliographyId)
    {
        foreach (DataGridViewRow gridRow in dataGridView1.Rows)
        {
            if (gridRow.DataBoundItem is BookRow row && row.Id == bibliographyId)
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

        var hasSelection = SelectedBookRow is not null;
        btnEdit.Enabled = hasSelection;
        btnDelete.Enabled = hasSelection;
    }
}

public sealed class BookRow
{
    [Key] public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public string? Isbn { get; set; }
    public string Publisher { get; set; } = "";
    public int? Year { get; set; }
    public int Copies { get; set; }
}
