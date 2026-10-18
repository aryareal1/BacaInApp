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
