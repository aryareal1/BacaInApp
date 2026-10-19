using System;
using System.Windows.Forms;

namespace BacaIn
{
    /// <summary>
    /// Hosts design-preview student portal pages and their navigation.
    /// </summary>
    public partial class StudentForm : Form
    {
        /// <summary>
        /// Creates the student portal shell with the Catalog page selected.
        /// </summary>
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
                Services.CurrentUser.Logout();
                Close();
            }
        }
        private void catalogButton_Click(object sender, EventArgs e)
        {
            catalogButton.Checked = true;
            catalogPage.BringToFront();
        }

        private void loansButton_Click(object sender, EventArgs e)
        {
            loansButton.Checked = true;
            myLoansPage.BringToFront();
        }

        private void reservationsButton_Click(object sender, EventArgs e)
        {
            reservationsButton.Checked = true;
            myReservationsPage.BringToFront();
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            historyButton.Checked = true;
            checkInHistoryPage.BringToFront();
        }

        private void catalogPage_ViewDetailRequested(object sender, EventArgs e)
        {
            catalogButton.Checked = true;
            bookDetailPage.BringToFront();
        }

        private void bookDetailPage_BackToCatalogRequested(object sender, EventArgs e)
        {
            catalogButton.Checked = true;
            catalogPage.BringToFront();
        }
    }
}
