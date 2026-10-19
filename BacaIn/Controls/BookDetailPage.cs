using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BacaIn.Models;
using BacaIn.Services;

namespace BacaIn
{
    public partial class BookDetailPage : UserControl
    {
        public event EventHandler? BackToCatalogRequested;
        private Bibliography? _book;

        public BookDetailPage()
        {
            InitializeComponent();
            previewLabel.Visible = false;
            reserveButton.Click += async (s, e) => await HandleReserveAsync();
        }

        public async Task LoadBookAsync(Guid bookId)
        {
            try
            {
                _book = await BookService.Instance.GetBibliographyByIdAsync(bookId);
                if (_book == null) return;

                titleLabel.Text = _book.Title;
                authorLabel.Text = "Author: " + _book.Author;
                publisherLabel.Text = "Publisher: " + _book.Publisher;
                yearLabel.Text = "Publication year: " + (_book.PublisherYear?.ToString() ?? "—");
                isbnLabel.Text = "ISBN: " + (_book.Isbn ?? "—");
                descriptionLabel.Text = string.IsNullOrEmpty(_book.Description) ? "No description provided." : _book.Description;
                availabilityLabel.Text = $"Available copies: {_book.AvailableCopies} of {_book.TotalCopies}";

                if (CurrentUser.Current != null)
                {
                    studentLabel.Text = $"Student: {CurrentUser.Current.DisplayName ?? CurrentUser.Current.Username}";
                }

                var copies = await BookService.Instance.GetExemplarsAsync(bookId);
                copiesGrid.Rows.Clear();
                foreach (var copy in copies)
                {
                    var idx = copiesGrid.Rows.Add(copy.Barcode, copy.Condition, copy.Status);
                    if (copy.Status == "AVAILABLE")
                    {
                        copiesGrid.Rows[idx].Cells[statusColumn.Index].Style.ForeColor = Color.FromArgb(22, 101, 52);
                    }
                    else if (copy.Status == "BORROWED")
                    {
                        copiesGrid.Rows[idx].Cells[statusColumn.Index].Style.ForeColor = Color.FromArgb(30, 64, 175);
                    }
                    else
                    {
                        copiesGrid.Rows[idx].Cells[statusColumn.Index].Style.ForeColor = Color.FromArgb(153, 27, 27);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to load book details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task HandleReserveAsync()
        {
            if (_book == null) return;
            if (CurrentUser.Current == null)
            {
                MessageBox.Show(this, "Please log in to reserve books.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            reserveButton.Enabled = false;
            reserveButton.Text = "Reserving...";

            try
            {
                var reservation = await ReservationService.Instance.MakeReservationAsync(CurrentUser.Current.Id, _book.Id);
                MessageBox.Show(this,
                    $"Successfully reserved '{_book.Title}'!\nYour queue position: #{reservation.QueuePosition}.\nYou will be notified when a copy becomes available for pickup.",
                    "Reservation Confirmed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Reservation Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                reserveButton.Enabled = true;
                reserveButton.Text = "Reserve Book";
            }
        }

        public void RaiseBackToCatalogRequested()
        {
            BackToCatalogRequested?.Invoke(this, EventArgs.Empty);
        }
        private void backButton_Click(object? sender, EventArgs e)
        {
            RaiseBackToCatalogRequested();
        }
    }
}
