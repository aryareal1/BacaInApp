using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BacaIn.Models;
using BacaIn.Services;

namespace BacaIn.Controls
{
    public partial class BookEditDialog : Form
    {
        private readonly Guid? _bookId;
        private Bibliography? _book;
        private readonly List<Exemplar> _exemplars = new List<Exemplar>();
        private readonly List<Guid> _deletedExemplarIds = new List<Guid>();

        public BookEditDialog(Guid? bookId = null)
        {
            InitializeComponent();
            _bookId = bookId;

            lookupButton.Click += async (s, e) => await HandleIsbnLookupAsync();
            addCopyButton.Click += HandleAddCopy;
            copiesGrid.CellContentClick += HandleCopyGridClick;
            saveButton.Click += async (s, e) => await HandleSaveAsync();
            cancelButton.Click += (s, e) => DialogResult = DialogResult.Cancel;

            Load += async (s, e) => await InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            if (_bookId.HasValue)
            {
                Text = "Modify Book";
                saveButton.Text = "Save Changes";
                _book = await BookService.Instance.GetBibliographyByIdAsync(_bookId.Value);
                if (_book != null)
                {
                    isbnTextBox.Text = _book.Isbn ?? "";
                    titleTextBox.Text = _book.Title;
                    authorTextBox.Text = _book.Author;
                    publisherTextBox.Text = _book.Publisher;
                    yearTextBox.Text = _book.PublisherYear?.ToString() ?? "";
                    descTextBox.Text = _book.Description ?? "";
                    coverTextBox.Text = _book.CoverUrl ?? "";

                    var copies = await BookService.Instance.GetExemplarsAsync(_book.Id);
                    _exemplars.Clear();
                    _exemplars.AddRange(copies);
                    RefreshCopiesGrid();
                }
            }
            else
            {
                Text = "Add Book";
                saveButton.Text = "Save Book";
                barcodeTextBox.Text = "BK-" + new Random().Next(100, 999);
            }
        }

        private async Task HandleIsbnLookupAsync()
        {
            var isbn = isbnTextBox.Text.Trim();
            if (string.IsNullOrEmpty(isbn))
            {
                ShowStatus("Please enter an ISBN first.", isError: true);
                return;
            }

            lookupButton.Enabled = false;
            lookupButton.Text = "...";

            try
            {
                var book = await BookService.Instance.LookupIsbnAsync(isbn);
                if (book != null)
                {
                    if (!string.IsNullOrEmpty(book.Title)) titleTextBox.Text = book.Title;
                    if (!string.IsNullOrEmpty(book.Author)) authorTextBox.Text = book.Author;
                    if (!string.IsNullOrEmpty(book.Publisher)) publisherTextBox.Text = book.Publisher;
                    if (book.PublisherYear.HasValue) yearTextBox.Text = book.PublisherYear.Value.ToString();
                    if (!string.IsNullOrEmpty(book.CoverUrl)) coverTextBox.Text = book.CoverUrl;

                    ShowStatus("✓ Book found in OpenLibrary!", isError: false);
                }
                else
                {
                    ShowStatus("ISBN not found. Please enter details manually.", isError: true);
                }
            }
            catch (Exception ex)
            {
                ShowStatus("Lookup failed: " + ex.Message, isError: true);
            }
            finally
            {
                lookupButton.Enabled = true;
                lookupButton.Text = "Lookup";
            }
        }

        private void HandleAddCopy(object? sender, EventArgs e)
        {
            var barcode = barcodeTextBox.Text.Trim().ToUpperInvariant();
            if (string.IsNullOrEmpty(barcode))
            {
                ShowStatus("Please enter a copy barcode.", isError: true);
                return;
            }

            // Check duplicate barcode in current list
            if (_exemplars.Exists(x => string.Equals(x.Barcode, barcode, StringComparison.OrdinalIgnoreCase)))
            {
                ShowStatus($"Barcode '{barcode}' is already in the list.", isError: true);
                return;
            }

            var condition = conditionComboBox.SelectedItem?.ToString() ?? "GOOD";
            var exemplar = new Exemplar
            {
                Id = Guid.NewGuid(),
                BibliographyId = _bookId ?? Guid.Empty,
                Barcode = barcode,
                Condition = condition,
                Status = "AVAILABLE",
                CreatedAt = DateTime.UtcNow
            };

            _exemplars.Add(exemplar);
            RefreshCopiesGrid();
            barcodeTextBox.Text = "BK-" + new Random().Next(100, 999);
            ShowStatus($"Added copy '{barcode}'.", isError: false);
        }

