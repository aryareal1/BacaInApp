using System;
using System.Windows.Forms;

namespace BacaIn
{
    /// <summary>
    /// Displays detailed information about a selected book and its available copies.
    /// </summary>
    public partial class BookDetailPage : UserControl
    {
        /// <summary>
        /// Occurs when navigation back to the catalog is requested.
        /// </summary>
        public event EventHandler? BackToCatalogRequested;

        /// <summary>
        /// Initializes the book detail preview page.
        /// </summary>
        public BookDetailPage()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            RaiseBackToCatalogRequested();
        }

        /// <summary>
        /// Raises the BackToCatalogRequested event for navigation.
        /// </summary>
        public void RaiseBackToCatalogRequested()
        {
            BackToCatalogRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
