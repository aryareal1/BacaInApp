using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using BacaIn.Data;
using BacaIn.Models;
using Microsoft.EntityFrameworkCore;

namespace BacaIn.Controls;

/// <summary>Unified modal dialog for adding and modifying a <see cref="Bibliography"/> and its <see cref="Exemplar"/> copies.</summary>
public partial class BookDialog : Form
{
    private static readonly HttpClient Http = new() { Timeout = TimeSpan.FromSeconds(8) };

    private readonly int? _bibliographyId;
    private readonly List<ExemplarEditRow> _exemplars = new();
    private readonly HashSet<int> _removedExemplarIds = new();
    private readonly HashSet<int> _activeLoanExemplarIds = new();

    private int _nextBarcodeNumber = 1;

    /// <summary>Gets the ID of the created or edited bibliography after a successful save.</summary>
    public int SavedBibliographyId { get; private set; }

    public BookDialog() : this(null)
    {
    }

    public BookDialog(int? bibliographyId)
    {
        _bibliographyId = bibliographyId;
        InitializeComponent();

        Text = bibliographyId.HasValue ? "Modify Book" : "Add Book";
        colCondition.DataSource = Enum.GetValues<ExemplarCondition>();
        colStatus.DataSource = Enum.GetValues<ExemplarStatus>();
    }

