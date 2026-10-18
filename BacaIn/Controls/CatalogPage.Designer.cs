namespace BacaIn
{
    partial class CatalogPage
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Releases owned components.
        /// </summary>
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
            DataGridViewCellStyle actionStyle = new DataGridViewCellStyle();
            pageLayout = new TableLayoutPanel();
            headerLayout = new TableLayoutPanel();
            headingLabel = new Label();
            studentLabel = new Label();
            supportingLabel = new Label();
            toolbarLayout = new TableLayoutPanel();
            searchTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            searchButton = new Guna.UI2.WinForms.Guna2Button();
            availabilityComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            previewDetailButton = new Guna.UI2.WinForms.Guna2Button();
            catalogPanel = new Guna.UI2.WinForms.Guna2Panel();
            catalogLayout = new TableLayoutPanel();
            catalogCountLabel = new Label();
            catalogGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            titleColumn = new DataGridViewTextBoxColumn();
            authorColumn = new DataGridViewTextBoxColumn();
            availableColumn = new DataGridViewTextBoxColumn();
            actionColumn = new DataGridViewButtonColumn();
            bottomBarLayout = new TableLayoutPanel();
            noteLabel = new Label();
            paginationLayout = new FlowLayoutPanel();
            previousButton = new Guna.UI2.WinForms.Guna2Button();
            pageNumberButton = new Guna.UI2.WinForms.Guna2Button();
            nextButton = new Guna.UI2.WinForms.Guna2Button();
            previewLabel = new Label();
            pageLayout.SuspendLayout();
            headerLayout.SuspendLayout();
            toolbarLayout.SuspendLayout();
            catalogPanel.SuspendLayout();
            catalogLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)catalogGrid).BeginInit();
            bottomBarLayout.SuspendLayout();
            paginationLayout.SuspendLayout();
            SuspendLayout();
            // 
            // pageLayout
            // 
            pageLayout.AutoScroll = true;
            pageLayout.ColumnCount = 1;
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.Controls.Add(headerLayout, 0, 0);
            pageLayout.Controls.Add(supportingLabel, 0, 1);
            pageLayout.Controls.Add(toolbarLayout, 0, 2);
            pageLayout.Controls.Add(catalogPanel, 0, 3);
            pageLayout.Controls.Add(previewLabel, 0, 4);
            pageLayout.Dock = DockStyle.Fill;
            pageLayout.Margin = new Padding(0);
            pageLayout.MinimumSize = new Size(640, 500);
            pageLayout.Name = "pageLayout";
            pageLayout.Padding = new Padding(24);
            pageLayout.RowCount = 5;
            pageLayout.RowStyles.Add(new RowStyle());
            pageLayout.RowStyles.Add(new RowStyle());
            pageLayout.RowStyles.Add(new RowStyle());
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pageLayout.RowStyles.Add(new RowStyle());
            pageLayout.Size = new Size(1048, 800);
            pageLayout.TabIndex = 0;
            // 
            // headerLayout
            // 
            headerLayout.AutoSize = true;
            headerLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            headerLayout.ColumnCount = 2;
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            headerLayout.Controls.Add(headingLabel, 0, 0);
            headerLayout.Controls.Add(studentLabel, 1, 0);
            headerLayout.Dock = DockStyle.Fill;
            headerLayout.Margin = new Padding(0, 0, 0, 8);
            headerLayout.Name = "headerLayout";
            headerLayout.RowCount = 1;
            headerLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            headerLayout.TabIndex = 0;
            // 
            // headingLabel
            // 
            headingLabel.AutoSize = true;
            headingLabel.Dock = DockStyle.Fill;
            headingLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            headingLabel.ForeColor = Color.FromArgb(36, 51, 46);
            headingLabel.Margin = new Padding(0);
            headingLabel.Name = "headingLabel";
            headingLabel.TabIndex = 0;
            headingLabel.Text = "View Catalog";
            // 
            // studentLabel
            // 
            studentLabel.Anchor = AnchorStyles.Right;
            studentLabel.AutoSize = true;
            studentLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            studentLabel.ForeColor = Color.FromArgb(47, 93, 80);
            studentLabel.Margin = new Padding(0);
            studentLabel.Name = "studentLabel";
            studentLabel.TabIndex = 1;
            studentLabel.Text = "Student: Aji";
            studentLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // supportingLabel
            // 
            supportingLabel.AutoSize = true;
            supportingLabel.Dock = DockStyle.Fill;
            supportingLabel.Font = new Font("Segoe UI", 10.5F);
            supportingLabel.ForeColor = Color.FromArgb(95, 111, 103);
            supportingLabel.Margin = new Padding(0, 0, 0, 20);
            supportingLabel.Name = "supportingLabel";
            supportingLabel.TabIndex = 1;
            supportingLabel.Text = "Explore books, check copy availability, and view full details.";
            // 
            // toolbarLayout
            // 
            toolbarLayout.AutoSize = true;
            toolbarLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            toolbarLayout.ColumnCount = 4;
            toolbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            toolbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            toolbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            toolbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            toolbarLayout.Controls.Add(searchTextBox, 0, 0);
            toolbarLayout.Controls.Add(searchButton, 1, 0);
            toolbarLayout.Controls.Add(availabilityComboBox, 2, 0);
            toolbarLayout.Controls.Add(previewDetailButton, 3, 0);
            toolbarLayout.Dock = DockStyle.Fill;
            toolbarLayout.Margin = new Padding(0, 0, 0, 16);
            toolbarLayout.Name = "toolbarLayout";
            toolbarLayout.RowCount = 1;
            toolbarLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            toolbarLayout.TabIndex = 2;
            // 
            // searchTextBox
            // 
            searchTextBox.AccessibleName = "Search catalog";
            searchTextBox.BorderColor = Color.FromArgb(120, 135, 126);
            searchTextBox.BorderRadius = 6;
            searchTextBox.Dock = DockStyle.Fill;
            searchTextBox.FocusedState.BorderColor = Color.FromArgb(47, 93, 80);
            searchTextBox.Font = new Font("Segoe UI", 10.5F);
            searchTextBox.ForeColor = Color.FromArgb(36, 51, 46);
            searchTextBox.HoverState.BorderColor = Color.FromArgb(47, 93, 80);
            searchTextBox.Margin = new Padding(0, 0, 12, 0);
            searchTextBox.MinimumSize = new Size(0, 40);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "Search title, author or ISBN...";
            searchTextBox.Size = new Size(460, 40);
            searchTextBox.TabIndex = 0;
            // 
            // searchButton
            // 
            searchButton.AccessibleName = "Search";
            searchButton.AccessibleDescription = "Design preview action. Search is not connected.";
            searchButton.BorderColor = Color.FromArgb(47, 93, 80);
            searchButton.BorderRadius = 6;
            searchButton.BorderThickness = 1;
            searchButton.FillColor = Color.FromArgb(47, 93, 80);
            searchButton.FocusedColor = Color.FromArgb(36, 72, 62);
            searchButton.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            searchButton.ForeColor = Color.White;
            searchButton.HoverState.FillColor = Color.FromArgb(36, 72, 62);
            searchButton.Margin = new Padding(0, 0, 12, 0);
            searchButton.Name = "searchButton";
            searchButton.PressedColor = Color.FromArgb(36, 72, 62);
            searchButton.Size = new Size(100, 40);
            searchButton.TabIndex = 1;
            searchButton.Text = "Search";
            // 
            // availabilityComboBox
            // 
            availabilityComboBox.AccessibleName = "Availability filter";
            availabilityComboBox.BorderColor = Color.FromArgb(120, 135, 126);
            availabilityComboBox.BorderRadius = 6;
            availabilityComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            availabilityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            availabilityComboBox.FillColor = Color.White;
            availabilityComboBox.FocusedColor = Color.FromArgb(47, 93, 80);
            availabilityComboBox.FocusedState.BorderColor = Color.FromArgb(47, 93, 80);
            availabilityComboBox.Font = new Font("Segoe UI", 10.5F);
            availabilityComboBox.ForeColor = Color.FromArgb(36, 51, 46);
            availabilityComboBox.ItemHeight = 34;
            availabilityComboBox.Items.AddRange(new object[] {
            "Availability: All",
            "Availability: Available",
            "Availability: Borrowed"});
            availabilityComboBox.Margin = new Padding(0, 0, 12, 0);
            availabilityComboBox.Name = "availabilityComboBox";
            availabilityComboBox.SelectedIndex = 0;
            availabilityComboBox.Size = new Size(190, 40);
            availabilityComboBox.TabIndex = 2;
            // 
            // previewDetailButton
            // 
            previewDetailButton.AccessibleName = "Inspect Book Detail";
            previewDetailButton.AccessibleDescription = "Open the book detail design-preview page";
            previewDetailButton.BorderColor = Color.FromArgb(120, 135, 126);
            previewDetailButton.BorderRadius = 6;
            previewDetailButton.BorderThickness = 1;
            previewDetailButton.FillColor = Color.White;
            previewDetailButton.FocusedColor = Color.FromArgb(47, 93, 80);
            previewDetailButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            previewDetailButton.ForeColor = Color.FromArgb(36, 51, 46);
            previewDetailButton.HoverState.BorderColor = Color.FromArgb(47, 93, 80);
            previewDetailButton.HoverState.FillColor = Color.FromArgb(229, 239, 232);
            previewDetailButton.Margin = new Padding(0);
            previewDetailButton.Name = "previewDetailButton";
            previewDetailButton.PressedColor = Color.FromArgb(36, 72, 62);
            previewDetailButton.Size = new Size(140, 40);
            previewDetailButton.TabIndex = 3;
            previewDetailButton.Text = "View Detail →";
            previewDetailButton.Click += previewDetailButton_Click;
            // 
            // catalogPanel
            // 
            catalogPanel.BorderColor = Color.FromArgb(216, 223, 216);
            catalogPanel.BorderRadius = 8;
            catalogPanel.BorderThickness = 1;
            catalogPanel.Controls.Add(catalogLayout);
            catalogPanel.Dock = DockStyle.Fill;
            catalogPanel.FillColor = Color.White;
            catalogPanel.Margin = new Padding(0);
            catalogPanel.Name = "catalogPanel";
            catalogPanel.Padding = new Padding(16);
            catalogPanel.Size = new Size(1000, 580);
            catalogPanel.TabIndex = 3;
            // 
            // catalogLayout
            // 
            catalogLayout.BackColor = Color.White;
            catalogLayout.ColumnCount = 1;
            catalogLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            catalogLayout.Controls.Add(catalogCountLabel, 0, 0);
            catalogLayout.Controls.Add(catalogGrid, 0, 1);
            catalogLayout.Controls.Add(bottomBarLayout, 0, 2);
            catalogLayout.Dock = DockStyle.Fill;
            catalogLayout.Margin = new Padding(0);
            catalogLayout.Name = "catalogLayout";
            catalogLayout.RowCount = 3;
            catalogLayout.RowStyles.Add(new RowStyle());
            catalogLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            catalogLayout.RowStyles.Add(new RowStyle());
            catalogLayout.TabIndex = 0;
            // 
            // catalogCountLabel
            // 
            catalogCountLabel.AutoSize = true;
            catalogCountLabel.Dock = DockStyle.Fill;
            catalogCountLabel.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            catalogCountLabel.ForeColor = Color.FromArgb(36, 51, 46);
            catalogCountLabel.Margin = new Padding(0, 0, 0, 12);
            catalogCountLabel.Name = "catalogCountLabel";
            catalogCountLabel.TabIndex = 0;
            catalogCountLabel.Text = "Books in Library";
            // 
            // catalogGrid
            // 
            catalogGrid.AccessibleName = "Book catalog table";
            catalogGrid.AccessibleDescription = "Design preview table showing library books and availability.";
            catalogGrid.AllowUserToAddRows = false;
            catalogGrid.AllowUserToDeleteRows = false;
            catalogGrid.AllowUserToResizeRows = false;
            alternateStyle.BackColor = Color.FromArgb(247, 248, 244);
            catalogGrid.AlternatingRowsDefaultCellStyle = alternateStyle;
            catalogGrid.AutoGenerateColumns = false;
            catalogGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            catalogGrid.BackgroundColor = Color.White;
            catalogGrid.BorderStyle = BorderStyle.None;
            catalogGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            catalogGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(229, 239, 232);
            headerStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            headerStyle.ForeColor = Color.FromArgb(36, 51, 46);
            headerStyle.SelectionBackColor = Color.FromArgb(229, 239, 232);
            headerStyle.SelectionForeColor = Color.FromArgb(36, 51, 46);
            headerStyle.WrapMode = DataGridViewTriState.True;
            catalogGrid.ColumnHeadersDefaultCellStyle = headerStyle;
            catalogGrid.ColumnHeadersHeight = 36;
            catalogGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            catalogGrid.Columns.AddRange(new DataGridViewColumn[] {
            titleColumn,
            authorColumn,
            availableColumn,
            actionColumn});
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Segoe UI", 10F);
            cellStyle.ForeColor = Color.FromArgb(36, 51, 46);
            cellStyle.SelectionBackColor = Color.FromArgb(229, 239, 232);
            cellStyle.SelectionForeColor = Color.FromArgb(36, 51, 46);
            cellStyle.WrapMode = DataGridViewTriState.False;
            catalogGrid.DefaultCellStyle = cellStyle;
            catalogGrid.Dock = DockStyle.Fill;
            catalogGrid.EnableHeadersVisualStyles = false;
            catalogGrid.GridColor = Color.FromArgb(216, 223, 216);
            catalogGrid.Margin = new Padding(0);
            catalogGrid.MultiSelect = false;
            catalogGrid.Name = "catalogGrid";
            catalogGrid.ReadOnly = true;
            catalogGrid.RowHeadersVisible = false;
            catalogGrid.RowTemplate.Height = 40;
            catalogGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            catalogGrid.TabIndex = 1;
            catalogGrid.CellContentClick += catalogGrid_CellContentClick;
            // 
            // titleColumn
            // 
            titleColumn.FillWeight = 200F;
            titleColumn.HeaderText = "Title";
            titleColumn.MinimumWidth = 160;
            titleColumn.Name = "titleColumn";
            titleColumn.ReadOnly = true;
            // 
            // authorColumn
            // 
            authorColumn.FillWeight = 175F;
            authorColumn.HeaderText = "Author";
            authorColumn.MinimumWidth = 140;
            authorColumn.Name = "authorColumn";
            authorColumn.ReadOnly = true;
            // 
            // availableColumn
            // 
            availableColumn.FillWeight = 100F;
            availableColumn.HeaderText = "Available";
            availableColumn.MinimumWidth = 90;
            availableColumn.Name = "availableColumn";
            availableColumn.ReadOnly = true;
            // 
            // actionColumn
            // 
            actionColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            actionStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            actionColumn.DefaultCellStyle = actionStyle;
            actionColumn.FlatStyle = FlatStyle.Standard;
            actionColumn.HeaderText = "Action";
            actionColumn.MinimumWidth = 110;
            actionColumn.Name = "actionColumn";
            actionColumn.ReadOnly = true;
            actionColumn.Text = "View Detail";
            actionColumn.UseColumnTextForButtonValue = true;
            actionColumn.Width = 110;
            // 
            // bottomBarLayout
            // 
            bottomBarLayout.AutoSize = true;
            bottomBarLayout.ColumnCount = 2;
            bottomBarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bottomBarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            bottomBarLayout.Controls.Add(noteLabel, 0, 0);
            bottomBarLayout.Controls.Add(paginationLayout, 1, 0);
            bottomBarLayout.Dock = DockStyle.Fill;
            bottomBarLayout.Margin = new Padding(0, 16, 0, 0);
            bottomBarLayout.Name = "bottomBarLayout";
            bottomBarLayout.RowCount = 1;
            bottomBarLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            bottomBarLayout.TabIndex = 2;
            // 
            // noteLabel
            // 
            noteLabel.Anchor = AnchorStyles.Left;
            noteLabel.AutoSize = true;
            noteLabel.Font = new Font("Segoe UI", 9.5F);
            noteLabel.ForeColor = Color.FromArgb(95, 111, 103);
            noteLabel.Margin = new Padding(0);
            noteLabel.Name = "noteLabel";
            noteLabel.TabIndex = 0;
            noteLabel.Text = "Select a book to inspect details or place a reservation.";
            // 
            // paginationLayout
            // 
            paginationLayout.Anchor = AnchorStyles.Right;
            paginationLayout.AutoSize = true;
            paginationLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            paginationLayout.Controls.Add(previousButton);
            paginationLayout.Controls.Add(pageNumberButton);
            paginationLayout.Controls.Add(nextButton);
            paginationLayout.FlowDirection = FlowDirection.LeftToRight;
            paginationLayout.Margin = new Padding(0);
            paginationLayout.Name = "paginationLayout";
            paginationLayout.TabIndex = 1;
            paginationLayout.WrapContents = false;
            // 
            // previousButton
            // 
            previousButton.BorderColor = Color.FromArgb(120, 135, 126);
            previousButton.BorderRadius = 4;
            previousButton.BorderThickness = 1;
            previousButton.FillColor = Color.White;
            previousButton.Font = new Font("Segoe UI", 9F);
            previousButton.ForeColor = Color.FromArgb(36, 51, 46);
            previousButton.HoverState.FillColor = Color.FromArgb(229, 239, 232);
            previousButton.Margin = new Padding(0, 0, 4, 0);
            previousButton.Name = "previousButton";
            previousButton.Size = new Size(72, 28);
            previousButton.TabIndex = 0;
            previousButton.Text = "Previous";
            // 
            // pageNumberButton
            // 
            pageNumberButton.BorderColor = Color.FromArgb(47, 93, 80);
            pageNumberButton.BorderRadius = 4;
            pageNumberButton.BorderThickness = 1;
            pageNumberButton.FillColor = Color.FromArgb(229, 239, 232);
            pageNumberButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            pageNumberButton.ForeColor = Color.FromArgb(47, 93, 80);
            pageNumberButton.Margin = new Padding(0, 0, 4, 0);
            pageNumberButton.Name = "pageNumberButton";
            pageNumberButton.Size = new Size(32, 28);
            pageNumberButton.TabIndex = 1;
            pageNumberButton.Text = "1";
            // 
            // nextButton
            // 
            nextButton.BorderColor = Color.FromArgb(120, 135, 126);
            nextButton.BorderRadius = 4;
            nextButton.BorderThickness = 1;
            nextButton.FillColor = Color.White;
            nextButton.Font = new Font("Segoe UI", 9F);
            nextButton.ForeColor = Color.FromArgb(36, 51, 46);
            nextButton.HoverState.FillColor = Color.FromArgb(229, 239, 232);
            nextButton.Margin = new Padding(0);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(60, 28);
            nextButton.TabIndex = 2;
            nextButton.Text = "Next";
            // 
            // previewLabel
            // 
            previewLabel.AutoSize = true;
            previewLabel.Dock = DockStyle.Fill;
            previewLabel.Font = new Font("Segoe UI", 10F);
            previewLabel.ForeColor = Color.FromArgb(95, 111, 103);
            previewLabel.Margin = new Padding(0, 12, 0, 0);
            previewLabel.Name = "previewLabel";
            previewLabel.TabIndex = 4;
            previewLabel.Text = "Design preview — no records loaded. Search and book actions are not connected.";
            // 
            // CatalogPage
            // 
            AccessibleName = "Book Catalog";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(247, 248, 244);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(0);
            Name = "CatalogPage";
            Size = new Size(1048, 800);
            pageLayout.ResumeLayout(false);
            pageLayout.PerformLayout();
            headerLayout.ResumeLayout(false);
            headerLayout.PerformLayout();
            toolbarLayout.ResumeLayout(false);
            catalogPanel.ResumeLayout(false);
            catalogLayout.ResumeLayout(false);
            catalogLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)catalogGrid).EndInit();
            bottomBarLayout.ResumeLayout(false);
            bottomBarLayout.PerformLayout();
            paginationLayout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel pageLayout;
        private TableLayoutPanel headerLayout;
        private Label headingLabel;
        private Label studentLabel;
        private Label supportingLabel;
        private TableLayoutPanel toolbarLayout;
        private Guna.UI2.WinForms.Guna2TextBox searchTextBox;
        private Guna.UI2.WinForms.Guna2Button searchButton;
        private Guna.UI2.WinForms.Guna2ComboBox availabilityComboBox;
        private Guna.UI2.WinForms.Guna2Button previewDetailButton;
        private Guna.UI2.WinForms.Guna2Panel catalogPanel;
        private TableLayoutPanel catalogLayout;
        private Label catalogCountLabel;
        private Guna.UI2.WinForms.Guna2DataGridView catalogGrid;
        private DataGridViewTextBoxColumn titleColumn;
        private DataGridViewTextBoxColumn authorColumn;
        private DataGridViewTextBoxColumn availableColumn;
        private DataGridViewButtonColumn actionColumn;
        private TableLayoutPanel bottomBarLayout;
        private Label noteLabel;
        private FlowLayoutPanel paginationLayout;
        private Guna.UI2.WinForms.Guna2Button previousButton;
        private Guna.UI2.WinForms.Guna2Button pageNumberButton;
        private Guna.UI2.WinForms.Guna2Button nextButton;
        private Label previewLabel;
    }
}
