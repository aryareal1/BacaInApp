using System;
using System.Windows.Forms;
using BacaIn.Services;

namespace BacaIn
{
    /// <summary>
    /// Hosts student portal pages and their navigation.
    /// </summary>
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
            previewLabel.Visible = false;
            logoutButton.Click += LogoutButton_Click;
        }

        private void LogoutButton_Click(object? sender, EventArgs e)
        {
            var confirm = MessageBox.Show(this, "Are you sure you want to log out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                CurrentUser.Logout();
                Close();
            }
        }

        private async void catalogButton_Click(object sender, EventArgs e)
        {
            catalogButton.Checked = true;
            await catalogPage.LoadCatalogAsync();
            catalogPage.BringToFront();
        }

        private async void loansButton_Click(object sender, EventArgs e)
        {
            loansButton.Checked = true;
            await myLoansPage.LoadLoansAsync();
            myLoansPage.BringToFront();
        }

        private async void reservationsButton_Click(object sender, EventArgs e)
        {
            reservationsButton.Checked = true;
            await myReservationsPage.LoadReservationsAsync();
            myReservationsPage.BringToFront();
        }

        private async void historyButton_Click(object sender, EventArgs e)
        {
            historyButton.Checked = true;
            await checkInHistoryPage.LoadHistoryAsync();
            checkInHistoryPage.BringToFront();
        }

        private async void catalogPage_ViewDetailRequested(object sender, EventArgs e)
        {
            catalogButton.Checked = true;
            if (catalogPage.SelectedBookId.HasValue)
            {
                await bookDetailPage.LoadBookAsync(catalogPage.SelectedBookId.Value);
            }
            bookDetailPage.BringToFront();
        }

        private void bookDetailPage_BackToCatalogRequested(object sender, EventArgs e)
        {
            catalogButton.Checked = true;
            catalogPage.BringToFront();
        }
    }
}
