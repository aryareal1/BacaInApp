namespace BacaIn
{
    partial class MyReservationsPage
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
            statusComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            summaryLayout = new FlowLayoutPanel();
            pendingCountLabel = new Label();
            readyCountLabel = new Label();
            reservationsPanel = new Guna.UI2.WinForms.Guna2Panel();
            reservationsLayout = new TableLayoutPanel();
            reservationsGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            bookColumn = new DataGridViewTextBoxColumn();
            reservedDateColumn = new DataGridViewTextBoxColumn();
            statusColumn = new DataGridViewTextBoxColumn();
            queueColumn = new DataGridViewTextBoxColumn();
            actionColumn = new DataGridViewButtonColumn();
            bottomBarLayout = new TableLayoutPanel();
            notesLayout = new TableLayoutPanel();
            readyNoteLabel = new Label();
            cancelNoteLabel = new Label();
            paginationLayout = new FlowLayoutPanel();
            previousButton = new Guna.UI2.WinForms.Guna2Button();
            pageNumberButton = new Guna.UI2.WinForms.Guna2Button();
            nextButton = new Guna.UI2.WinForms.Guna2Button();
            previewLabel = new Label();
            pageLayout.SuspendLayout();
            headerLayout.SuspendLayout();
            toolbarLayout.SuspendLayout();
            summaryLayout.SuspendLayout();
            reservationsPanel.SuspendLayout();
            reservationsLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)reservationsGrid).BeginInit();
            bottomBarLayout.SuspendLayout();
            notesLayout.SuspendLayout();
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
            pageLayout.Controls.Add(reservationsPanel, 0, 3);
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
            headingLabel.Text = "View My Reservations";
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
            supportingLabel.Text = "Track reserve requests, ready notifications, and queue statuses.";
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
            statusComboBox.AccessibleName = "Reservation status filter";
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
            "Status: Pending",
            "Status: Ready",
            "Status: Fulfilled",
            "Status: Cancelled",
            "Status: Expired"});
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
            summaryLayout.Controls.Add(pendingCountLabel);
            summaryLayout.Controls.Add(readyCountLabel);
            summaryLayout.FlowDirection = FlowDirection.LeftToRight;
            summaryLayout.Margin = new Padding(0);
            summaryLayout.Name = "summaryLayout";
            summaryLayout.TabIndex = 1;
            summaryLayout.WrapContents = false;
            // 
            // pendingCountLabel
            // 
            pendingCountLabel.AutoSize = true;
            pendingCountLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            pendingCountLabel.ForeColor = Color.FromArgb(146, 64, 14);
            pendingCountLabel.Margin = new Padding(0, 0, 16, 0);
            pendingCountLabel.Name = "pendingCountLabel";
            pendingCountLabel.TabIndex = 0;
            pendingCountLabel.Text = "Pending: —";
            // 
            // readyCountLabel
            // 
            readyCountLabel.AutoSize = true;
            readyCountLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            readyCountLabel.ForeColor = Color.FromArgb(22, 101, 52);
            readyCountLabel.Margin = new Padding(0);
            readyCountLabel.Name = "readyCountLabel";
            readyCountLabel.TabIndex = 1;
            readyCountLabel.Text = "Ready: —";
            // 
            // reservationsPanel
            // 
            reservationsPanel.BorderColor = Color.FromArgb(204, 204, 204);
            reservationsPanel.BorderRadius = 8;
            reservationsPanel.BorderThickness = 1;
            reservationsPanel.Controls.Add(reservationsLayout);
            reservationsPanel.Dock = DockStyle.Fill;
            reservationsPanel.FillColor = Color.White;
            reservationsPanel.Margin = new Padding(0);
            reservationsPanel.Name = "reservationsPanel";
            reservationsPanel.Padding = new Padding(16);
            reservationsPanel.Size = new Size(1000, 580);
            reservationsPanel.TabIndex = 3;
            // 
            // reservationsLayout
            // 
            reservationsLayout.BackColor = Color.White;
            reservationsLayout.ColumnCount = 1;
            reservationsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            reservationsLayout.Controls.Add(reservationsGrid, 0, 0);
            reservationsLayout.Controls.Add(bottomBarLayout, 0, 1);
            reservationsLayout.Dock = DockStyle.Fill;
            reservationsLayout.Margin = new Padding(0);
            reservationsLayout.Name = "reservationsLayout";
            reservationsLayout.RowCount = 2;
            reservationsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            reservationsLayout.RowStyles.Add(new RowStyle());
            reservationsLayout.TabIndex = 0;
            // 
            // reservationsGrid
            // 
            reservationsGrid.AccessibleName = "Reservations table";
            reservationsGrid.AccessibleDescription = "Design preview table showing reserved books, status, queue, and cancel actions.";
            reservationsGrid.AllowUserToAddRows = false;
            reservationsGrid.AllowUserToDeleteRows = false;
            reservationsGrid.AllowUserToResizeRows = false;
            alternateStyle.BackColor = Color.FromArgb(242, 242, 242);
            reservationsGrid.AlternatingRowsDefaultCellStyle = alternateStyle;
            reservationsGrid.AutoGenerateColumns = false;
            reservationsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            reservationsGrid.BackgroundColor = Color.White;
            reservationsGrid.BorderStyle = BorderStyle.None;
            reservationsGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            reservationsGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(223, 241, 218);
            headerStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            headerStyle.ForeColor = Color.FromArgb(26, 26, 26);
            headerStyle.SelectionBackColor = Color.FromArgb(223, 241, 218);
            headerStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);
            headerStyle.WrapMode = DataGridViewTriState.True;
            reservationsGrid.ColumnHeadersDefaultCellStyle = headerStyle;
            reservationsGrid.ColumnHeadersHeight = 36;
            reservationsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            reservationsGrid.Columns.AddRange(new DataGridViewColumn[] {
            bookColumn,
            reservedDateColumn,
            statusColumn,
            queueColumn,
            actionColumn});
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Segoe UI", 10F);
            cellStyle.ForeColor = Color.FromArgb(26, 26, 26);
            cellStyle.SelectionBackColor = Color.FromArgb(223, 241, 218);
            cellStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);
            cellStyle.WrapMode = DataGridViewTriState.False;
            reservationsGrid.DefaultCellStyle = cellStyle;
            reservationsGrid.Dock = DockStyle.Fill;
            reservationsGrid.EnableHeadersVisualStyles = false;
            reservationsGrid.GridColor = Color.FromArgb(204, 204, 204);
            reservationsGrid.Margin = new Padding(0);
            reservationsGrid.MultiSelect = false;
            reservationsGrid.Name = "reservationsGrid";
            reservationsGrid.ReadOnly = true;
            reservationsGrid.RowHeadersVisible = false;
            reservationsGrid.RowTemplate.Height = 40;
            reservationsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            reservationsGrid.TabIndex = 0;
            // 
            // bookColumn
            // 
            bookColumn.FillWeight = 200F;
            bookColumn.HeaderText = "Book Title";
            bookColumn.MinimumWidth = 160;
            bookColumn.Name = "bookColumn";
            bookColumn.ReadOnly = true;
            // 
            // reservedDateColumn
            // 
            reservedDateColumn.FillWeight = 110F;
            reservedDateColumn.HeaderText = "Reserved";
            reservedDateColumn.MinimumWidth = 100;
            reservedDateColumn.Name = "reservedDateColumn";
            reservedDateColumn.ReadOnly = true;
            // 
            // statusColumn
            // 
            statusColumn.FillWeight = 100F;
            statusColumn.HeaderText = "Status";
            statusColumn.MinimumWidth = 90;
            statusColumn.Name = "statusColumn";
            statusColumn.ReadOnly = true;
            // 
            // queueColumn
            // 
            queueColumn.FillWeight = 70F;
            queueColumn.HeaderText = "Queue";
            queueColumn.MinimumWidth = 60;
            queueColumn.Name = "queueColumn";
            queueColumn.ReadOnly = true;
            // 
            // actionColumn
            // 
            actionColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            actionStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            actionStyle.ForeColor = Color.FromArgb(153, 27, 27);
            actionStyle.SelectionForeColor = Color.FromArgb(153, 27, 27);
            actionColumn.DefaultCellStyle = actionStyle;
            actionColumn.FlatStyle = FlatStyle.Standard;
            actionColumn.HeaderText = "Action";
            actionColumn.MinimumWidth = 100;
            actionColumn.Name = "actionColumn";
            actionColumn.ReadOnly = true;
            actionColumn.Text = "Cancel";
            actionColumn.UseColumnTextForButtonValue = true;
            actionColumn.Width = 100;
            // 
            // bottomBarLayout
            // 
            bottomBarLayout.AutoSize = true;
            bottomBarLayout.ColumnCount = 2;
            bottomBarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bottomBarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            bottomBarLayout.Controls.Add(notesLayout, 0, 0);
            bottomBarLayout.Controls.Add(paginationLayout, 1, 0);
            bottomBarLayout.Dock = DockStyle.Fill;
            bottomBarLayout.Margin = new Padding(0, 16, 0, 0);
            bottomBarLayout.Name = "bottomBarLayout";
            bottomBarLayout.RowCount = 1;
            bottomBarLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            bottomBarLayout.TabIndex = 1;
            // 
            // notesLayout
            // 
            notesLayout.AutoSize = true;
            notesLayout.ColumnCount = 1;
            notesLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            notesLayout.Controls.Add(readyNoteLabel, 0, 0);
            notesLayout.Controls.Add(cancelNoteLabel, 0, 1);
            notesLayout.Dock = DockStyle.Fill;
            notesLayout.Margin = new Padding(0);
            notesLayout.Name = "notesLayout";
            notesLayout.RowCount = 2;
            notesLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            notesLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            notesLayout.TabIndex = 0;
            // 
            // readyNoteLabel
            // 
            readyNoteLabel.AutoSize = true;
            readyNoteLabel.Font = new Font("Segoe UI", 9.5F);
            readyNoteLabel.ForeColor = Color.FromArgb(102, 102, 102);
            readyNoteLabel.Margin = new Padding(0, 0, 0, 4);
            readyNoteLabel.Name = "readyNoteLabel";
            readyNoteLabel.TabIndex = 0;
            readyNoteLabel.Text = "Ready: collect at librarian desk before reservation expires.";
            // 
            // cancelNoteLabel
            // 
            cancelNoteLabel.AutoSize = true;
            cancelNoteLabel.Font = new Font("Segoe UI", 9.5F);
            cancelNoteLabel.ForeColor = Color.FromArgb(102, 102, 102);
            cancelNoteLabel.Margin = new Padding(0);
            cancelNoteLabel.Name = "cancelNoteLabel";
            cancelNoteLabel.TabIndex = 1;
            cancelNoteLabel.Text = "Cancel opens confirmation: Keep Reservation / Confirm Cancel.";
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
            previewLabel.Text = "Design preview — no reservation records loaded. Reservation services are not connected.";
            // 
            // MyReservationsPage
            // 
            AccessibleName = "My Reservations";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(242, 242, 242);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(0);
            Name = "MyReservationsPage";
            Size = new Size(1048, 800);
            pageLayout.ResumeLayout(false);
            pageLayout.PerformLayout();
            headerLayout.ResumeLayout(false);
            headerLayout.PerformLayout();
            toolbarLayout.ResumeLayout(false);
            toolbarLayout.PerformLayout();
            summaryLayout.ResumeLayout(false);
            summaryLayout.PerformLayout();
            reservationsPanel.ResumeLayout(false);
            reservationsLayout.ResumeLayout(false);
            reservationsLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)reservationsGrid).EndInit();
            bottomBarLayout.ResumeLayout(false);
            bottomBarLayout.PerformLayout();
            notesLayout.ResumeLayout(false);
            notesLayout.PerformLayout();
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
        private Label pendingCountLabel;
        private Label readyCountLabel;
        private Guna.UI2.WinForms.Guna2Panel reservationsPanel;
        private TableLayoutPanel reservationsLayout;
        private Guna.UI2.WinForms.Guna2DataGridView reservationsGrid;
        private DataGridViewTextBoxColumn bookColumn;
        private DataGridViewTextBoxColumn reservedDateColumn;
        private DataGridViewTextBoxColumn statusColumn;
        private DataGridViewTextBoxColumn queueColumn;
        private DataGridViewButtonColumn actionColumn;
        private TableLayoutPanel bottomBarLayout;
        private TableLayoutPanel notesLayout;
        private Label readyNoteLabel;
        private Label cancelNoteLabel;
        private FlowLayoutPanel paginationLayout;
        private Guna.UI2.WinForms.Guna2Button previousButton;
        private Guna.UI2.WinForms.Guna2Button pageNumberButton;
        private Guna.UI2.WinForms.Guna2Button nextButton;
        private Label previewLabel;
    }
}
