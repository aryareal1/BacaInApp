using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using BacaIn.Controls;
using BacaIn.Models;
using BacaIn.Services;

namespace BacaIn
{
    public partial class BooksPage : UserControl
    {
        private List<Bibliography> _books = new List<Bibliography>();

        public BooksPage()
        {
            InitializeComponent();
            previewLabel.Visible = false;

            searchTextBox.TextChanged += async (s, e) => await LoadBooksAsync(searchTextBox.Text.Trim());
            addBookButton.Click += async (s, e) => await HandleAddBookAsync();
            booksGrid.CellContentClick += async (s, e) => await HandleGridCellClickAsync(e);

            Load += async (s, e) => await LoadBooksAsync(null);
        }

        public async Task LoadBooksAsync(string? keyword)
        {
            try
            {
                _books = await BookService.Instance.SearchBibliographiesAsync(keyword);
                catalogLabel.Text = $"Catalog ({_books.Count} books)";

                booksGrid.Rows.Clear();
                foreach (var b in _books)
                {
                    var rowIndex = booksGrid.Rows.Add(
                        b.Title,
                        b.Author,
                        b.Publisher,
                        b.Isbn ?? "—",
                        "Modify",
                        "Delete"
                    );
                    booksGrid.Rows[rowIndex].Tag = b.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to load books: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task HandleAddBookAsync()
        {
            using var dialog = new BookEditDialog(null);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                await LoadBooksAsync(searchTextBox.Text.Trim());
            }
        }

        private async Task HandleGridCellClickAsync(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= booksGrid.Rows.Count) return;

            var bookId = (Guid)booksGrid.Rows[e.RowIndex].Tag!;
            var book = _books.Find(x => x.Id == bookId);

            if (e.ColumnIndex == modifyColumn.Index)
            {
                using var dialog = new BookEditDialog(bookId);
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    await LoadBooksAsync(searchTextBox.Text.Trim());
                }
            }
            else if (e.ColumnIndex == deleteColumn.Index)
            {
                var title = book?.Title ?? "this book";
                var confirm = MessageBox.Show(this,
                    $"Are you sure you want to delete '{title}' and all its copies?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    await BookService.Instance.DeleteBibliographyAsync(bookId);
                    await LoadBooksAsync(searchTextBox.Text.Trim());
                }
            }
        }
    }
}