    private void BookDialog_Load(object? sender, EventArgs e)
    {
        if (DesignMode)
            return;

        try
        {
            using var db = new AppDbContext();
            _nextBarcodeNumber = ComputeNextBarcodeNumber(db);

            if (!_bibliographyId.HasValue)
            {
                _exemplars.Add(new ExemplarEditRow
                {
                    Id = 0,
                    Barcode = $"BC-{_nextBarcodeNumber++:0000}",
                    Condition = ExemplarCondition.New,
                    Status = ExemplarStatus.Available,
                });
                RefreshExemplarsGrid();
                return;
            }

            var book = db.Bibliographies.AsNoTracking()
                .Include(b => b.Exemplars)
                .FirstOrDefault(b => b.Id == _bibliographyId.Value);

            if (book is null)
            {
                MessageBox.Show("The selected book could not be found.", "BacaIn",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            txtIsbn.Text = book.Isbn ?? string.Empty;
            txtTitle.Text = book.Title;
            txtAuthor.Text = book.Author;
            txtPublisher.Text = book.Publisher;
            txtYear.Text = book.PublisherYear?.ToString() ?? string.Empty;
            txtDescription.Text = book.Description ?? string.Empty;
            txtCoverUrl.Text = book.CoverUrl ?? string.Empty;

            var exemplarIds = book.Exemplars.Select(ex => ex.Id).ToList();
            if (exemplarIds.Count > 0)
            {
                var borrowedIds = db.Loans.AsNoTracking()
                    .Where(l => exemplarIds.Contains(l.ExemplarId) && l.Status == LoanStatus.Active)
                    .Select(l => l.ExemplarId)
                    .ToList();
                foreach (var id in borrowedIds)
                    _activeLoanExemplarIds.Add(id);
            }

            foreach (var ex in book.Exemplars.OrderBy(ex => ex.Barcode))
            {
                _exemplars.Add(new ExemplarEditRow
                {
                    Id = ex.Id,
                    Barcode = ex.Barcode,
                    Condition = ex.Condition,
                    Status = ex.Status,
                    HasActiveLoan = _activeLoanExemplarIds.Contains(ex.Id),
                });
            }

            RefreshExemplarsGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not load book details:\n{ex.Message}", "BacaIn",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

    private void dgvExemplars_CellBeginEdit(object? sender, DataGridViewCellCancelEventArgs e)
    {
        if (e.RowIndex >= 0 && e.RowIndex < _exemplars.Count && _exemplars[e.RowIndex].HasActiveLoan)
        {
            var colProp = dgvExemplars.Columns[e.ColumnIndex].DataPropertyName;
            if (colProp == nameof(ExemplarEditRow.Status))
                e.Cancel = true;
        }
    }

    private async void btnLookup_Click(object? sender, EventArgs e)
    {
        var raw = txtIsbn.Text.Trim();
        var isbn = Regex.Replace(raw, @"[\s-]", "");
        if (isbn.Length is not (10 or 13))
        {
            SetIsbnStatus("Enter a valid 10- or 13-character ISBN.", isError: true);
            txtIsbn.Focus();
            return;
        }

        txtIsbn.Text = isbn;
        btnLookup.Enabled = false;
        SetIsbnStatus("Looking up ISBN...", isError: false);

        try
        {
            var result = await LookupFromOpenLibraryAsync(isbn) ?? await LookupFromGoogleBooksAsync(isbn);
            if (IsDisposed)
                return;

            if (result is null)
            {
                SetIsbnStatus("No book metadata found for this ISBN.", isError: true);
                return;
            }

            if (!string.IsNullOrWhiteSpace(result.Title))
                txtTitle.Text = result.Title;
            if (!string.IsNullOrWhiteSpace(result.Author))
                txtAuthor.Text = result.Author;
            if (!string.IsNullOrWhiteSpace(result.Publisher))
                txtPublisher.Text = result.Publisher;
            if (result.Year.HasValue)
                txtYear.Text = result.Year.Value.ToString();
            if (!string.IsNullOrWhiteSpace(result.Description))
                txtDescription.Text = result.Description;
            if (!string.IsNullOrWhiteSpace(result.CoverUrl))
                txtCoverUrl.Text = result.CoverUrl;

            SetIsbnStatus($"Loaded from {result.Source}.", isError: false);
        }
        catch (Exception ex)
        {
            if (!IsDisposed)
                SetIsbnStatus($"Lookup failed: {ex.Message}", isError: true);
        }
        finally
        {
            if (!IsDisposed)
                btnLookup.Enabled = true;
        }
    }

    private void SetIsbnStatus(string message, bool isError)
    {
        lblIsbnStatus.Text = message;
        lblIsbnStatus.ForeColor = isError ? Color.Firebrick : SystemColors.GrayText;
    }

    private static async Task<IsbnMetadata?> LookupFromOpenLibraryAsync(string isbn)
    {
        var url = $"https://openlibrary.org/api/books?bibkeys=ISBN:{Uri.EscapeDataString(isbn)}&format=json&jscmd=data";
        using var response = await Http.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            return null;

        await using var stream = await response.Content.ReadAsStreamAsync();
        using var doc = await JsonDocument.ParseAsync(stream);

        if (!doc.RootElement.TryGetProperty($"ISBN:{isbn}", out var book))
            return null;

        var title = book.TryGetProperty("title", out var t) ? t.GetString() : null;
        var author = ReadJoinedNames(book, "authors");
        var publisher = ReadJoinedNames(book, "publishers");
        var year = book.TryGetProperty("publish_date", out var pd) ? ExtractYear(pd.GetString()) : null;
        var cover = book.TryGetProperty("cover", out var cov)
            ? (cov.TryGetProperty("large", out var l) ? l.GetString()
               : cov.TryGetProperty("medium", out var m) ? m.GetString()
               : cov.TryGetProperty("small", out var s) ? s.GetString() : null)
            : null;
        var description = book.TryGetProperty("notes", out var notes) ? notes.GetString() : null;

        if (string.IsNullOrWhiteSpace(title) && string.IsNullOrWhiteSpace(author))
            return null;

        return new IsbnMetadata("Open Library", title, author, publisher, year, description, cover);
    }

    private static async Task<IsbnMetadata?> LookupFromGoogleBooksAsync(string isbn)
    {
        var url = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{Uri.EscapeDataString(isbn)}";
        using var response = await Http.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            return null;

        await using var stream = await response.Content.ReadAsStreamAsync();
        using var doc = await JsonDocument.ParseAsync(stream);

        if (!doc.RootElement.TryGetProperty("items", out var items) || items.GetArrayLength() == 0)
            return null;

        if (!items[0].TryGetProperty("volumeInfo", out var info))
            return null;

        var title = info.TryGetProperty("title", out var t) ? t.GetString() : null;
        string? author = null;
        if (info.TryGetProperty("authors", out var authors) && authors.ValueKind == JsonValueKind.Array)
            author = string.Join(", ", authors.EnumerateArray().Select(a => a.GetString()).Where(s => !string.IsNullOrWhiteSpace(s)));

        var publisher = info.TryGetProperty("publisher", out var p) ? p.GetString() : null;
        var year = info.TryGetProperty("publishedDate", out var pd) ? ExtractYear(pd.GetString()) : null;
        var description = info.TryGetProperty("description", out var desc) ? desc.GetString() : null;
        var cover = info.TryGetProperty("imageLinks", out var imgs)
            ? (imgs.TryGetProperty("thumbnail", out var th) ? th.GetString()
               : imgs.TryGetProperty("smallThumbnail", out var sth) ? sth.GetString() : null)
            : null;

        if (string.IsNullOrWhiteSpace(title) && string.IsNullOrWhiteSpace(author))
            return null;

        return new IsbnMetadata("Google Books", title, author, publisher, year, description, cover);
    }

    private static string? ReadJoinedNames(JsonElement element, string propertyName)
    {
        if (!element.TryGetProperty(propertyName, out var arr) || arr.ValueKind != JsonValueKind.Array)
            return null;

        var names = arr.EnumerateArray()
            .Select(item => item.TryGetProperty("name", out var n) ? n.GetString() : null)
            .Where(s => !string.IsNullOrWhiteSpace(s));
        var joined = string.Join(", ", names);
        return joined.Length > 0 ? joined : null;
    }

    private static int? ExtractYear(string? text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return null;

        var match = Regex.Match(text, @"\b(1\d{3}|20\d{2})\b");
        return match.Success && int.TryParse(match.Value, out var year) ? year : null;
    }

    private void btnSelectCover_Click(object? sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog
        {
            Title = "Select Book Cover",
            Filter = "Image Files|*.jpg;*.jpeg;*.png;*.webp;*.bmp|All Files|*.*",
        };
        if (ofd.ShowDialog(this) == DialogResult.OK)
            txtCoverUrl.Text = ofd.FileName;
    }

    private void btnAddCopy_Click(object? sender, EventArgs e)
    {
        _exemplars.Add(new ExemplarEditRow
        {
            Id = 0,
            Barcode = $"BC-{_nextBarcodeNumber++:0000}",
            Condition = ExemplarCondition.New,
            Status = ExemplarStatus.Available,
        });
        RefreshExemplarsGrid();
    }

    private void btnRemoveCopy_Click(object? sender, EventArgs e)
    {
        if (dgvExemplars.CurrentRow?.DataBoundItem is not ExemplarEditRow row)
            return;

        if (row.HasActiveLoan || row.Status == ExemplarStatus.Borrowed)
        {
            MessageBox.Show($"Copy {row.Barcode} is currently borrowed and cannot be removed.", "BacaIn",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (row.Id > 0)
            _removedExemplarIds.Add(row.Id);

        _exemplars.Remove(row);
        RefreshExemplarsGrid();
    }

    private void RefreshExemplarsGrid()
    {
        dgvExemplars.DataSource = null;
        dgvExemplars.DataSource = _exemplars;
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        dgvExemplars.EndEdit();

        var isbn = Regex.Replace(txtIsbn.Text.Trim(), @"[\s-]", "");
        var title = txtTitle.Text.Trim();
        var author = txtAuthor.Text.Trim();
        var publisher = txtPublisher.Text.Trim();
        var yearText = txtYear.Text.Trim();
        var description = txtDescription.Text.Trim();
        var coverUrl = txtCoverUrl.Text.Trim();

        if (isbn.Length > 13)
        {
            MessageBox.Show("ISBN cannot exceed 13 characters.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtIsbn.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(title))
        {
            MessageBox.Show("Title is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTitle.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(author))
        {
            MessageBox.Show("Author is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtAuthor.Focus();
            return;
        }

        int? publisherYear = null;
        if (yearText.Length > 0)
        {
            if (!int.TryParse(yearText, out var parsedYear) || parsedYear < 1000 || parsedYear > DateTime.Now.Year + 1)
            {
                MessageBox.Show($"Publication Year must be between 1000 and {DateTime.Now.Year + 1}.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYear.Focus();
                return;
            }
            publisherYear = parsedYear;
        }

        var seenBarcodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var row in _exemplars)
        {
            row.Barcode = row.Barcode.Trim();
            if (string.IsNullOrWhiteSpace(row.Barcode))
            {
                MessageBox.Show("Every exemplar must have a barcode.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!seenBarcodes.Add(row.Barcode))
            {
                MessageBox.Show($"Duplicate barcode \"{row.Barcode}\" in exemplars list.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        try
        {
            using var db = new AppDbContext();
            var now = DateTime.UtcNow;

            if (_bibliographyId.HasValue)
            {
                var book = db.Bibliographies
                    .Include(b => b.Exemplars)
                    .FirstOrDefault(b => b.Id == _bibliographyId.Value);

                if (book is null)
                {
                    MessageBox.Show("The book no longer exists.", "BacaIn",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                book.Isbn = isbn.Length > 0 ? isbn : null;
                book.Title = title;
                book.Author = author;
                book.Publisher = publisher;
                book.PublisherYear = publisherYear;
                book.Description = description.Length > 0 ? description : null;
                book.CoverUrl = coverUrl.Length > 0 ? coverUrl : null;
                book.UpdatedAt = now;

                foreach (var removedId in _removedExemplarIds)
                {
                    var ex = book.Exemplars.FirstOrDefault(x => x.Id == removedId);
                    if (ex is not null)
                    {
                        ex.DeletedAt = now;
                        ex.UpdatedAt = now;
                    }
                }

                foreach (var row in _exemplars)
                {
                    if (row.Id == 0)
                    {
                        book.Exemplars.Add(new Exemplar
                        {
                            Barcode = row.Barcode,
                            Condition = row.Condition,
                            Status = row.Status,
                            CreatedAt = now,
                        });
                    }
                    else
                    {
                        var ex = book.Exemplars.FirstOrDefault(x => x.Id == row.Id);
                        if (ex is not null && (ex.Barcode != row.Barcode || ex.Condition != row.Condition || ex.Status != row.Status))
                        {
                            ex.Barcode = row.Barcode;
                            ex.Condition = row.Condition;
                            ex.Status = row.Status;
                            ex.UpdatedAt = now;
                        }
                    }
                }

                db.SaveChanges();
                SavedBibliographyId = book.Id;
            }
            else
            {
                var book = new Bibliography
                {
                    Isbn = isbn.Length > 0 ? isbn : null,
                    Title = title,
                    Author = author,
                    Publisher = publisher,
                    PublisherYear = publisherYear,
                    Description = description.Length > 0 ? description : null,
                    CoverUrl = coverUrl.Length > 0 ? coverUrl : null,
                    CreatedAt = now,
                };

                foreach (var row in _exemplars)
                {
                    book.Exemplars.Add(new Exemplar
                    {
                        Barcode = row.Barcode,
                        Condition = row.Condition,
                        Status = row.Status,
                        CreatedAt = now,
                    });
                }

                db.Bibliographies.Add(book);
                db.SaveChanges();
                SavedBibliographyId = book.Id;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not save book:\n{ex.Message}", "BacaIn",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static int ComputeNextBarcodeNumber(AppDbContext db)
    {
        var barcodes = db.Exemplars.IgnoreQueryFilters()
            .Select(e => e.Barcode)
            .ToList();

        var max = 0;
        foreach (var barcode in barcodes)
        {
            if (barcode.StartsWith("BC-", StringComparison.OrdinalIgnoreCase) &&
                int.TryParse(barcode.AsSpan(3), out var num) &&
                num > max)
            {
                max = num;
            }
        }
        return max + 1;
    }

    private sealed record IsbnMetadata(
        string Source,
        string? Title,
        string? Author,
        string? Publisher,
        int? Year,
        string? Description,
        string? CoverUrl);

    private sealed class ExemplarEditRow
    {
        public int Id { get; set; }
        public string Barcode { get; set; } = "";
        public ExemplarCondition Condition { get; set; }
        public ExemplarStatus Status { get; set; }
        public bool HasActiveLoan { get; set; }
    }
}
