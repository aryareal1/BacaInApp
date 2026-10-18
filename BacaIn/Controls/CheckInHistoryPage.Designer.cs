namespace BacaIn
{
    partial class CheckInHistoryPage
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
            toolbarLayout = new FlowLayoutPanel();
            fromLayout = new TableLayoutPanel();
            fromLabel = new Label();
            fromDatePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            toLayout = new TableLayoutPanel();
            toLabel = new Label();
            toDatePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            actionsLayout = new FlowLayoutPanel();
            applyButton = new Guna.UI2.WinForms.Guna2Button();
            resetButton = new Guna.UI2.WinForms.Guna2Button();
            historyPanel = new Guna.UI2.WinForms.Guna2Panel();
            historyLayout = new TableLayoutPanel();
            summaryCountLabel = new Label();
            historyGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            dateColumn = new DataGridViewTextBoxColumn();
            timeColumn = new DataGridViewTextBoxColumn();
            bottomBarLayout = new TableLayoutPanel();
            notesLayout = new TableLayoutPanel();
            orderNoteLabel = new Label();
            emptyNoteLabel = new Label();
            paginationLayout = new FlowLayoutPanel();
            previousButton = new Guna.UI2.WinForms.Guna2Button();
            pageNumberButton = new Guna.UI2.WinForms.Guna2Button();
            nextButton = new Guna.UI2.WinForms.Guna2Button();
            previewLabel = new Label();
            pageLayout.SuspendLayout();
            headerLayout.SuspendLayout();
            toolbarLayout.SuspendLayout();
            fromLayout.SuspendLayout();
            toLayout.SuspendLayout();
            actionsLayout.SuspendLayout();
            historyPanel.SuspendLayout();
            historyLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)historyGrid).BeginInit();
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
            pageLayout.Controls.Add(historyPanel, 0, 3);
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
            headingLabel.Text = "View Check-in History";
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
            supportingLabel.Text = "View your physical library visit logs and entry timestamps.";
            // 
            // toolbarLayout
            // 
            toolbarLayout.AutoSize = true;
            toolbarLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            toolbarLayout.Controls.Add(fromLayout);
            toolbarLayout.Controls.Add(toLayout);
            toolbarLayout.Controls.Add(actionsLayout);
            toolbarLayout.Dock = DockStyle.Fill;
            toolbarLayout.Margin = new Padding(0, 0, 0, 16);
            toolbarLayout.Name = "toolbarLayout";
            toolbarLayout.TabIndex = 2;
            toolbarLayout.WrapContents = true;
            // 
            // fromLayout
            // 
            fromLayout.AutoSize = true;
            fromLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            fromLayout.ColumnCount = 1;
            fromLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            fromLayout.Controls.Add(fromLabel, 0, 0);
            fromLayout.Controls.Add(fromDatePicker, 0, 1);
            fromLayout.Margin = new Padding(0, 0, 16, 8);
            fromLayout.Name = "fromLayout";
            fromLayout.RowCount = 2;
            fromLayout.RowStyles.Add(new RowStyle());
            fromLayout.RowStyles.Add(new RowStyle());
            fromLayout.TabIndex = 0;
            // 
            // fromLabel
            // 
            fromLabel.AutoSize = true;
            fromLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            fromLabel.ForeColor = Color.FromArgb(36, 51, 46);
            fromLabel.Margin = new Padding(0, 0, 0, 6);
            fromLabel.Name = "fromLabel";
            fromLabel.TabIndex = 0;
            fromLabel.Text = "From";
            // 
            // fromDatePicker
            // 
            fromDatePicker.AccessibleName = "From date";
            fromDatePicker.BorderColor = Color.FromArgb(120, 135, 126);
            fromDatePicker.BorderRadius = 6;
            fromDatePicker.BorderThickness = 1;
            fromDatePicker.CustomFormat = "dd MMM yyyy";
            fromDatePicker.FillColor = Color.White;
            fromDatePicker.FocusedColor = Color.FromArgb(47, 93, 80);
            fromDatePicker.Font = new Font("Segoe UI", 10F);
            fromDatePicker.ForeColor = Color.FromArgb(36, 51, 46);
            fromDatePicker.Format = DateTimePickerFormat.Custom;
            fromDatePicker.Margin = new Padding(0);
            fromDatePicker.Name = "fromDatePicker";
            fromDatePicker.Size = new Size(160, 40);
            fromDatePicker.TabIndex = 1;
            fromDatePicker.Value = new DateTime(2026, 10, 1);
            // 
            // toLayout
            // 
            toLayout.AutoSize = true;
            toLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            toLayout.ColumnCount = 1;
            toLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            toLayout.Controls.Add(toLabel, 0, 0);
            toLayout.Controls.Add(toDatePicker, 0, 1);
            toLayout.Margin = new Padding(0, 0, 16, 8);
            toLayout.Name = "toLayout";
            toLayout.RowCount = 2;
            toLayout.RowStyles.Add(new RowStyle());
            toLayout.RowStyles.Add(new RowStyle());
            toLayout.TabIndex = 1;
            // 
            // toLabel
            // 
            toLabel.AutoSize = true;
            toLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            toLabel.ForeColor = Color.FromArgb(36, 51, 46);
            toLabel.Margin = new Padding(0, 0, 0, 6);
            toLabel.Name = "toLabel";
            toLabel.TabIndex = 0;
            toLabel.Text = "To";
            // 
            // toDatePicker
            // 
            toDatePicker.AccessibleName = "To date";
            toDatePicker.BorderColor = Color.FromArgb(120, 135, 126);
            toDatePicker.BorderRadius = 6;
            toDatePicker.BorderThickness = 1;
            toDatePicker.CustomFormat = "dd MMM yyyy";
            toDatePicker.FillColor = Color.White;
            toDatePicker.FocusedColor = Color.FromArgb(47, 93, 80);
            toDatePicker.Font = new Font("Segoe UI", 10F);
            toDatePicker.ForeColor = Color.FromArgb(36, 51, 46);
            toDatePicker.Format = DateTimePickerFormat.Custom;
            toDatePicker.Margin = new Padding(0);
            toDatePicker.Name = "toDatePicker";
            toDatePicker.Size = new Size(160, 40);
            toDatePicker.TabIndex = 1;
            toDatePicker.Value = new DateTime(2026, 10, 18);
            // 
            // actionsLayout
            // 
            actionsLayout.AutoSize = true;
            actionsLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            actionsLayout.Controls.Add(applyButton);
            actionsLayout.Controls.Add(resetButton);
            actionsLayout.FlowDirection = FlowDirection.LeftToRight;
            actionsLayout.Margin = new Padding(0, 24, 0, 8);
            actionsLayout.Name = "actionsLayout";
            actionsLayout.TabIndex = 2;
            actionsLayout.WrapContents = false;
            // 
            // applyButton
            // 
            applyButton.AccessibleName = "Apply filter";
            applyButton.AccessibleDescription = "Design preview action. Date filter is not connected.";
            applyButton.BorderColor = Color.FromArgb(47, 93, 80);
            applyButton.BorderRadius = 6;
            applyButton.BorderThickness = 1;
            applyButton.FillColor = Color.FromArgb(47, 93, 80);
            applyButton.FocusedColor = Color.FromArgb(36, 72, 62);
            applyButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            applyButton.ForeColor = Color.White;
            applyButton.HoverState.FillColor = Color.FromArgb(36, 72, 62);
            applyButton.Margin = new Padding(0, 0, 8, 0);
            applyButton.Name = "applyButton";
            applyButton.PressedColor = Color.FromArgb(36, 72, 62);
            applyButton.Size = new Size(88, 40);
            applyButton.TabIndex = 0;
            applyButton.Text = "Apply";
            // 
            // resetButton
            // 
            resetButton.AccessibleName = "Reset filter";
            resetButton.AccessibleDescription = "Design preview action. Reset filter is not connected.";
            resetButton.BorderColor = Color.FromArgb(120, 135, 126);
            resetButton.BorderRadius = 6;
            resetButton.BorderThickness = 1;
            resetButton.FillColor = Color.White;
            resetButton.FocusedColor = Color.FromArgb(47, 93, 80);
            resetButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            resetButton.ForeColor = Color.FromArgb(36, 51, 46);
            resetButton.HoverState.BorderColor = Color.FromArgb(47, 93, 80);
            resetButton.HoverState.FillColor = Color.FromArgb(229, 239, 232);
            resetButton.Margin = new Padding(0);
            resetButton.Name = "resetButton";
            resetButton.PressedColor = Color.FromArgb(36, 72, 62);
            resetButton.Size = new Size(88, 40);
            resetButton.TabIndex = 1;
            resetButton.Text = "Reset";
            // 
            // historyPanel
            // 
            historyPanel.BorderColor = Color.FromArgb(216, 223, 216);
            historyPanel.BorderRadius = 8;
            historyPanel.BorderThickness = 1;
            historyPanel.Controls.Add(historyLayout);
            historyPanel.Dock = DockStyle.Fill;
            historyPanel.FillColor = Color.White;
            historyPanel.Margin = new Padding(0);
            historyPanel.Name = "historyPanel";
            historyPanel.Padding = new Padding(16);
            historyPanel.Size = new Size(1000, 580);
            historyPanel.TabIndex = 3;
            // 
            // historyLayout
            // 
            historyLayout.BackColor = Color.White;
            historyLayout.ColumnCount = 1;
            historyLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            historyLayout.Controls.Add(summaryCountLabel, 0, 0);
            historyLayout.Controls.Add(historyGrid, 0, 1);
            historyLayout.Controls.Add(bottomBarLayout, 0, 2);
            historyLayout.Dock = DockStyle.Fill;
            historyLayout.Margin = new Padding(0);
            historyLayout.Name = "historyLayout";
            historyLayout.RowCount = 3;
            historyLayout.RowStyles.Add(new RowStyle());
            historyLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            historyLayout.RowStyles.Add(new RowStyle());
            historyLayout.TabIndex = 0;
            // 
            // summaryCountLabel
            // 
            summaryCountLabel.AutoSize = true;
            summaryCountLabel.Dock = DockStyle.Fill;
            summaryCountLabel.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            summaryCountLabel.ForeColor = Color.FromArgb(36, 51, 46);
            summaryCountLabel.Margin = new Padding(0, 0, 0, 12);
            summaryCountLabel.Name = "summaryCountLabel";
            summaryCountLabel.TabIndex = 0;
            summaryCountLabel.Text = "Visits in selected period: —";
            // 
            // historyGrid
            // 
            historyGrid.AccessibleName = "Check-in history table";
            historyGrid.AccessibleDescription = "Design preview table showing library visits and check-in times.";
            historyGrid.AllowUserToAddRows = false;
            historyGrid.AllowUserToDeleteRows = false;
            historyGrid.AllowUserToResizeRows = false;
            alternateStyle.BackColor = Color.FromArgb(247, 248, 244);
            historyGrid.AlternatingRowsDefaultCellStyle = alternateStyle;
            historyGrid.AutoGenerateColumns = false;
            historyGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            historyGrid.BackgroundColor = Color.White;
            historyGrid.BorderStyle = BorderStyle.None;
            historyGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            historyGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(229, 239, 232);
            headerStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            headerStyle.ForeColor = Color.FromArgb(36, 51, 46);
            headerStyle.SelectionBackColor = Color.FromArgb(229, 239, 232);
            headerStyle.SelectionForeColor = Color.FromArgb(36, 51, 46);
            headerStyle.WrapMode = DataGridViewTriState.True;
            historyGrid.ColumnHeadersDefaultCellStyle = headerStyle;
            historyGrid.ColumnHeadersHeight = 36;
            historyGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            historyGrid.Columns.AddRange(new DataGridViewColumn[] {
            dateColumn,
            timeColumn});
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Segoe UI", 10F);
            cellStyle.ForeColor = Color.FromArgb(36, 51, 46);
            cellStyle.SelectionBackColor = Color.FromArgb(229, 239, 232);
            cellStyle.SelectionForeColor = Color.FromArgb(36, 51, 46);
            cellStyle.WrapMode = DataGridViewTriState.False;
            historyGrid.DefaultCellStyle = cellStyle;
            historyGrid.Dock = DockStyle.Fill;
            historyGrid.EnableHeadersVisualStyles = false;
            historyGrid.GridColor = Color.FromArgb(216, 223, 216);
            historyGrid.Margin = new Padding(0);
            historyGrid.MultiSelect = false;
            historyGrid.Name = "historyGrid";
            historyGrid.ReadOnly = true;
            historyGrid.RowHeadersVisible = false;
            historyGrid.RowTemplate.Height = 40;
            historyGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            historyGrid.TabIndex = 1;
            // 
            // dateColumn
            // 
            dateColumn.FillWeight = 150F;
            dateColumn.HeaderText = "Date";
            dateColumn.MinimumWidth = 120;
            dateColumn.Name = "dateColumn";
            dateColumn.ReadOnly = true;
            // 
            // timeColumn
            // 
            timeColumn.FillWeight = 150F;
            timeColumn.HeaderText = "Check-in Time";
            timeColumn.MinimumWidth = 120;
            timeColumn.Name = "timeColumn";
            timeColumn.ReadOnly = true;
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
            bottomBarLayout.TabIndex = 2;
            // 
            // notesLayout
            // 
            notesLayout.AutoSize = true;
            notesLayout.ColumnCount = 1;
            notesLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            notesLayout.Controls.Add(orderNoteLabel, 0, 0);
            notesLayout.Controls.Add(emptyNoteLabel, 0, 1);
            notesLayout.Dock = DockStyle.Fill;
            notesLayout.Margin = new Padding(0);
            notesLayout.Name = "notesLayout";
            notesLayout.RowCount = 2;
            notesLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            notesLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            notesLayout.TabIndex = 0;
            // 
            // orderNoteLabel
            // 
            orderNoteLabel.AutoSize = true;
            orderNoteLabel.Font = new Font("Segoe UI", 9.5F);
            orderNoteLabel.ForeColor = Color.FromArgb(95, 111, 103);
            orderNoteLabel.Margin = new Padding(0, 0, 0, 4);
            orderNoteLabel.Name = "orderNoteLabel";
            orderNoteLabel.TabIndex = 0;
            orderNoteLabel.Text = "Newest first. Times shown in library local time.";
            // 
            // emptyNoteLabel
            // 
            emptyNoteLabel.AutoSize = true;
            emptyNoteLabel.Font = new Font("Segoe UI", 9.5F);
            emptyNoteLabel.ForeColor = Color.FromArgb(95, 111, 103);
            emptyNoteLabel.Margin = new Padding(0);
            emptyNoteLabel.Name = "emptyNoteLabel";
            emptyNoteLabel.TabIndex = 1;
            emptyNoteLabel.Text = "No visits: show “No check-ins in selected period”.";
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
            previewLabel.Text = "Design preview — no check-in records loaded. Attendance tracking is not connected.";
            // 
            // CheckInHistoryPage
            // 
            AccessibleName = "Check-in History";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(247, 248, 244);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(0);
            Name = "CheckInHistoryPage";
            Size = new Size(1048, 800);
            pageLayout.ResumeLayout(false);
            pageLayout.PerformLayout();
            headerLayout.ResumeLayout(false);
            headerLayout.PerformLayout();
            toolbarLayout.ResumeLayout(false);
            toolbarLayout.PerformLayout();
            fromLayout.ResumeLayout(false);
            fromLayout.PerformLayout();
            toLayout.ResumeLayout(false);
            toLayout.PerformLayout();
            actionsLayout.ResumeLayout(false);
            historyPanel.ResumeLayout(false);
            historyLayout.ResumeLayout(false);
            historyLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)historyGrid).EndInit();
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
        private FlowLayoutPanel toolbarLayout;
        private TableLayoutPanel fromLayout;
        private Label fromLabel;
        private Guna.UI2.WinForms.Guna2DateTimePicker fromDatePicker;
        private TableLayoutPanel toLayout;
        private Label toLabel;
        private Guna.UI2.WinForms.Guna2DateTimePicker toDatePicker;
        private FlowLayoutPanel actionsLayout;
        private Guna.UI2.WinForms.Guna2Button applyButton;
        private Guna.UI2.WinForms.Guna2Button resetButton;
        private Guna.UI2.WinForms.Guna2Panel historyPanel;
        private TableLayoutPanel historyLayout;
        private Label summaryCountLabel;
        private Guna.UI2.WinForms.Guna2DataGridView historyGrid;
        private DataGridViewTextBoxColumn dateColumn;
        private DataGridViewTextBoxColumn timeColumn;
        private TableLayoutPanel bottomBarLayout;
        private TableLayoutPanel notesLayout;
        private Label orderNoteLabel;
        private Label emptyNoteLabel;
        private FlowLayoutPanel paginationLayout;
        private Guna.UI2.WinForms.Guna2Button previousButton;
        private Guna.UI2.WinForms.Guna2Button pageNumberButton;
        private Guna.UI2.WinForms.Guna2Button nextButton;
        private Label previewLabel;
    }
}
