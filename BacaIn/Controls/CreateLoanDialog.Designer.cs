namespace BacaIn.Controls
{
    partial class CreateLoanDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            layout = new TableLayoutPanel();
            headingLabel = new Label();
            studentLabel = new Label();
            searchLayout = new TableLayoutPanel();
            searchLabel = new Label();
            searchTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            exemplarsGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            titleColumn = new DataGridViewTextBoxColumn();
            authorColumn = new DataGridViewTextBoxColumn();
            barcodeColumn = new DataGridViewTextBoxColumn();
            conditionColumn = new DataGridViewTextBoxColumn();
            actionsLayout = new FlowLayoutPanel();
            issueButton = new Guna.UI2.WinForms.Guna2Button();
            cancelButton = new Guna.UI2.WinForms.Guna2Button();
            statusLabel = new Label();
            layout.SuspendLayout();
            searchLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)exemplarsGrid).BeginInit();
            actionsLayout.SuspendLayout();
            SuspendLayout();
            // 
            // layout
            // 
            layout.ColumnCount = 1;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.Controls.Add(headingLabel, 0, 0);
            layout.Controls.Add(studentLabel, 0, 1);
            layout.Controls.Add(searchLayout, 0, 2);
            layout.Controls.Add(exemplarsGrid, 0, 3);
            layout.Controls.Add(actionsLayout, 0, 4);
            layout.Dock = DockStyle.Fill;
            layout.Location = new Point(0, 0);
            layout.Name = "layout";
            layout.Padding = new Padding(20);
            layout.RowCount = 5;
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.Size = new Size(720, 500);
            layout.TabIndex = 0;
            // 
            // headingLabel
            // 
            headingLabel.AutoSize = true;
            headingLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            headingLabel.ForeColor = Color.FromArgb(26, 26, 26);
            headingLabel.Location = new Point(23, 20);
            headingLabel.Name = "headingLabel";
            headingLabel.Size = new Size(204, 32);
            headingLabel.TabIndex = 0;
            headingLabel.Text = "Create New Loan";
            // 
            // studentLabel
            // 
            studentLabel.AutoSize = true;
            studentLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            studentLabel.ForeColor = Color.FromArgb(57, 112, 41);
            studentLabel.Location = new Point(23, 56);
            studentLabel.Margin = new Padding(3, 4, 3, 16);
            studentLabel.Name = "studentLabel";
            studentLabel.Size = new Size(74, 20);
            studentLabel.TabIndex = 1;
            studentLabel.Text = "Student: -";
            // 
            // searchLayout
            // 
            searchLayout.ColumnCount = 2;
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            searchLayout.Controls.Add(searchLabel, 0, 0);
            searchLayout.Controls.Add(searchTextBox, 1, 0);
            searchLayout.Dock = DockStyle.Fill;
            searchLayout.Location = new Point(23, 95);
            searchLayout.Margin = new Padding(3, 3, 3, 10);
            searchLayout.Name = "searchLayout";
            searchLayout.RowCount = 1;
            searchLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            searchLayout.Size = new Size(674, 40);
            searchLayout.TabIndex = 2;
            // 
            // searchLabel
            // 
            searchLabel.Anchor = AnchorStyles.Left;
            searchLabel.AutoSize = true;
            searchLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            searchLabel.ForeColor = Color.FromArgb(26, 26, 26);
            searchLabel.Location = new Point(3, 11);
            searchLabel.Margin = new Padding(3, 0, 10, 0);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(135, 17);
            searchLabel.TabIndex = 0;
            searchLabel.Text = "Search Available Copy:";
            // 
            // searchTextBox
            // 
            searchTextBox.BorderColor = Color.FromArgb(128, 128, 128);
            searchTextBox.BorderRadius = 4;
            searchTextBox.DefaultText = "";
            searchTextBox.Dock = DockStyle.Fill;
            searchTextBox.Font = new Font("Segoe UI", 9.5F);
            searchTextBox.Location = new Point(148, 0);
            searchTextBox.Margin = new Padding(0);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "Type title, author, or barcode...";
            searchTextBox.Size = new Size(526, 40);
            searchTextBox.TabIndex = 1;
            // 
            // exemplarsGrid
            // 
            exemplarsGrid.AllowUserToAddRows = false;
            exemplarsGrid.AllowUserToDeleteRows = false;
            exemplarsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            exemplarsGrid.BackgroundColor = Color.White;
            exemplarsGrid.BorderStyle = BorderStyle.None;
            exemplarsGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(242, 242, 242);
            headerStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            headerStyle.ForeColor = Color.FromArgb(26, 26, 26);
            headerStyle.SelectionBackColor = Color.FromArgb(242, 242, 242);
            headerStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);
            exemplarsGrid.ColumnHeadersDefaultCellStyle = headerStyle;
            exemplarsGrid.ColumnHeadersHeight = 32;
            exemplarsGrid.Columns.AddRange(new DataGridViewColumn[] { titleColumn, authorColumn, barcodeColumn, conditionColumn });
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Segoe UI", 9.5F);
            cellStyle.ForeColor = Color.FromArgb(26, 26, 26);
            cellStyle.SelectionBackColor = Color.FromArgb(223, 241, 218);
            cellStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);
            exemplarsGrid.DefaultCellStyle = cellStyle;
            exemplarsGrid.Dock = DockStyle.Fill;
            exemplarsGrid.Location = new Point(23, 148);
            exemplarsGrid.MultiSelect = false;
            exemplarsGrid.Name = "exemplarsGrid";
            exemplarsGrid.ReadOnly = true;
            exemplarsGrid.RowHeadersVisible = false;
            exemplarsGrid.RowTemplate.Height = 32;
            exemplarsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            exemplarsGrid.Size = new Size(674, 276);
            exemplarsGrid.TabIndex = 3;
            // 
            // titleColumn
            // 
            titleColumn.FillWeight = 40F;
            titleColumn.HeaderText = "Book Title";
            titleColumn.Name = "titleColumn";
            titleColumn.ReadOnly = true;
            // 
            // authorColumn
            // 
            authorColumn.FillWeight = 25F;
            authorColumn.HeaderText = "Author";
            authorColumn.Name = "authorColumn";
            authorColumn.ReadOnly = true;
            // 
            // barcodeColumn
            // 
            barcodeColumn.FillWeight = 20F;
            barcodeColumn.HeaderText = "Barcode";
            barcodeColumn.Name = "barcodeColumn";
            barcodeColumn.ReadOnly = true;
            // 
            // conditionColumn
            // 
            conditionColumn.FillWeight = 15F;
            conditionColumn.HeaderText = "Condition";
            conditionColumn.Name = "conditionColumn";
            conditionColumn.ReadOnly = true;
            // 
            // actionsLayout
            // 
            actionsLayout.Controls.Add(issueButton);
            actionsLayout.Controls.Add(cancelButton);
            actionsLayout.Controls.Add(statusLabel);
            actionsLayout.Dock = DockStyle.Fill;
            actionsLayout.FlowDirection = FlowDirection.RightToLeft;
            actionsLayout.Location = new Point(20, 437);
            actionsLayout.Margin = new Padding(0, 10, 0, 0);
            actionsLayout.Name = "actionsLayout";
            actionsLayout.Size = new Size(680, 43);
            actionsLayout.TabIndex = 4;
            // 
            // issueButton
            // 
            issueButton.BorderColor = Color.FromArgb(57, 112, 41);
            issueButton.BorderRadius = 4;
            issueButton.BorderThickness = 1;
            issueButton.FillColor = Color.FromArgb(57, 112, 41);
            issueButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            issueButton.ForeColor = Color.White;
            issueButton.Location = new Point(530, 0);
            issueButton.Margin = new Padding(10, 0, 0, 0);
            issueButton.Name = "issueButton";
            issueButton.Size = new Size(150, 40);
            issueButton.TabIndex = 0;
            issueButton.Text = "Issue Loan (14 Days)";
            // 
            // cancelButton
            // 
            cancelButton.BorderColor = Color.FromArgb(128, 128, 128);
            cancelButton.BorderRadius = 4;
            cancelButton.BorderThickness = 1;
            cancelButton.FillColor = Color.White;
            cancelButton.Font = new Font("Segoe UI", 10F);
            cancelButton.ForeColor = Color.FromArgb(26, 26, 26);
            cancelButton.Location = new Point(420, 0);
            cancelButton.Margin = new Padding(0);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 40);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            // 
            // statusLabel
            // 
            statusLabel.Anchor = AnchorStyles.Left;
            statusLabel.AutoSize = true;
            statusLabel.Font = new Font("Segoe UI", 9.5F);
            statusLabel.ForeColor = Color.FromArgb(153, 27, 27);
            statusLabel.Location = new Point(365, 11);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(52, 17);
            statusLabel.TabIndex = 2;
            statusLabel.Text = "status...";
            statusLabel.Visible = false;
            // 
            // CreateLoanDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 242, 242);
            ClientSize = new Size(720, 500);
            Controls.Add(layout);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateLoanDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Issue Book Loan";
            layout.ResumeLayout(false);
            layout.PerformLayout();
            searchLayout.ResumeLayout(false);
            searchLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)exemplarsGrid).EndInit();
            actionsLayout.ResumeLayout(false);
            actionsLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel layout;
        private Label headingLabel;
        private Label studentLabel;
        private TableLayoutPanel searchLayout;
        private Label searchLabel;
        private Guna.UI2.WinForms.Guna2TextBox searchTextBox;
        private Guna.UI2.WinForms.Guna2DataGridView exemplarsGrid;
        private DataGridViewTextBoxColumn titleColumn;
        private DataGridViewTextBoxColumn authorColumn;
        private DataGridViewTextBoxColumn barcodeColumn;
        private DataGridViewTextBoxColumn conditionColumn;
        private FlowLayoutPanel actionsLayout;
        private Guna.UI2.WinForms.Guna2Button issueButton;
        private Guna.UI2.WinForms.Guna2Button cancelButton;
        private Label statusLabel;
    }
}
