using System;
using System.Windows.Forms;

namespace BacaIn
{
    /// <summary>
    /// Hosts design-preview library administration pages and their navigation.
    /// </summary>
    public partial class AdminForm : Form
    {
        /// <summary>
        /// Creates the administration shell with the Books page selected.
        /// </summary>
        public AdminForm()
        {
            InitializeComponent();
            previewLabel.Visible = false;
            logoutButton.Click += LogoutButton_Click;
            studentsPage.ManageLoansRequested += async (s, studentId) =>
            {
                loansReturnsButton.Checked = true;
                await loansReturnsPage.SelectStudentByIdAsync(studentId);
                loansReturnsPage.BringToFront();
            };
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
        private void booksButton_Click(object sender, EventArgs e)
        {
            booksButton.Checked = true;
            booksPage.BringToFront();
        }

        private void loansReturnsButton_Click(object sender, EventArgs e)
        {
            loansReturnsButton.Checked = true;
            loansReturnsPage.BringToFront();
        }

        private void studentsButton_Click(object sender, EventArgs e)
        {
            studentsButton.Checked = true;
            studentsPage.BringToFront();
        }

        private void reportsButton_Click(object sender, EventArgs e)
        {
            reportsButton.Checked = true;
            reportsPage.BringToFront();
        }
    }
}
