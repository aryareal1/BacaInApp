using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BacaIn.Models;
using BacaIn.Services;

namespace BacaIn
{
    public partial class CatalogPage : UserControl
    {
        public event EventHandler? ViewDetailRequested;
        private List<Bibliography> _books = new List<Bibliography>();
        public Guid? SelectedBookId { get; private set; }

        public CatalogPage()
        {
            InitializeComponent();
            previewLabel.Visible = false;
            previewDetailButton.Visible = false;

            searchButton.Click += async (s, e) => await LoadCatalogAsync();
            searchTextBox.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    await LoadCatalogAsync();
                }
            };
            availabilityComboBox.SelectedIndexChanged += async (s, e) => await LoadCatalogAsync();

            Load += async (s, e) => await LoadCatalogAsync();
        }

        public async Task LoadCatalogAsync()
        {
            if (CurrentUser.Current != null)
            {
                studentLabel.Text = $"Student: {CurrentUser.Current.DisplayName ?? CurrentUser.Current.Username}";
            }

            var kw = searchTextBox.Text.Trim();
            var availOnly = availabilityComboBox.SelectedIndex == 1; // 0 = All, 1 = Available

            try
            {
                _books = await BookService.Instance.SearchBibliographiesAsync(kw, availOnly);
                catalogCountLabel.Text = $"Showing {_books.Count} books";

                catalogGrid.Rows.Clear();
                foreach (var b in _books)
                {
                    var availText = $"{b.AvailableCopies} of {b.TotalCopies}";
                    var idx = catalogGrid.Rows.Add(b.Title, b.Author, availText, "View Detail");
                    catalogGrid.Rows[idx].Tag = b.Id;

                    if (b.AvailableCopies > 0)
                    {
                        catalogGrid.Rows[idx].Cells[availableColumn.Index].Style.ForeColor = Color.FromArgb(22, 101, 52);
                    }
                    else
                    {
                        catalogGrid.Rows[idx].Cells[availableColumn.Index].Style.ForeColor = Color.FromArgb(153, 27, 27);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to load catalog: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void catalogGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == actionColumn.Index)
            {
                SelectedBookId = (Guid)catalogGrid.Rows[e.RowIndex].Tag!;
                RaiseViewDetailRequested();
            }
        }

        private void previewDetailButton_Click(object sender, EventArgs e)
        {
            if (catalogGrid.SelectedRows.Count > 0)
            {
                SelectedBookId = (Guid)catalogGrid.SelectedRows[0].Tag!;
            }
            else if (_books.Count > 0)
            {
                SelectedBookId = _books[0].Id;
            }
            RaiseViewDetailRequested();
        }

        public void RaiseViewDetailRequested()
        {
            ViewDetailRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
