namespace BacaIn
{
    partial class BooksPage
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>Releases owned components.</summary>
        /// <param name="disposing">Whether managed resources should be disposed.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle alternateStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle deleteStyle = new DataGridViewCellStyle();
            pageLayout = new TableLayoutPanel();
            headingLabel = new Label();
            supportingLabel = new Label();
            toolbarLayout = new TableLayoutPanel();
            searchLayout = new TableLayoutPanel();
            searchLabel = new Label();
            searchTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            addBookButton = new Guna.UI2.WinForms.Guna2Button();
            catalogPanel = new Guna.UI2.WinForms.Guna2Panel();
            catalogLayout = new TableLayoutPanel();
            catalogLabel = new Label();
            booksGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            titleColumn = new DataGridViewTextBoxColumn();
            authorColumn = new DataGridViewTextBoxColumn();
            publisherColumn = new DataGridViewTextBoxColumn();
            isbnColumn = new DataGridViewTextBoxColumn();
            modifyColumn = new DataGridViewButtonColumn();
            deleteColumn = new DataGridViewButtonColumn();
            previewLabel = new Label();
            pageLayout.SuspendLayout();
            toolbarLayout.SuspendLayout();
            searchLayout.SuspendLayout();
            catalogPanel.SuspendLayout();
            catalogLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)booksGrid).BeginInit();
            SuspendLayout();
            //
            // pageLayout
            //
            pageLayout.ColumnCount = 1;
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.Controls.Add(headingLabel, 0, 0);
            pageLayout.Controls.Add(supportingLabel, 0, 1);
            pageLayout.Controls.Add(toolbarLayout, 0, 2);
            pageLayout.Controls.Add(catalogPanel, 0, 3);
            pageLayout.Dock = DockStyle.Fill;
            pageLayout.Margin = new Padding(0);
            pageLayout.MinimumSize = new Size(640, 500);
            pageLayout.Name = "pageLayout";
            pageLayout.Padding = new Padding(24);
            pageLayout.RowCount = 4;
            pageLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pageLayout.Size = new Size(960, 650);
            pageLayout.TabIndex = 0;
            //
            // headingLabel
            //
            headingLabel.AutoSize = true;
            headingLabel.Dock = DockStyle.Fill;
            headingLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            headingLabel.ForeColor = Color.FromArgb(26, 26, 26);
            headingLabel.Margin = new Padding(0, 0, 0, 8);
            headingLabel.Name = "headingLabel";
            headingLabel.TabIndex = 0;
            headingLabel.Text = "Manage Books";
            //
            // supportingLabel
            //
            supportingLabel.AutoSize = true;
            supportingLabel.Dock = DockStyle.Fill;
            supportingLabel.Font = new Font("Segoe UI", 10.5F);
            supportingLabel.ForeColor = Color.FromArgb(102, 102, 102);
            supportingLabel.Margin = new Padding(0, 0, 0, 24);
            supportingLabel.Name = "supportingLabel";
            supportingLabel.TabIndex = 1;
            supportingLabel.Text = "Organize the library catalog by title, author, publisher, and ISBN.";
            //
            // toolbarLayout
            //
            toolbarLayout.AutoSize = true;
            toolbarLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            toolbarLayout.ColumnCount = 2;
            toolbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            toolbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            toolbarLayout.Controls.Add(searchLayout, 0, 0);
            toolbarLayout.Controls.Add(addBookButton, 1, 0);
            toolbarLayout.Dock = DockStyle.Fill;
            toolbarLayout.Margin = new Padding(0, 0, 0, 24);
            toolbarLayout.Name = "toolbarLayout";
            toolbarLayout.RowCount = 1;
            toolbarLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            toolbarLayout.TabIndex = 2;
            //
            // searchLayout
            //
            searchLayout.AutoSize = true;
            searchLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            searchLayout.ColumnCount = 1;
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            searchLayout.Controls.Add(searchLabel, 0, 0);
            searchLayout.Controls.Add(searchTextBox, 0, 1);
            searchLayout.Dock = DockStyle.Fill;
            searchLayout.Margin = new Padding(0, 0, 16, 0);
            searchLayout.Name = "searchLayout";
            searchLayout.RowCount = 2;
            searchLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            searchLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            searchLayout.TabIndex = 0;
            //
            // searchLabel
            //
            searchLabel.AutoSize = true;
            searchLabel.Dock = DockStyle.Fill;
            searchLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            searchLabel.ForeColor = Color.FromArgb(26, 26, 26);
            searchLabel.Margin = new Padding(0, 0, 0, 8);
            searchLabel.Name = "searchLabel";
            searchLabel.TabIndex = 0;
            searchLabel.Text = "Search";
            //
            // searchTextBox
            //
            searchTextBox.AccessibleDescription = "Design preview. Catalog search is not connected.";
            searchTextBox.AccessibleName = "Search books";
            searchTextBox.BorderColor = Color.FromArgb(128, 128, 128);
            searchTextBox.BorderRadius = 4;
            searchTextBox.Cursor = Cursors.IBeam;
            searchTextBox.DefaultText = "";
            searchTextBox.Dock = DockStyle.Fill;
            searchTextBox.FillColor = Color.White;
            searchTextBox.FocusedState.BorderColor = Color.FromArgb(57, 112, 41);
            searchTextBox.Font = new Font("Segoe UI", 10.5F);
            searchTextBox.ForeColor = Color.FromArgb(26, 26, 26);
            searchTextBox.HoverState.BorderColor = Color.FromArgb(57, 112, 41);
            searchTextBox.Margin = new Padding(0);
            searchTextBox.MinimumSize = new Size(0, 44);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderForeColor = Color.FromArgb(102, 102, 102);
            searchTextBox.PlaceholderText = "Title, author, publisher, or ISBN";
            searchTextBox.Size = new Size(760, 44);
            searchTextBox.TabIndex = 1;
            //
            // addBookButton
            //
            addBookButton.AccessibleDescription = "Design preview. Add Book is not connected.";
            addBookButton.AccessibleName = "Add Book";
            addBookButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            addBookButton.BorderColor = Color.FromArgb(57, 112, 41);
            addBookButton.BorderRadius = 4;
            addBookButton.BorderThickness = 1;
            addBookButton.DisabledState.FillColor = Color.FromArgb(204, 204, 204);
            addBookButton.DisabledState.ForeColor = Color.FromArgb(102, 102, 102);
            addBookButton.FillColor = Color.FromArgb(57, 112, 41);
            addBookButton.FocusedColor = Color.FromArgb(38, 74, 28);
            addBookButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            addBookButton.ForeColor = Color.White;
            addBookButton.HoverState.FillColor = Color.FromArgb(38, 74, 28);
            addBookButton.Margin = new Padding(0);
            addBookButton.Name = "addBookButton";
            addBookButton.PressedColor = Color.Black;
            addBookButton.Size = new Size(136, 44);
            addBookButton.TabIndex = 1;
            addBookButton.Text = "Add Book";
            //
            // catalogPanel
            //
            catalogPanel.BorderColor = Color.FromArgb(204, 204, 204);
            catalogPanel.BorderRadius = 6;
            catalogPanel.BorderThickness = 1;
            catalogPanel.Controls.Add(catalogLayout);
            catalogPanel.Dock = DockStyle.Fill;
            catalogPanel.FillColor = Color.White;
            catalogPanel.Margin = new Padding(0);
            catalogPanel.Name = "catalogPanel";
            catalogPanel.Padding = new Padding(16);
            catalogPanel.TabIndex = 3;
            //
            // catalogLayout
            //
            catalogLayout.BackColor = Color.White;
            catalogLayout.ColumnCount = 1;
            catalogLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            catalogLayout.Controls.Add(catalogLabel, 0, 0);
            catalogLayout.Controls.Add(booksGrid, 0, 1);
            catalogLayout.Controls.Add(previewLabel, 0, 2);
            catalogLayout.Dock = DockStyle.Fill;
            catalogLayout.Margin = new Padding(0);
            catalogLayout.Name = "catalogLayout";
            catalogLayout.RowCount = 3;
            catalogLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            catalogLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            catalogLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            catalogLayout.TabIndex = 0;
            //
            // catalogLabel
            //
            catalogLabel.AutoSize = true;
            catalogLabel.Dock = DockStyle.Fill;
            catalogLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            catalogLabel.ForeColor = Color.FromArgb(26, 26, 26);
            catalogLabel.Margin = new Padding(0, 0, 0, 16);
            catalogLabel.Name = "catalogLabel";
            catalogLabel.TabIndex = 0;
            catalogLabel.Text = "Book catalog";
            //
            // booksGrid
            //
            booksGrid.AccessibleDescription = "Empty read-only catalog preview with Title, Author, Publisher, ISBN, Modify, and Delete columns.";
            booksGrid.AccessibleName = "Book catalog";
            booksGrid.AllowUserToAddRows = false;
            booksGrid.AllowUserToDeleteRows = false;
            booksGrid.AllowUserToResizeRows = false;
            booksGrid.AutoGenerateColumns = false;
            booksGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            booksGrid.BackgroundColor = Color.White;
            booksGrid.BorderStyle = BorderStyle.None;
            booksGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            booksGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(223, 241, 218);
            headerStyle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            headerStyle.ForeColor = Color.FromArgb(26, 26, 26);
            headerStyle.SelectionBackColor = Color.FromArgb(223, 241, 218);
            headerStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);
            headerStyle.WrapMode = DataGridViewTriState.True;
            booksGrid.ColumnHeadersDefaultCellStyle = headerStyle;
            booksGrid.ColumnHeadersHeight = 44;
            booksGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            booksGrid.ColumnHeadersVisible = true;
            booksGrid.Columns.AddRange(new DataGridViewColumn[] { titleColumn, authorColumn, publisherColumn, isbnColumn, modifyColumn, deleteColumn });
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Segoe UI", 10.5F);
            cellStyle.ForeColor = Color.FromArgb(26, 26, 26);
            cellStyle.SelectionBackColor = Color.FromArgb(223, 241, 218);
            cellStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);
            booksGrid.DefaultCellStyle = cellStyle;
            alternateStyle.BackColor = Color.White;
            alternateStyle.ForeColor = Color.FromArgb(26, 26, 26);
            alternateStyle.SelectionBackColor = Color.FromArgb(223, 241, 218);
            alternateStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);
            booksGrid.AlternatingRowsDefaultCellStyle = alternateStyle;
            booksGrid.Dock = DockStyle.Fill;
            booksGrid.EnableHeadersVisualStyles = false;
            booksGrid.GridColor = Color.FromArgb(204, 204, 204);
            booksGrid.Margin = new Padding(0);
            booksGrid.MultiSelect = false;
            booksGrid.Name = "booksGrid";
            booksGrid.ReadOnly = true;
            booksGrid.RowHeadersVisible = false;
            booksGrid.RowTemplate.Height = 40;
            booksGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            booksGrid.TabIndex = 1;
            booksGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            booksGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(26, 26, 26);
            booksGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.FromArgb(223, 241, 218);
            booksGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);
            booksGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(223, 241, 218);
            booksGrid.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(26, 26, 26);
            booksGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            booksGrid.ThemeStyle.HeaderStyle.Height = 44;
            booksGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            booksGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(26, 26, 26);
            booksGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 10.5F);
            booksGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(223, 241, 218);
            booksGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);
            booksGrid.ThemeStyle.RowsStyle.Height = 40;
            booksGrid.ThemeStyle.GridColor = Color.FromArgb(204, 204, 204);
            //
            // columns
            //
            titleColumn.FillWeight = 160F;
            titleColumn.HeaderText = "Title";
            titleColumn.MinimumWidth = 160;
            titleColumn.Name = "titleColumn";
            titleColumn.ReadOnly = true;
            authorColumn.FillWeight = 120F;
            authorColumn.HeaderText = "Author";
            authorColumn.MinimumWidth = 120;
            authorColumn.Name = "authorColumn";
            authorColumn.ReadOnly = true;
            publisherColumn.FillWeight = 120F;
            publisherColumn.HeaderText = "Publisher";
            publisherColumn.MinimumWidth = 120;
            publisherColumn.Name = "publisherColumn";
            publisherColumn.ReadOnly = true;
            isbnColumn.FillWeight = 150F;
            isbnColumn.HeaderText = "ISBN";
            isbnColumn.MinimumWidth = 150;
            isbnColumn.Name = "isbnColumn";
            isbnColumn.ReadOnly = true;
            modifyColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            modifyColumn.HeaderText = "Modify";
            modifyColumn.MinimumWidth = 80;
            modifyColumn.Name = "modifyColumn";
            modifyColumn.ReadOnly = true;
            modifyColumn.Text = "Modify";
            modifyColumn.UseColumnTextForButtonValue = true;
            modifyColumn.Width = 88;
            deleteStyle.ForeColor = Color.FromArgb(153, 27, 27);
            deleteStyle.SelectionForeColor = Color.FromArgb(153, 27, 27);
            deleteColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            deleteColumn.DefaultCellStyle = deleteStyle;
            deleteColumn.HeaderText = "Delete";
            deleteColumn.MinimumWidth = 80;
            deleteColumn.Name = "deleteColumn";
            deleteColumn.ReadOnly = true;
            deleteColumn.Text = "Delete";
            deleteColumn.UseColumnTextForButtonValue = true;
            deleteColumn.Width = 88;
            //
            // previewLabel
            //
            previewLabel.AutoSize = true;
            previewLabel.Dock = DockStyle.Fill;
            previewLabel.Font = new Font("Segoe UI", 10F);
            previewLabel.ForeColor = Color.FromArgb(102, 102, 102);
            previewLabel.Margin = new Padding(0, 16, 0, 0);
            previewLabel.Name = "previewLabel";
            previewLabel.TabIndex = 2;
            previewLabel.Text = "Design preview — no records loaded. Search and book actions are not connected.";
            //
            // BooksPage
            //
            AccessibleName = "Manage Books";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(242, 242, 242);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(0);
            Name = "BooksPage";
            Size = new Size(960, 650);
            pageLayout.ResumeLayout(false);
            pageLayout.PerformLayout();
            toolbarLayout.ResumeLayout(false);
            toolbarLayout.PerformLayout();
            searchLayout.ResumeLayout(false);
            searchLayout.PerformLayout();
            catalogPanel.ResumeLayout(false);
            catalogLayout.ResumeLayout(false);
            catalogLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)booksGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel pageLayout;
        private Label headingLabel;
        private Label supportingLabel;
        private TableLayoutPanel toolbarLayout;
        private TableLayoutPanel searchLayout;
        private Label searchLabel;
        private Guna.UI2.WinForms.Guna2TextBox searchTextBox;
        private Guna.UI2.WinForms.Guna2Button addBookButton;
        private Guna.UI2.WinForms.Guna2Panel catalogPanel;
        private TableLayoutPanel catalogLayout;
        private Label catalogLabel;
        private Guna.UI2.WinForms.Guna2DataGridView booksGrid;
        private DataGridViewTextBoxColumn titleColumn;
        private DataGridViewTextBoxColumn authorColumn;
        private DataGridViewTextBoxColumn publisherColumn;
        private DataGridViewTextBoxColumn isbnColumn;
        private DataGridViewButtonColumn modifyColumn;
        private DataGridViewButtonColumn deleteColumn;
        private Label previewLabel;
    }
}
