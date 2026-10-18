using System;
using System.Windows.Forms;

namespace BacaIn
{
    /// <summary>
    /// Displays the student book catalog search and browsing page.
    /// </summary>
    public partial class CatalogPage : UserControl
    {
        /// <summary>
        /// Occurs when a book detail view is requested.
        /// </summary>
        public event EventHandler? ViewDetailRequested;

        /// <summary>
        /// Initializes the student catalog page.
        /// </summary>
        public CatalogPage()
        {
            InitializeComponent();
        }

        private void catalogGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == actionColumn.Index)
            {
                ViewDetailRequested?.Invoke(this, EventArgs.Empty);
            }
        }

        private void previewDetailButton_Click(object sender, EventArgs e)
        {
            RaiseViewDetailRequested();
        }

        /// <summary>
        /// Raises the ViewDetailRequested event for navigation.
        /// </summary>
        public void RaiseViewDetailRequested()
        {
            ViewDetailRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
