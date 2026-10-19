using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BacaIn.Models;
using BacaIn.Services;

namespace BacaIn
{
    public partial class MyReservationsPage : UserControl
    {
        private List<Reservation> _reservations = new List<Reservation>();

        public MyReservationsPage()
        {
            InitializeComponent();
            previewLabel.Visible = false;

            statusComboBox.SelectedIndexChanged += async (s, e) => await LoadReservationsAsync();
            reservationsGrid.CellContentClick += async (s, e) => await HandleCancelClickAsync(e);

            Load += async (s, e) => await LoadReservationsAsync();
        }

        public async Task LoadReservationsAsync()
        {
            if (CurrentUser.Current == null) return;
            studentLabel.Text = $"Student: {CurrentUser.Current.DisplayName ?? CurrentUser.Current.Username}";

            var filter = statusComboBox.SelectedItem?.ToString() ?? "All";
            if (filter.StartsWith("Status: ")) filter = filter.Replace("Status: ", "").Trim();

            try
            {
                _reservations = await ReservationService.Instance.GetStudentReservationsAsync(CurrentUser.Current.Id, filter);

                var allForStudent = await ReservationService.Instance.GetStudentReservationsAsync(CurrentUser.Current.Id, null);
                var pendingCount = allForStudent.FindAll(x => x.Status == "PENDING").Count;
                var readyCount = allForStudent.FindAll(x => x.Status == "READY").Count;

                pendingCountLabel.Text = $"Pending: {pendingCount}";
                readyCountLabel.Text = $"Ready: {readyCount}";

                reservationsGrid.Rows.Clear();
                foreach (var r in _reservations)
                {
                    var actionText = (r.Status == "PENDING" || r.Status == "READY") ? "Cancel" : "—";
                    var idx = reservationsGrid.Rows.Add(
                        r.BookTitle ?? "—",
                        r.ReservedAt.ToLocalTime().ToString("dd MMM yyyy"),
                        r.Status,
                        r.QueuePosition.ToString(),
                        actionText
                    );
                    reservationsGrid.Rows[idx].Tag = r;

                    if (r.Status == "READY")
                    {
                        reservationsGrid.Rows[idx].Cells[statusColumn.Index].Style.ForeColor = Color.FromArgb(22, 101, 52);
                        reservationsGrid.Rows[idx].Cells[statusColumn.Index].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    }
                    else if (r.Status == "PENDING")
                    {
                        reservationsGrid.Rows[idx].Cells[statusColumn.Index].Style.ForeColor = Color.FromArgb(146, 64, 14);
                    }
                    else if (r.Status == "CANCELLED")
                    {
                        reservationsGrid.Rows[idx].Cells[statusColumn.Index].Style.ForeColor = Color.FromArgb(102, 102, 102);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to load reservations: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task HandleCancelClickAsync(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= reservationsGrid.Rows.Count) return;
            if (e.ColumnIndex != actionColumn.Index) return;
            if (reservationsGrid.Rows[e.RowIndex].Tag is not Reservation reservation) return;
            if (reservation.Status != "PENDING" && reservation.Status != "READY") return;

            var confirm = MessageBox.Show(this,
                $"Are you sure you want to cancel your reservation for '{reservation.BookTitle}'?",
                "Cancel Reservation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    await ReservationService.Instance.CancelReservationAsync(reservation.Id);
                    MessageBox.Show(this, "Reservation cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadReservationsAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error cancelling reservation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
