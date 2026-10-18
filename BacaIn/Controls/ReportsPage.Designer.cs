namespace BacaIn
{
    partial class ReportsPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pageLayout = new TableLayoutPanel();
            headingLabel = new Label();
            previewLabel = new Label();
            filtersLayout = new FlowLayoutPanel();
            reportTypeLayout = new TableLayoutPanel();
            reportTypeLabel = new Label();
            reportTypeComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            fromLayout = new TableLayoutPanel();
            fromLabel = new Label();
            fromDatePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            toLayout = new TableLayoutPanel();
            toLabel = new Label();
            toDatePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            actionsLayout = new FlowLayoutPanel();
            applyButton = new Guna.UI2.WinForms.Guna2Button();
            printButton = new Guna.UI2.WinForms.Guna2Button();
            summaryLayout = new FlowLayoutPanel();
            loansCard = new Guna.UI2.WinForms.Guna2Panel();
            loansLayout = new TableLayoutPanel();
            loansLabel = new Label();
            loansValueLabel = new Label();
            returnsCard = new Guna.UI2.WinForms.Guna2Panel();
            returnsLayout = new TableLayoutPanel();
            returnsLabel = new Label();
            returnsValueLabel = new Label();
            overdueCard = new Guna.UI2.WinForms.Guna2Panel();
            overdueLayout = new TableLayoutPanel();
            overdueLabel = new Label();
            overdueValueLabel = new Label();
            periodNoteLabel = new Label();
            tableHeadingLabel = new Label();
            reportGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            bookTitleColumn = new DataGridViewTextBoxColumn();
            loansIssuedColumn = new DataGridViewTextBoxColumn();
            returnsColumn = new DataGridViewTextBoxColumn();
            totalsLayout = new FlowLayoutPanel();
            totalLabel = new Label();
            totalLoansLabel = new Label();
            totalReturnsLabel = new Label();
            headerStyle = new DataGridViewCellStyle();
            rowStyle = new DataGridViewCellStyle();
            alternateStyle = new DataGridViewCellStyle();
            ((System.ComponentModel.ISupportInitialize)reportGrid).BeginInit();
            pageLayout.SuspendLayout();
            filtersLayout.SuspendLayout();
            reportTypeLayout.SuspendLayout();
            fromLayout.SuspendLayout();
            toLayout.SuspendLayout();
            actionsLayout.SuspendLayout();
            summaryLayout.SuspendLayout();
            loansCard.SuspendLayout();
            loansLayout.SuspendLayout();
            returnsCard.SuspendLayout();
            returnsLayout.SuspendLayout();
            overdueCard.SuspendLayout();
            overdueLayout.SuspendLayout();
            totalsLayout.SuspendLayout();
            SuspendLayout();
            // pageLayout
            pageLayout.AutoScroll = true;
            pageLayout.ColumnCount = 1;
            pageLayout.Dock = DockStyle.Fill;
            pageLayout.Padding = new Padding(24);
            pageLayout.Margin = new Padding(0);
            pageLayout.RowCount = 8;
            pageLayout.TabIndex = 0;
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.Controls.Add(headingLabel, 0, 0);
            pageLayout.Controls.Add(previewLabel, 0, 1);
            pageLayout.Controls.Add(filtersLayout, 0, 2);
            pageLayout.Controls.Add(summaryLayout, 0, 3);
            pageLayout.Controls.Add(periodNoteLabel, 0, 4);
            pageLayout.Controls.Add(tableHeadingLabel, 0, 5);
            pageLayout.Controls.Add(reportGrid, 0, 6);
            pageLayout.Controls.Add(totalsLayout, 0, 7);
            pageLayout.RowStyles.Add(new RowStyle());
            pageLayout.RowStyles.Add(new RowStyle());
            pageLayout.RowStyles.Add(new RowStyle());
            pageLayout.RowStyles.Add(new RowStyle());
            pageLayout.RowStyles.Add(new RowStyle());
            pageLayout.RowStyles.Add(new RowStyle());
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pageLayout.RowStyles.Add(new RowStyle());
            // headingLabel
            headingLabel.AutoSize = true;
            headingLabel.Dock = DockStyle.Fill;
            headingLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            headingLabel.ForeColor = Color.FromArgb(36, 51, 46);
            headingLabel.Margin = new Padding(0, 0, 0, 16);
            headingLabel.Text = "View Reports";
            // previewLabel
            previewLabel.AutoSize = true;
            previewLabel.Dock = DockStyle.Fill;
            previewLabel.Font = new Font("Segoe UI", 10.5F);
            previewLabel.ForeColor = Color.FromArgb(95, 111, 103);
            previewLabel.Margin = new Padding(0, 0, 0, 16);
            previewLabel.Text = "Design preview — report generation and printing are not connected. Report type and dates are layout controls only; this empty Loans & Returns preview does not change.";
            previewLabel.UseMnemonic = false;
            // periodNoteLabel
            periodNoteLabel.AutoSize = true;
            periodNoteLabel.Dock = DockStyle.Fill;
            periodNoteLabel.Font = new Font("Segoe UI", 10F);
            periodNoteLabel.ForeColor = Color.FromArgb(95, 111, 103);
            periodNoteLabel.Margin = new Padding(0, 0, 0, 16);
            periodNoteLabel.Text = "Loans issued and returns are period totals. Overdue now is a current count, independent of the selected period. No values are connected.";
            // tableHeadingLabel
            tableHeadingLabel.AutoSize = true;
            tableHeadingLabel.Dock = DockStyle.Fill;
            tableHeadingLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            tableHeadingLabel.ForeColor = Color.FromArgb(36, 51, 46);
            tableHeadingLabel.Margin = new Padding(0, 0, 0, 16);
            tableHeadingLabel.Text = "Loans & Returns preview";
            tableHeadingLabel.UseMnemonic = false;
            // filtersLayout
            filtersLayout.AutoSize = true;
            filtersLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            filtersLayout.Dock = DockStyle.Fill;
            filtersLayout.Margin = new Padding(0, 0, 0, 16);
            filtersLayout.WrapContents = true;
            filtersLayout.TabIndex = 0;
            filtersLayout.Controls.Add(reportTypeLayout);
            // reportTypeLayout
            reportTypeLayout.AutoSize = true;
            reportTypeLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            reportTypeLayout.ColumnCount = 1;
            reportTypeLayout.RowCount = 2;
            reportTypeLayout.Margin = new Padding(0, 0, 16, 8);
            reportTypeLayout.Size = new Size(230, 72);
            reportTypeLayout.TabIndex = 0;
            reportTypeLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            reportTypeLayout.RowStyles.Add(new RowStyle());
            reportTypeLayout.RowStyles.Add(new RowStyle());
            reportTypeLayout.Controls.Add(reportTypeLabel, 0, 0);
            reportTypeLayout.Controls.Add(reportTypeComboBox, 0, 1);
            // reportTypeLabel
            reportTypeLabel.AutoSize = true;
            reportTypeLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            reportTypeLabel.Margin = new Padding(0, 0, 0, 8);
            reportTypeLabel.Text = "Report type";
            // reportTypeComboBox
            reportTypeComboBox.AccessibleName = "Report type";
            reportTypeComboBox.BorderColor = Color.FromArgb(120, 135, 126);
            reportTypeComboBox.BorderRadius = 6;
            reportTypeComboBox.FillColor = Color.White;
            reportTypeComboBox.Font = new Font("Segoe UI", 10.5F);
            reportTypeComboBox.ForeColor = Color.FromArgb(36, 51, 46);
            reportTypeComboBox.Margin = new Padding(0);
            reportTypeComboBox.Size = new Size(230, 40);
            reportTypeComboBox.TabIndex = 0;
            filtersLayout.Controls.Add(fromLayout);
            // fromLayout
            fromLayout.AutoSize = true;
            fromLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            fromLayout.ColumnCount = 1;
            fromLayout.RowCount = 2;
            fromLayout.Margin = new Padding(0, 0, 16, 8);
            fromLayout.Size = new Size(180, 72);
            fromLayout.TabIndex = 1;
            fromLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            fromLayout.RowStyles.Add(new RowStyle());
            fromLayout.RowStyles.Add(new RowStyle());
            fromLayout.Controls.Add(fromLabel, 0, 0);
            fromLayout.Controls.Add(fromDatePicker, 0, 1);
            // fromLabel
            fromLabel.AutoSize = true;
            fromLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            fromLabel.Margin = new Padding(0, 0, 0, 8);
            fromLabel.Text = "From";
            // fromDatePicker
            fromDatePicker.AccessibleName = "From";
            fromDatePicker.BorderColor = Color.FromArgb(120, 135, 126);
            fromDatePicker.BorderRadius = 6;
            fromDatePicker.FillColor = Color.White;
            fromDatePicker.Font = new Font("Segoe UI", 10.5F);
            fromDatePicker.ForeColor = Color.FromArgb(36, 51, 46);
            fromDatePicker.Margin = new Padding(0);
            fromDatePicker.Size = new Size(180, 40);
            fromDatePicker.TabIndex = 0;
            filtersLayout.Controls.Add(toLayout);
            // toLayout
            toLayout.AutoSize = true;
            toLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            toLayout.ColumnCount = 1;
            toLayout.RowCount = 2;
            toLayout.Margin = new Padding(0, 0, 16, 8);
            toLayout.Size = new Size(180, 72);
            toLayout.TabIndex = 2;
            toLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            toLayout.RowStyles.Add(new RowStyle());
            toLayout.RowStyles.Add(new RowStyle());
            toLayout.Controls.Add(toLabel, 0, 0);
            toLayout.Controls.Add(toDatePicker, 0, 1);
            // toLabel
            toLabel.AutoSize = true;
            toLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            toLabel.Margin = new Padding(0, 0, 0, 8);
            toLabel.Text = "To";
            // toDatePicker
            toDatePicker.AccessibleName = "To";
            toDatePicker.BorderColor = Color.FromArgb(120, 135, 126);
            toDatePicker.BorderRadius = 6;
            toDatePicker.FillColor = Color.White;
            toDatePicker.Font = new Font("Segoe UI", 10.5F);
            toDatePicker.ForeColor = Color.FromArgb(36, 51, 46);
            toDatePicker.Margin = new Padding(0);
            toDatePicker.Size = new Size(180, 40);
            toDatePicker.TabIndex = 0;
            // reportTypeComboBox
            reportTypeComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            reportTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            reportTypeComboBox.ItemHeight = 34;
            reportTypeComboBox.Items.AddRange(new object[] { "Loans & Returns", "Inventory", "Reservations", "Check-ins" });
            reportTypeComboBox.SelectedIndex = 0;
            reportTypeComboBox.FocusedState.BorderColor = Color.FromArgb(47, 93, 80);
            // fromDatePicker
            fromDatePicker.BorderThickness = 1;
            fromDatePicker.Format = DateTimePickerFormat.Custom;
            fromDatePicker.CustomFormat = "dd MMM yyyy";
            fromDatePicker.Value = new DateTime(2026, 10, 14);
            // toDatePicker
            toDatePicker.BorderThickness = 1;
            toDatePicker.Format = DateTimePickerFormat.Custom;
            toDatePicker.CustomFormat = "dd MMM yyyy";
            toDatePicker.Value = new DateTime(2026, 10, 14);
            filtersLayout.Controls.Add(actionsLayout);
            // actionsLayout
            actionsLayout.AutoSize = true;
            actionsLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            actionsLayout.Margin = new Padding(0, 27, 0, 8);
            actionsLayout.TabIndex = 3;
            actionsLayout.WrapContents = true;
            actionsLayout.Controls.Add(applyButton);
            // applyButton
            applyButton.AccessibleName = "Apply";
            applyButton.AccessibleDescription = "Design preview only; action is not connected.";
            applyButton.BorderColor = Color.FromArgb(120, 135, 126);
            applyButton.BorderThickness = 0;
            applyButton.BorderRadius = 6;
            applyButton.FillColor = Color.FromArgb(47, 93, 80);
            applyButton.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            applyButton.ForeColor = Color.White;
            applyButton.Margin = new Padding(0, 0, 8, 0);
            applyButton.Size = new Size(100, 40);
            applyButton.TabIndex = 0;
            applyButton.Text = "Apply";
            applyButton.HoverState.FillColor = Color.FromArgb(36, 72, 62);
            applyButton.FocusedColor = Color.FromArgb(120, 135, 126);
            applyButton.PressedColor = Color.FromArgb(36, 72, 62);
            actionsLayout.Controls.Add(printButton);
            // printButton
            printButton.AccessibleName = "Print / Save PDF";
            printButton.AccessibleDescription = "Design preview only; action is not connected.";
            printButton.BorderColor = Color.FromArgb(120, 135, 126);
            printButton.BorderThickness = 1;
            printButton.BorderRadius = 6;
            printButton.FillColor = Color.White;
            printButton.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            printButton.ForeColor = Color.FromArgb(47, 93, 80);
            printButton.Margin = new Padding(0, 0, 8, 0);
            printButton.Size = new Size(170, 40);
            printButton.TabIndex = 1;
            printButton.Text = "Print / Save PDF";
            printButton.HoverState.FillColor = Color.FromArgb(229, 239, 232);
            printButton.FocusedColor = Color.FromArgb(120, 135, 126);
            printButton.PressedColor = Color.FromArgb(36, 72, 62);
            // summaryLayout
            summaryLayout.AutoSize = true;
            summaryLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            summaryLayout.Dock = DockStyle.Fill;
            summaryLayout.Margin = new Padding(0, 0, 0, 8);
            summaryLayout.WrapContents = true;
            summaryLayout.TabStop = false;
            summaryLayout.Controls.Add(loansCard);
            // loansCard
            loansCard.AutoSize = true;
            loansCard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            loansCard.BorderColor = Color.FromArgb(216, 223, 216);
            loansCard.BorderThickness = 1;
            loansCard.BorderRadius = 8;
            loansCard.FillColor = Color.White;
            loansCard.BackColor = Color.White;
            loansCard.Margin = new Padding(0, 0, 16, 8);
            loansCard.MinimumSize = new Size(210, 104);
            loansCard.TabStop = false;
            loansCard.Controls.Add(loansLayout);
            // loansLayout
            loansLayout.AutoSize = true;
            loansLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            loansLayout.ColumnCount = 1;
            loansLayout.RowCount = 2;
            loansLayout.Dock = DockStyle.Top;
            loansLayout.Padding = new Padding(16);
            loansLayout.MinimumSize = new Size(210, 104);
            loansLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            loansLayout.RowStyles.Add(new RowStyle());
            loansLayout.RowStyles.Add(new RowStyle());
            loansLayout.Controls.Add(loansLabel, 0, 0);
            loansLayout.Controls.Add(loansValueLabel, 0, 1);
            // loansLabel
            loansLabel.AutoSize = true;
            loansLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            loansLabel.Margin = new Padding(0, 0, 0, 8);
            loansLabel.Text = "Loans issued";
            // loansValueLabel
            loansValueLabel.AutoSize = true;
            loansValueLabel.AccessibleName = "Loans issued unavailable";
            loansValueLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            loansValueLabel.ForeColor = Color.FromArgb(47, 93, 80);
            loansValueLabel.Margin = new Padding(0);
            loansValueLabel.Text = "—";
            summaryLayout.Controls.Add(returnsCard);
            // returnsCard
            returnsCard.AutoSize = true;
            returnsCard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            returnsCard.BorderColor = Color.FromArgb(216, 223, 216);
            returnsCard.BorderThickness = 1;
            returnsCard.BorderRadius = 8;
            returnsCard.FillColor = Color.White;
            returnsCard.BackColor = Color.White;
            returnsCard.Margin = new Padding(0, 0, 16, 8);
            returnsCard.MinimumSize = new Size(210, 104);
            returnsCard.TabStop = false;
            returnsCard.Controls.Add(returnsLayout);
            // returnsLayout
            returnsLayout.AutoSize = true;
            returnsLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            returnsLayout.ColumnCount = 1;
            returnsLayout.RowCount = 2;
            returnsLayout.Dock = DockStyle.Top;
            returnsLayout.Padding = new Padding(16);
            returnsLayout.MinimumSize = new Size(210, 104);
            returnsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            returnsLayout.RowStyles.Add(new RowStyle());
            returnsLayout.RowStyles.Add(new RowStyle());
            returnsLayout.Controls.Add(returnsLabel, 0, 0);
            returnsLayout.Controls.Add(returnsValueLabel, 0, 1);
            // returnsLabel
            returnsLabel.AutoSize = true;
            returnsLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            returnsLabel.Margin = new Padding(0, 0, 0, 8);
            returnsLabel.Text = "Returns";
            // returnsValueLabel
            returnsValueLabel.AutoSize = true;
            returnsValueLabel.AccessibleName = "Returns unavailable";
            returnsValueLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            returnsValueLabel.ForeColor = Color.FromArgb(47, 93, 80);
            returnsValueLabel.Margin = new Padding(0);
            returnsValueLabel.Text = "—";
            summaryLayout.Controls.Add(overdueCard);
            // overdueCard
            overdueCard.AutoSize = true;
            overdueCard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            overdueCard.BorderColor = Color.FromArgb(216, 223, 216);
            overdueCard.BorderThickness = 1;
            overdueCard.BorderRadius = 8;
            overdueCard.FillColor = Color.White;
            overdueCard.BackColor = Color.White;
            overdueCard.Margin = new Padding(0, 0, 16, 8);
            overdueCard.MinimumSize = new Size(210, 104);
            overdueCard.TabStop = false;
            overdueCard.Controls.Add(overdueLayout);
            // overdueLayout
            overdueLayout.AutoSize = true;
            overdueLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            overdueLayout.ColumnCount = 1;
            overdueLayout.RowCount = 2;
            overdueLayout.Dock = DockStyle.Top;
            overdueLayout.Padding = new Padding(16);
            overdueLayout.MinimumSize = new Size(210, 104);
            overdueLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            overdueLayout.RowStyles.Add(new RowStyle());
            overdueLayout.RowStyles.Add(new RowStyle());
            overdueLayout.Controls.Add(overdueLabel, 0, 0);
            overdueLayout.Controls.Add(overdueValueLabel, 0, 1);
            // overdueLabel
            overdueLabel.AutoSize = true;
            overdueLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            overdueLabel.Margin = new Padding(0, 0, 0, 8);
            overdueLabel.Text = "Overdue now";
            // overdueValueLabel
            overdueValueLabel.AutoSize = true;
            overdueValueLabel.AccessibleName = "Overdue now unavailable";
            overdueValueLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            overdueValueLabel.ForeColor = Color.FromArgb(47, 93, 80);
            overdueValueLabel.Margin = new Padding(0);
            overdueValueLabel.Text = "—";
            // headerStyle
            headerStyle.BackColor = Color.FromArgb(229, 239, 232);
            headerStyle.ForeColor = Color.FromArgb(36, 51, 46);
            headerStyle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(229, 239, 232);
            headerStyle.SelectionForeColor = Color.FromArgb(36, 51, 46);
            headerStyle.WrapMode = DataGridViewTriState.True;
            // rowStyle
            rowStyle.BackColor = Color.White;
            rowStyle.ForeColor = Color.FromArgb(36, 51, 46);
            rowStyle.Font = new Font("Segoe UI", 10.5F);
            rowStyle.SelectionBackColor = Color.FromArgb(229, 239, 232);
            rowStyle.SelectionForeColor = Color.FromArgb(36, 51, 46);
            // alternateStyle
            alternateStyle.BackColor = Color.FromArgb(247, 248, 244);
            alternateStyle.ForeColor = Color.FromArgb(36, 51, 46);
            alternateStyle.SelectionBackColor = Color.FromArgb(229, 239, 232);
            alternateStyle.SelectionForeColor = Color.FromArgb(36, 51, 46);
            // reportGrid
            reportGrid.AccessibleName = "Empty Loans and Returns report preview";
            reportGrid.AccessibleDescription = "Design preview only. No report has been generated.";
            reportGrid.AllowUserToAddRows = false;
            reportGrid.AllowUserToDeleteRows = false;
            reportGrid.AllowUserToResizeRows = false;
            reportGrid.AutoGenerateColumns = false;
            reportGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            reportGrid.BackgroundColor = Color.White;
            reportGrid.BorderStyle = BorderStyle.None;
            reportGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            reportGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            reportGrid.ColumnHeadersDefaultCellStyle = headerStyle;
            reportGrid.ColumnHeadersHeight = 48;
            reportGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            reportGrid.ColumnHeadersVisible = true;
            reportGrid.DefaultCellStyle = rowStyle;
            reportGrid.AlternatingRowsDefaultCellStyle = alternateStyle;
            reportGrid.Dock = DockStyle.Fill;
            reportGrid.EnableHeadersVisualStyles = false;
            reportGrid.GridColor = Color.FromArgb(216, 223, 216);
            reportGrid.Margin = new Padding(0);
            reportGrid.MinimumSize = new Size(280, 220);
            reportGrid.MultiSelect = false;
            reportGrid.ReadOnly = true;
            reportGrid.RowHeadersVisible = false;
            reportGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            reportGrid.TabIndex = 1;
            reportGrid.Columns.AddRange(new DataGridViewColumn[] { bookTitleColumn, loansIssuedColumn, returnsColumn });
            // bookTitleColumn
            bookTitleColumn.HeaderText = "Book title";
            bookTitleColumn.MinimumWidth = 190;
            bookTitleColumn.FillWeight = 54F;
            bookTitleColumn.ReadOnly = true;
            bookTitleColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // loansIssuedColumn
            loansIssuedColumn.HeaderText = "Loans issued";
            loansIssuedColumn.MinimumWidth = 130;
            loansIssuedColumn.FillWeight = 23F;
            loansIssuedColumn.ReadOnly = true;
            loansIssuedColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // returnsColumn
            returnsColumn.HeaderText = "Returns";
            returnsColumn.MinimumWidth = 100;
            returnsColumn.FillWeight = 23F;
            returnsColumn.ReadOnly = true;
            returnsColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            reportGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(229, 239, 232);
            reportGrid.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(36, 51, 46);
            reportGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            reportGrid.ThemeStyle.HeaderStyle.Height = 48;
            reportGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            reportGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(36, 51, 46);
            reportGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(229, 239, 232);
            reportGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(36, 51, 46);
            reportGrid.ThemeStyle.GridColor = Color.FromArgb(216, 223, 216);
            // totalsLayout
            totalsLayout.AutoSize = true;
            totalsLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            totalsLayout.Dock = DockStyle.Fill;
            totalsLayout.BackColor = Color.White;
            totalsLayout.Padding = new Padding(16);
            totalsLayout.Margin = new Padding(0);
            totalsLayout.WrapContents = true;
            totalsLayout.TabStop = false;
            totalsLayout.Controls.Add(totalLabel);
            // totalLabel
            totalLabel.AutoSize = true;
            totalLabel.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            totalLabel.Margin = new Padding(0, 0, 24, 0);
            totalLabel.Text = "Total";
            totalsLayout.Controls.Add(totalLoansLabel);
            // totalLoansLabel
            totalLoansLabel.AutoSize = true;
            totalLoansLabel.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            totalLoansLabel.Margin = new Padding(0, 0, 24, 0);
            totalLoansLabel.Text = "Loans issued: —";
            totalsLayout.Controls.Add(totalReturnsLabel);
            // totalReturnsLabel
            totalReturnsLabel.AutoSize = true;
            totalReturnsLabel.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            totalReturnsLabel.Margin = new Padding(0, 0, 24, 0);
            totalReturnsLabel.Text = "Returns: —";
            // pageLayout
            pageLayout.Name = "pageLayout";
            // headingLabel
            headingLabel.Name = "headingLabel";
            // previewLabel
            previewLabel.Name = "previewLabel";
            // filtersLayout
            filtersLayout.Name = "filtersLayout";
            // reportTypeLayout
            reportTypeLayout.Name = "reportTypeLayout";
            // reportTypeLabel
            reportTypeLabel.Name = "reportTypeLabel";
            // reportTypeComboBox
            reportTypeComboBox.Name = "reportTypeComboBox";
            // fromLayout
            fromLayout.Name = "fromLayout";
            // fromLabel
            fromLabel.Name = "fromLabel";
            // fromDatePicker
            fromDatePicker.Name = "fromDatePicker";
            // toLayout
            toLayout.Name = "toLayout";
            // toLabel
            toLabel.Name = "toLabel";
            // toDatePicker
            toDatePicker.Name = "toDatePicker";
            // actionsLayout
            actionsLayout.Name = "actionsLayout";
            // applyButton
            applyButton.Name = "applyButton";
            // printButton
            printButton.Name = "printButton";
            // summaryLayout
            summaryLayout.Name = "summaryLayout";
            // loansCard
            loansCard.Name = "loansCard";
            // loansLayout
            loansLayout.Name = "loansLayout";
            // loansLabel
            loansLabel.Name = "loansLabel";
            // loansValueLabel
            loansValueLabel.Name = "loansValueLabel";
            // returnsCard
            returnsCard.Name = "returnsCard";
            // returnsLayout
            returnsLayout.Name = "returnsLayout";
            // returnsLabel
            returnsLabel.Name = "returnsLabel";
            // returnsValueLabel
            returnsValueLabel.Name = "returnsValueLabel";
            // overdueCard
            overdueCard.Name = "overdueCard";
            // overdueLayout
            overdueLayout.Name = "overdueLayout";
            // overdueLabel
            overdueLabel.Name = "overdueLabel";
            // overdueValueLabel
            overdueValueLabel.Name = "overdueValueLabel";
            // periodNoteLabel
            periodNoteLabel.Name = "periodNoteLabel";
            // tableHeadingLabel
            tableHeadingLabel.Name = "tableHeadingLabel";
            // reportGrid
            reportGrid.Name = "reportGrid";
            // bookTitleColumn
            bookTitleColumn.Name = "bookTitleColumn";
            // loansIssuedColumn
            loansIssuedColumn.Name = "loansIssuedColumn";
            // returnsColumn
            returnsColumn.Name = "returnsColumn";
            // totalsLayout
            totalsLayout.Name = "totalsLayout";
            // totalLabel
            totalLabel.Name = "totalLabel";
            // totalLoansLabel
            totalLoansLabel.Name = "totalLoansLabel";
            // totalReturnsLabel
            totalReturnsLabel.Name = "totalReturnsLabel";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 248, 244);
            ForeColor = Color.FromArgb(36, 51, 46);
            Font = new Font("Segoe UI", 9F);
            Controls.Add(pageLayout);
            Name = "ReportsPage";
            Size = new Size(1050, 820);
            ((System.ComponentModel.ISupportInitialize)reportGrid).EndInit();
            totalsLayout.ResumeLayout(false);
            totalsLayout.PerformLayout();
            overdueLayout.ResumeLayout(false);
            overdueLayout.PerformLayout();
            overdueCard.ResumeLayout(false);
            overdueCard.PerformLayout();
            returnsLayout.ResumeLayout(false);
            returnsLayout.PerformLayout();
            returnsCard.ResumeLayout(false);
            returnsCard.PerformLayout();
            loansLayout.ResumeLayout(false);
            loansLayout.PerformLayout();
            loansCard.ResumeLayout(false);
            loansCard.PerformLayout();
            summaryLayout.ResumeLayout(false);
            summaryLayout.PerformLayout();
            actionsLayout.ResumeLayout(false);
            actionsLayout.PerformLayout();
            toLayout.ResumeLayout(false);
            toLayout.PerformLayout();
            fromLayout.ResumeLayout(false);
            fromLayout.PerformLayout();
            reportTypeLayout.ResumeLayout(false);
            reportTypeLayout.PerformLayout();
            filtersLayout.ResumeLayout(false);
            filtersLayout.PerformLayout();
            pageLayout.ResumeLayout(false);
            pageLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel pageLayout;
        private Label headingLabel;
        private Label previewLabel;
        private FlowLayoutPanel filtersLayout;
        private TableLayoutPanel reportTypeLayout;
        private Label reportTypeLabel;
        private Guna.UI2.WinForms.Guna2ComboBox reportTypeComboBox;
        private TableLayoutPanel fromLayout;
        private Label fromLabel;
        private Guna.UI2.WinForms.Guna2DateTimePicker fromDatePicker;
        private TableLayoutPanel toLayout;
        private Label toLabel;
        private Guna.UI2.WinForms.Guna2DateTimePicker toDatePicker;
        private FlowLayoutPanel actionsLayout;
        private Guna.UI2.WinForms.Guna2Button applyButton;
        private Guna.UI2.WinForms.Guna2Button printButton;
        private FlowLayoutPanel summaryLayout;
        private Guna.UI2.WinForms.Guna2Panel loansCard;
        private TableLayoutPanel loansLayout;
        private Label loansLabel;
        private Label loansValueLabel;
        private Guna.UI2.WinForms.Guna2Panel returnsCard;
        private TableLayoutPanel returnsLayout;
        private Label returnsLabel;
        private Label returnsValueLabel;
        private Guna.UI2.WinForms.Guna2Panel overdueCard;
        private TableLayoutPanel overdueLayout;
        private Label overdueLabel;
        private Label overdueValueLabel;
        private Label periodNoteLabel;
        private Label tableHeadingLabel;
        private Guna.UI2.WinForms.Guna2DataGridView reportGrid;
        private DataGridViewTextBoxColumn bookTitleColumn;
        private DataGridViewTextBoxColumn loansIssuedColumn;
        private DataGridViewTextBoxColumn returnsColumn;
        private FlowLayoutPanel totalsLayout;
        private Label totalLabel;
        private Label totalLoansLabel;
        private Label totalReturnsLabel;
        private DataGridViewCellStyle headerStyle;
        private DataGridViewCellStyle rowStyle;
        private DataGridViewCellStyle alternateStyle;
    }
}