        private void HandleCopyGridClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _exemplars.Count) return;
            if (e.ColumnIndex == removeColumn.Index)
            {
                var copy = _exemplars[e.RowIndex];
                if (copy.Status == "BORROWED")
                {
                    MessageBox.Show(this, "Cannot remove a currently borrowed copy.", "Copy In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _deletedExemplarIds.Add(copy.Id);
                _exemplars.RemoveAt(e.RowIndex);
                RefreshCopiesGrid();
            }
        }

        private void RefreshCopiesGrid()
        {
            copiesGrid.Rows.Clear();
            foreach (var copy in _exemplars)
            {
                copiesGrid.Rows.Add(copy.Barcode, copy.Condition, copy.Status, "Del");
            }
        }

        private async Task HandleSaveAsync()
        {
            var title = titleTextBox.Text.Trim();
            var author = authorTextBox.Text.Trim();
            var publisher = publisherTextBox.Text.Trim();

            if (string.IsNullOrEmpty(title))
            {
                ShowStatus("Title is required.", isError: true);
                titleTextBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(author))
            {
                ShowStatus("Author is required.", isError: true);
                authorTextBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(publisher))
            {
                ShowStatus("Publisher is required.", isError: true);
                publisherTextBox.Focus();
                return;
            }

            int? year = null;
            if (int.TryParse(yearTextBox.Text.Trim(), out var parsedYear))
            {
                year = parsedYear;
            }

            saveButton.Enabled = false;
            saveButton.Text = "Saving...";

            try
            {
                if (_bookId.HasValue && _book != null)
                {
                    _book.Title = title;
                    _book.Isbn = string.IsNullOrWhiteSpace(isbnTextBox.Text) ? null : isbnTextBox.Text.Trim();
                    _book.Author = author;
                    _book.Publisher = publisher;
                    _book.PublisherYear = year;
                    _book.Description = string.IsNullOrWhiteSpace(descTextBox.Text) ? null : descTextBox.Text.Trim();
                    _book.CoverUrl = string.IsNullOrWhiteSpace(coverTextBox.Text) ? null : coverTextBox.Text.Trim();

                    await BookService.Instance.UpdateBibliographyAsync(_book);
                }
                else
                {
                    _book = new Bibliography
                    {
                        Id = Guid.NewGuid(),
                        Title = title,
                        Isbn = string.IsNullOrWhiteSpace(isbnTextBox.Text) ? null : isbnTextBox.Text.Trim(),
                        Author = author,
                        Publisher = publisher,
                        PublisherYear = year,
                        Description = string.IsNullOrWhiteSpace(descTextBox.Text) ? null : descTextBox.Text.Trim(),
                        CoverUrl = string.IsNullOrWhiteSpace(coverTextBox.Text) ? null : coverTextBox.Text.Trim()
                    };

                    await BookService.Instance.CreateBibliographyAsync(_book);
                }

                // Delete removed exemplars
                foreach (var delId in _deletedExemplarIds)
                {
                    await BookService.Instance.DeleteExemplarAsync(delId);
                }

                // Add or update current exemplars
                var existingCopies = await BookService.Instance.GetExemplarsAsync(_book.Id);
                var existingMap = new Dictionary<Guid, Exemplar>();
                foreach (var ec in existingCopies) existingMap[ec.Id] = ec;

                foreach (var copy in _exemplars)
                {
                    if (existingMap.ContainsKey(copy.Id))
                    {
                        await BookService.Instance.UpdateExemplarAsync(copy.Id, copy.Status, copy.Condition);
                    }
                    else
                    {
                        await BookService.Instance.AddExemplarAsync(_book.Id, copy.Barcode, copy.Condition);
                    }
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ShowStatus("Error saving: " + ex.Message, isError: true);
                saveButton.Enabled = true;
                saveButton.Text = "Save";
            }
        }

        private void ShowStatus(string message, bool isError)
        {
            statusMessageLabel.Text = message;
            statusMessageLabel.ForeColor = isError ? Color.FromArgb(153, 27, 27) : Color.FromArgb(22, 101, 52);
            statusMessageLabel.Visible = true;
        }
    }
}
