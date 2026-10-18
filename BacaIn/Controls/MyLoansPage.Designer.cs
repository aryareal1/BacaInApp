namespace BacaIn
{
    partial class MyLoansPage
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
            pageLayout = new TableLayoutPanel();
            headerLayout = new TableLayoutPanel();
            headingLabel = new Label();
            studentLabel = new Label();
            supportingLabel = new Label();
            toolbarLayout = new TableLayoutPanel();
            statusComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            summaryLayout = new FlowLayoutPanel();
            activeCountLabel = new Label();
            overdueCountLabel = new Label();
            returnedCountLabel = new Label();
            loansPanel = new Guna.UI2.WinForms.Guna2Panel();
            loansLayout = new TableLayoutPanel();
            loansGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            bookColumn = new DataGridViewTextBoxColumn();
            borrowedColumn = new DataGridViewTextBoxColumn();
            dueColumn = new DataGridViewTextBoxColumn();
            returnedColumn = new DataGridViewTextBoxColumn();
            statusColumn = new DataGridViewTextBoxColumn();
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
            summaryLayout.SuspendLayout();
            loansPanel.SuspendLayout();
            loansLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)loansGrid).BeginInit();
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
            pageLayout.Controls.Add(loansPanel, 0, 3);
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
            headingLabel.ForeColor = Color.FromArgb(26, 26, 26);
            headingLabel.Margin = new Padding(0);
            headingLabel.Name = "headingLabel";
            headingLabel.TabIndex = 0;
            headingLabel.Text = "View My Loans";
            // 
            // studentLabel
            // 
            studentLabel.Anchor = AnchorStyles.Right;
            studentLabel.AutoSize = true;
            studentLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            studentLabel.ForeColor = Color.FromArgb(57, 112, 41);
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
            supportingLabel.ForeColor = Color.FromArgb(102, 102, 102);
            supportingLabel.Margin = new Padding(0, 0, 0, 20);
            supportingLabel.Name = "supportingLabel";
            supportingLabel.TabIndex = 1;
            supportingLabel.Text = "Track your borrowed books, due dates, and return statuses.";
            // 
            // toolbarLayout
            // 
            toolbarLayout.AutoSize = true;
            toolbarLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            toolbarLayout.ColumnCount = 2;
            toolbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            toolbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            toolbarLayout.Controls.Add(statusComboBox, 0, 0);
            toolbarLayout.Controls.Add(summaryLayout, 1, 0);
            toolbarLayout.Dock = DockStyle.Fill;
            toolbarLayout.Margin = new Padding(0, 0, 0, 16);
            toolbarLayout.Name = "toolbarLayout";
            toolbarLayout.RowCount = 1;
            toolbarLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            toolbarLayout.TabIndex = 2;
            // 
            // statusComboBox
            // 
            statusComboBox.AccessibleName = "Loan status filter";
            statusComboBox.BorderColor = Color.FromArgb(128, 128, 128);
            statusComboBox.BorderRadius = 6;
            statusComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusComboBox.FillColor = Color.White;
            statusComboBox.FocusedColor = Color.FromArgb(57, 112, 41);
            statusComboBox.FocusedState.BorderColor = Color.FromArgb(57, 112, 41);
            statusComboBox.Font = new Font("Segoe UI", 10.5F);
            statusComboBox.ForeColor = Color.FromArgb(26, 26, 26);
            statusComboBox.ItemHeight = 34;
            statusComboBox.Items.AddRange(new object[] {
            "Status: All",
            "Status: Active",
            "Status: Overdue",
            "Status: Returned"});
            statusComboBox.Margin = new Padding(0, 0, 16, 0);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.SelectedIndex = 0;
            statusComboBox.Size = new Size(180, 40);
            statusComboBox.TabIndex = 0;
            // 
            // summaryLayout
            // 
            summaryLayout.Anchor = AnchorStyles.Left;
            summaryLayout.AutoSize = true;
            summaryLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            summaryLayout.Controls.Add(activeCountLabel);
            summaryLayout.Controls.Add(overdueCountLabel);
            summaryLayout.Controls.Add(returnedCountLabel);
            summaryLayout.FlowDirection = FlowDirection.LeftToRight;
            summaryLayout.Margin = new Padding(0);
            summaryLayout.Name = "summaryLayout";
            summaryLayout.TabIndex = 1;
            summaryLayout.WrapContents = false;
            // 
            // activeCountLabel
            // 
            activeCountLabel.AutoSize = true;
            activeCountLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            activeCountLabel.ForeColor = Color.FromArgb(30, 64, 175);
            activeCountLabel.Margin = new Padding(0, 0, 16, 0);
            activeCountLabel.Name = "activeCountLabel";
            activeCountLabel.TabIndex = 0;
            activeCountLabel.Text = "Active: —";
            // 
            // overdueCountLabel
            // 
            overdueCountLabel.AutoSize = true;
            overdueCountLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            overdueCountLabel.ForeColor = Color.FromArgb(153, 27, 27);
            overdueCountLabel.Margin = new Padding(0, 0, 16, 0);
            overdueCountLabel.Name = "overdueCountLabel";
            overdueCountLabel.TabIndex = 1;
            overdueCountLabel.Text = "Overdue: —";
            // 
            // returnedCountLabel
            // 
            returnedCountLabel.AutoSize = true;
            returnedCountLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            returnedCountLabel.ForeColor = Color.FromArgb(22, 101, 52);
            returnedCountLabel.Margin = new Padding(0);
            returnedCountLabel.Name = "returnedCountLabel";
            returnedCountLabel.TabIndex = 2;
            returnedCountLabel.Text = "Returned: —";
            // 
            // loansPanel
            // 
            loansPanel.BorderColor = Color.FromArgb(204, 204, 204);
            loansPanel.BorderRadius = 8;
            loansPanel.BorderThickness = 1;
            loansPanel.Controls.Add(loansLayout);
            loansPanel.Dock = DockStyle.Fill;
            loansPanel.FillColor = Color.White;
            loansPanel.Margin = new Padding(0);
            loansPanel.Name = "loansPanel";
            loansPanel.Padding = new Padding(16);
            loansPanel.Size = new Size(1000, 580);
            loansPanel.TabIndex = 3;
            // 
            // loansLayout
            // 
            loansLayout.BackColor = Color.White;
            loansLayout.ColumnCount = 1;
            loansLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            loansLayout.Controls.Add(loansGrid, 0, 0);
            loansLayout.Controls.Add(bottomBarLayout, 0, 1);
            loansLayout.Dock = DockStyle.Fill;
            loansLayout.Margin = new Padding(0);
            loansLayout.Name = "loansLayout";
            loansLayout.RowCount = 2;
            loansLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            loansLayout.RowStyles.Add(new RowStyle());
            loansLayout.TabIndex = 0;
            // 
            // loansGrid
            // 
            loansGrid.AccessibleName = "Student loans table";
            loansGrid.AccessibleDescription = "Design preview table showing borrowed books, due dates, and statuses.";
            loansGrid.AllowUserToAddRows = false;
            loansGrid.AllowUserToDeleteRows = false;
            loansGrid.AllowUserToResizeRows = false;
            alternateStyle.BackColor = Color.FromArgb(242, 242, 242);
            loansGrid.AlternatingRowsDefaultCellStyle = alternateStyle;
            loansGrid.AutoGenerateColumns = false;
            loansGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            loansGrid.BackgroundColor = Color.White;
            loansGrid.BorderStyle = BorderStyle.None;
            loansGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            loansGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(223, 241, 218);
            headerStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            headerStyle.ForeColor = Color.FromArgb(26, 26, 26);
            headerStyle.SelectionBackColor = Color.FromArgb(223, 241, 218);
            headerStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);
            headerStyle.WrapMode = DataGridViewTriState.True;
            loansGrid.ColumnHeadersDefaultCellStyle = headerStyle;
            loansGrid.ColumnHeadersHeight = 36;
            loansGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            loansGrid.Columns.AddRange(new DataGridViewColumn[] {
            bookColumn,
            borrowedColumn,
            dueColumn,
            returnedColumn,
            statusColumn});
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Segoe UI", 10F);
            cellStyle.ForeColor = Color.FromArgb(26, 26, 26);
            cellStyle.SelectionBackColor = Color.FromArgb(223, 241, 218);
            cellStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);
            cellStyle.WrapMode = DataGridViewTriState.False;
            loansGrid.DefaultCellStyle = cellStyle;
            loansGrid.Dock = DockStyle.Fill;
            loansGrid.EnableHeadersVisualStyles = false;
            loansGrid.GridColor = Color.FromArgb(204, 204, 204);
            loansGrid.Margin = new Padding(0);
            loansGrid.MultiSelect = false;
            loansGrid.Name = "loansGrid";
            loansGrid.ReadOnly = true;
            loansGrid.RowHeadersVisible = false;
            loansGrid.RowTemplate.Height = 40;
            loansGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            loansGrid.TabIndex = 0;
            // 
            // bookColumn
            // 
            bookColumn.FillWeight = 200F;
            bookColumn.HeaderText = "Book / Copy";
            bookColumn.MinimumWidth = 160;
            bookColumn.Name = "bookColumn";
            bookColumn.ReadOnly = true;
            // 
            // borrowedColumn
            // 
            borrowedColumn.FillWeight = 110F;
            borrowedColumn.HeaderText = "Borrowed";
            borrowedColumn.MinimumWidth = 100;
            borrowedColumn.Name = "borrowedColumn";
            borrowedColumn.ReadOnly = true;
            // 
            // dueColumn
            // 
            dueColumn.FillWeight = 110F;
            dueColumn.HeaderText = "Due";
            dueColumn.MinimumWidth = 100;
            dueColumn.Name = "dueColumn";
            dueColumn.ReadOnly = true;
            // 
            // returnedColumn
            // 
            returnedColumn.FillWeight = 110F;
            returnedColumn.HeaderText = "Returned";
            returnedColumn.MinimumWidth = 100;
            returnedColumn.Name = "returnedColumn";
            returnedColumn.ReadOnly = true;
            // 
            // statusColumn
            // 
            statusColumn.FillWeight = 100F;
            statusColumn.HeaderText = "Status";
            statusColumn.MinimumWidth = 90;
            statusColumn.Name = "statusColumn";
            statusColumn.ReadOnly = true;
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
            bottomBarLayout.TabIndex = 1;
            // 
            // noteLabel
            // 
            noteLabel.Anchor = AnchorStyles.Left;
            noteLabel.AutoSize = true;
            noteLabel.Font = new Font("Segoe UI", 9.5F);
            noteLabel.ForeColor = Color.FromArgb(102, 102, 102);
            noteLabel.Margin = new Padding(0);
            noteLabel.Name = "noteLabel";
            noteLabel.TabIndex = 0;
            noteLabel.Text = "Return books at librarian desk. Overdue = unreturned past due date.";
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
            previousButton.BorderColor = Color.FromArgb(128, 128, 128);
            previousButton.BorderRadius = 4;
            previousButton.BorderThickness = 1;
            previousButton.FillColor = Color.White;
            previousButton.Font = new Font("Segoe UI", 9F);
            previousButton.ForeColor = Color.FromArgb(26, 26, 26);
            previousButton.HoverState.FillColor = Color.FromArgb(223, 241, 218);
            previousButton.Margin = new Padding(0, 0, 4, 0);
            previousButton.Name = "previousButton";
            previousButton.Size = new Size(72, 28);
            previousButton.TabIndex = 0;
            previousButton.Text = "Previous";
            // 
            // pageNumberButton
            // 
            pageNumberButton.BorderColor = Color.FromArgb(57, 112, 41);
            pageNumberButton.BorderRadius = 4;
            pageNumberButton.BorderThickness = 1;
            pageNumberButton.FillColor = Color.FromArgb(223, 241, 218);
            pageNumberButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            pageNumberButton.ForeColor = Color.FromArgb(57, 112, 41);
            pageNumberButton.Margin = new Padding(0, 0, 4, 0);
            pageNumberButton.Name = "pageNumberButton";
            pageNumberButton.Size = new Size(32, 28);
            pageNumberButton.TabIndex = 1;
            pageNumberButton.Text = "1";
            // 
            // nextButton
            // 
            nextButton.BorderColor = Color.FromArgb(128, 128, 128);
            nextButton.BorderRadius = 4;
            nextButton.BorderThickness = 1;
            nextButton.FillColor = Color.White;
            nextButton.Font = new Font("Segoe UI", 9F);
            nextButton.ForeColor = Color.FromArgb(26, 26, 26);
            nextButton.HoverState.FillColor = Color.FromArgb(223, 241, 218);
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
            previewLabel.ForeColor = Color.FromArgb(102, 102, 102);
            previewLabel.Margin = new Padding(0, 12, 0, 0);
            previewLabel.Name = "previewLabel";
            previewLabel.TabIndex = 4;
            previewLabel.Text = "Design preview — no loan records loaded. Lending services are not connected.";
            // 
            // MyLoansPage
            // 
            AccessibleName = "My Loans";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(242, 242, 242);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(0);
            Name = "MyLoansPage";
            Size = new Size(1048, 800);
            pageLayout.ResumeLayout(false);
            pageLayout.PerformLayout();
            headerLayout.ResumeLayout(false);
            headerLayout.PerformLayout();
            toolbarLayout.ResumeLayout(false);
            toolbarLayout.PerformLayout();
            summaryLayout.ResumeLayout(false);
            summaryLayout.PerformLayout();
            loansPanel.ResumeLayout(false);
            loansLayout.ResumeLayout(false);
            loansLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)loansGrid).EndInit();
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
        private Guna.UI2.WinForms.Guna2ComboBox statusComboBox;
        private FlowLayoutPanel summaryLayout;
        private Label activeCountLabel;
        private Label overdueCountLabel;
        private Label returnedCountLabel;
        private Guna.UI2.WinForms.Guna2Panel loansPanel;
        private TableLayoutPanel loansLayout;
        private Guna.UI2.WinForms.Guna2DataGridView loansGrid;
        private DataGridViewTextBoxColumn bookColumn;
        private DataGridViewTextBoxColumn borrowedColumn;
        private DataGridViewTextBoxColumn dueColumn;
        private DataGridViewTextBoxColumn returnedColumn;
        private DataGridViewTextBoxColumn statusColumn;
        private TableLayoutPanel bottomBarLayout;
        private Label noteLabel;
        private FlowLayoutPanel paginationLayout;
        private Guna.UI2.WinForms.Guna2Button previousButton;
        private Guna.UI2.WinForms.Guna2Button pageNumberButton;
        private Guna.UI2.WinForms.Guna2Button nextButton;
        private Label previewLabel;
    }
}
