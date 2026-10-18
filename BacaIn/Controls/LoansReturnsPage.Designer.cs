namespace BacaIn
{
    partial class LoansReturnsPage
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
            pageLayout = new TableLayoutPanel();
            headingLabel = new Label();
            studentContextLabel = new Label();
            studentsPanel = new Guna.UI2.WinForms.Guna2Panel();
            studentsLayout = new TableLayoutPanel();
            studentsHeadingLabel = new Label();
            studentSearchLayout = new TableLayoutPanel();
            studentSearchLabel = new Label();
            studentSearchTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            studentsGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            usernameColumn = new DataGridViewTextBoxColumn();
            displayNameColumn = new DataGridViewTextBoxColumn();
            selectColumn = new DataGridViewButtonColumn();
            studentsPreviewLabel = new Label();
            loansPanel = new Guna.UI2.WinForms.Guna2Panel();
            loansLayout = new TableLayoutPanel();
            loansToolbar = new TableLayoutPanel();
            loanActionLayout = new FlowLayoutPanel();
            loanSearchLayout = new TableLayoutPanel();
            loanSearchLabel = new Label();
            loanSearchTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            createLoanButton = new Guna.UI2.WinForms.Guna2Button();
            loansGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            titleColumn = new DataGridViewTextBoxColumn();
            authorColumn = new DataGridViewTextBoxColumn();
            exemplarColumn = new DataGridViewTextBoxColumn();
            statusColumn = new DataGridViewTextBoxColumn();
            returnColumn = new DataGridViewButtonColumn();
            loansPreviewLabel = new Label();
            pageLayout.SuspendLayout();
            studentsPanel.SuspendLayout();
            studentsLayout.SuspendLayout();
            studentSearchLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)studentsGrid).BeginInit();
            loansPanel.SuspendLayout();
            loansLayout.SuspendLayout();
            loansToolbar.SuspendLayout();
            loanActionLayout.SuspendLayout();
            loanSearchLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)loansGrid).BeginInit();
            SuspendLayout();
            //
            // pageLayout
            //
            pageLayout.ColumnCount = 1;
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.Controls.Add(headingLabel, 0, 0);
            pageLayout.Controls.Add(studentContextLabel, 0, 1);
            pageLayout.Controls.Add(studentsPanel, 0, 2);
            pageLayout.Controls.Add(loansPanel, 0, 3);
            pageLayout.Dock = DockStyle.Fill;
            pageLayout.Margin = new Padding(0);
            pageLayout.MinimumSize = new Size(800, 600);
            pageLayout.Name = "pageLayout";
            pageLayout.Padding = new Padding(24);
            pageLayout.RowCount = 4;
            pageLayout.RowStyles.Add(new RowStyle());
            pageLayout.RowStyles.Add(new RowStyle());
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 42F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 58F));
            pageLayout.Size = new Size(1000, 700);
            pageLayout.TabIndex = 0;
            //
            // headingLabel
            //
            headingLabel.AutoSize = true;
            headingLabel.Dock = DockStyle.Fill;
            headingLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            headingLabel.Margin = new Padding(0, 0, 0, 8);
            headingLabel.Name = "headingLabel";
            headingLabel.Text = "Manage Loans & Returns";
            headingLabel.UseMnemonic = false;
            //
            // studentContextLabel
            //
            studentContextLabel.AutoSize = true;
            studentContextLabel.Dock = DockStyle.Fill;
            studentContextLabel.Font = new Font("Segoe UI", 11F);
            studentContextLabel.ForeColor = Color.FromArgb(102, 102, 102);
            studentContextLabel.Margin = new Padding(0, 0, 0, 16);
            studentContextLabel.Name = "studentContextLabel";
            studentContextLabel.Text = "Student: No student selected";
            //
            // studentsPanel
            //
            studentsPanel.BorderColor = Color.FromArgb(204, 204, 204);
            studentsPanel.BorderRadius = 8;
            studentsPanel.BorderThickness = 1;
            studentsPanel.Controls.Add(studentsLayout);
            studentsPanel.Dock = DockStyle.Fill;
            studentsPanel.FillColor = Color.White;
            studentsPanel.Margin = new Padding(0, 0, 0, 16);
            studentsPanel.MinimumSize = new Size(0, 190);
            studentsPanel.Name = "studentsPanel";
            studentsPanel.Padding = new Padding(16);
            studentsPanel.TabIndex = 0;
            //
            // studentsLayout
            //
            studentsLayout.BackColor = Color.White;
            studentsLayout.ColumnCount = 1;
            studentsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            studentsLayout.Controls.Add(studentsHeadingLabel, 0, 0);
            studentsLayout.Controls.Add(studentSearchLayout, 0, 1);
            studentsLayout.Controls.Add(studentsGrid, 0, 2);
            studentsLayout.Controls.Add(studentsPreviewLabel, 0, 3);
            studentsLayout.Dock = DockStyle.Fill;
            studentsLayout.Margin = new Padding(0);
            studentsLayout.Name = "studentsLayout";
            studentsLayout.RowCount = 4;
            studentsLayout.RowStyles.Add(new RowStyle());
            studentsLayout.RowStyles.Add(new RowStyle());
            studentsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            studentsLayout.RowStyles.Add(new RowStyle());
            studentsLayout.TabIndex = 0;
            //
            // studentsHeadingLabel
            //
            studentsHeadingLabel.AutoSize = true;
            studentsHeadingLabel.Dock = DockStyle.Fill;
            studentsHeadingLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            studentsHeadingLabel.Margin = new Padding(0, 0, 0, 8);
            studentsHeadingLabel.Name = "studentsHeadingLabel";
            studentsHeadingLabel.Text = "Select student";
            //
            // studentSearchLayout
            //
            studentSearchLayout.AutoSize = true;
            studentSearchLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            studentSearchLayout.ColumnCount = 2;
            studentSearchLayout.ColumnStyles.Add(new ColumnStyle());
            studentSearchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            studentSearchLayout.Controls.Add(studentSearchLabel, 0, 0);
            studentSearchLayout.Controls.Add(studentSearchTextBox, 1, 0);
            studentSearchLayout.Dock = DockStyle.Fill;
            studentSearchLayout.Margin = new Padding(0, 0, 0, 8);
            studentSearchLayout.Name = "studentSearchLayout";
            studentSearchLayout.RowCount = 1;
            studentSearchLayout.RowStyles.Add(new RowStyle());
            studentSearchLayout.TabIndex = 0;
            //
            // studentSearchLabel
            //
            studentSearchLabel.Anchor = AnchorStyles.Left;
            studentSearchLabel.AutoSize = true;
            studentSearchLabel.Font = new Font("Segoe UI", 10F);
            studentSearchLabel.Margin = new Padding(0, 0, 16, 0);
            studentSearchLabel.Name = "studentSearchLabel";
            studentSearchLabel.Text = "&Username / display name";
            studentSearchLabel.TabIndex = 0;
            //
            // studentSearchTextBox
            //
            studentSearchTextBox.AccessibleName = "Search students by username or display name";
            studentSearchTextBox.BorderColor = Color.FromArgb(128, 128, 128);
            studentSearchTextBox.BorderRadius = 6;
            studentSearchTextBox.Dock = DockStyle.Fill;
            studentSearchTextBox.FocusedState.BorderColor = Color.FromArgb(57, 112, 41);
            studentSearchTextBox.Font = new Font("Segoe UI", 10F);
            studentSearchTextBox.ForeColor = Color.FromArgb(26, 26, 26);
            studentSearchTextBox.HoverState.BorderColor = Color.FromArgb(57, 112, 41);
            studentSearchTextBox.Margin = new Padding(0);
            studentSearchTextBox.MinimumSize = new Size(0, 36);
            studentSearchTextBox.Name = "studentSearchTextBox";
            studentSearchTextBox.PlaceholderText = "Search students";
            studentSearchTextBox.Size = new Size(600, 36);
            studentSearchTextBox.TabIndex = 1;
            //
            // studentsGrid
            //
            studentsGrid.AccessibleName = "Students available for loan selection";
            studentsGrid.AccessibleDescription = "Empty design preview. Student data and selection are not connected.";
            studentsGrid.AllowUserToAddRows = false;
            studentsGrid.AllowUserToDeleteRows = false;
            studentsGrid.AllowUserToResizeRows = false;
            studentsGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
            studentsGrid.AutoGenerateColumns = false;
            studentsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            studentsGrid.BackgroundColor = Color.White;
            studentsGrid.BorderStyle = BorderStyle.None;
            studentsGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            studentsGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            studentsGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(223, 241, 218);
            studentsGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            studentsGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(26, 26, 26);
            studentsGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(223, 241, 218);
            studentsGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);
            studentsGrid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            studentsGrid.ColumnHeadersHeight = 36;
            studentsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            studentsGrid.Columns.AddRange(new DataGridViewColumn[] { usernameColumn, displayNameColumn, selectColumn });
            studentsGrid.DefaultCellStyle.BackColor = Color.White;
            studentsGrid.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            studentsGrid.DefaultCellStyle.ForeColor = Color.FromArgb(26, 26, 26);
            studentsGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(223, 241, 218);
            studentsGrid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);
            studentsGrid.Dock = DockStyle.Fill;
            studentsGrid.EnableHeadersVisualStyles = false;
            studentsGrid.GridColor = Color.FromArgb(204, 204, 204);
            studentsGrid.Margin = new Padding(0);
            studentsGrid.MultiSelect = false;
            studentsGrid.Name = "studentsGrid";
            studentsGrid.ReadOnly = true;
            studentsGrid.RowHeadersVisible = false;
            studentsGrid.RowTemplate.Height = 36;
            studentsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            studentsGrid.TabIndex = 1;
            //
            // student columns
            //
            usernameColumn.HeaderText = "Username";
            usernameColumn.MinimumWidth = 140;
            usernameColumn.Name = "usernameColumn";
            usernameColumn.ReadOnly = true;
            displayNameColumn.FillWeight = 140F;
            displayNameColumn.HeaderText = "Display Name";
            displayNameColumn.MinimumWidth = 180;
            displayNameColumn.Name = "displayNameColumn";
            displayNameColumn.ReadOnly = true;
            selectColumn.FillWeight = 55F;
            selectColumn.FlatStyle = FlatStyle.Standard;
            selectColumn.HeaderText = "Select";
            selectColumn.MinimumWidth = 88;
            selectColumn.Name = "selectColumn";
            selectColumn.ReadOnly = true;
            selectColumn.Text = "Select";
            selectColumn.UseColumnTextForButtonValue = true;
            //
            // studentsPreviewLabel
            //
            studentsPreviewLabel.AutoSize = true;
            studentsPreviewLabel.Dock = DockStyle.Fill;
            studentsPreviewLabel.Font = new Font("Segoe UI", 10F);
            studentsPreviewLabel.ForeColor = Color.FromArgb(102, 102, 102);
            studentsPreviewLabel.Margin = new Padding(0, 8, 0, 0);
            studentsPreviewLabel.Name = "studentsPreviewLabel";
            studentsPreviewLabel.Text = "Design preview — students and selection not connected.";
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
            loansPanel.MinimumSize = new Size(0, 230);
            loansPanel.Name = "loansPanel";
            loansPanel.Padding = new Padding(16);
            loansPanel.TabIndex = 1;
            //
            // loansLayout
            //
            loansLayout.BackColor = Color.White;
            loansLayout.ColumnCount = 1;
            loansLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            loansLayout.Controls.Add(loansToolbar, 0, 0);
            loansLayout.Controls.Add(loansGrid, 0, 1);
            loansLayout.Controls.Add(loansPreviewLabel, 0, 2);
            loansLayout.Dock = DockStyle.Fill;
            loansLayout.Margin = new Padding(0);
            loansLayout.Name = "loansLayout";
            loansLayout.RowCount = 3;
            loansLayout.RowStyles.Add(new RowStyle());
            loansLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            loansLayout.RowStyles.Add(new RowStyle());
            loansLayout.TabIndex = 0;
            //
            // loansToolbar
            //
            loansToolbar.AutoSize = true;
            loansToolbar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            loansToolbar.ColumnCount = 2;
            loansToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            loansToolbar.ColumnStyles.Add(new ColumnStyle());
            loansToolbar.Controls.Add(loanSearchLayout, 0, 0);
            loansToolbar.Controls.Add(loanActionLayout, 1, 0);
            loansToolbar.Dock = DockStyle.Fill;
            loansToolbar.Margin = new Padding(0, 0, 0, 16);
            loansToolbar.Name = "loansToolbar";
            loansToolbar.RowCount = 1;
            loansToolbar.RowStyles.Add(new RowStyle());
            loansToolbar.TabIndex = 0;
            //
            // loanActionLayout
            //
            loanActionLayout.AutoSize = true;
            loanActionLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            loanActionLayout.Controls.Add(createLoanButton);
            loanActionLayout.Dock = DockStyle.Bottom;
            loanActionLayout.FlowDirection = FlowDirection.LeftToRight;
            loanActionLayout.Margin = new Padding(0);
            loanActionLayout.MinimumSize = new Size(144, 40);
            loanActionLayout.Name = "loanActionLayout";
            loanActionLayout.TabIndex = 1;
            loanActionLayout.WrapContents = false;
            //
            // loanSearchLayout
            //
            loanSearchLayout.AutoSize = true;
            loanSearchLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            loanSearchLayout.ColumnCount = 1;
            loanSearchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            loanSearchLayout.Controls.Add(loanSearchLabel, 0, 0);
            loanSearchLayout.Controls.Add(loanSearchTextBox, 0, 1);
            loanSearchLayout.Dock = DockStyle.Fill;
            loanSearchLayout.Margin = new Padding(0, 0, 16, 0);
            loanSearchLayout.Name = "loanSearchLayout";
            loanSearchLayout.RowCount = 2;
            loanSearchLayout.RowStyles.Add(new RowStyle());
            loanSearchLayout.RowStyles.Add(new RowStyle());
            loanSearchLayout.TabIndex = 0;
            //
            // loanSearchLabel
            //
            loanSearchLabel.AutoSize = true;
            loanSearchLabel.Dock = DockStyle.Fill;
            loanSearchLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            loanSearchLabel.Margin = new Padding(0, 0, 0, 8);
            loanSearchLabel.Name = "loanSearchLabel";
            loanSearchLabel.Text = "Search loans by &book / exemplar";
            loanSearchLabel.TabIndex = 0;
            //
            // loanSearchTextBox
            //
            loanSearchTextBox.AccessibleName = "Search loans by book or exemplar";
            loanSearchTextBox.BorderColor = Color.FromArgb(128, 128, 128);
            loanSearchTextBox.BorderRadius = 6;
            loanSearchTextBox.Dock = DockStyle.Fill;
            loanSearchTextBox.FocusedState.BorderColor = Color.FromArgb(57, 112, 41);
            loanSearchTextBox.Font = new Font("Segoe UI", 10F);
            loanSearchTextBox.ForeColor = Color.FromArgb(26, 26, 26);
            loanSearchTextBox.HoverState.BorderColor = Color.FromArgb(57, 112, 41);
            loanSearchTextBox.Margin = new Padding(0);
            loanSearchTextBox.MinimumSize = new Size(0, 40);
            loanSearchTextBox.Name = "loanSearchTextBox";
            loanSearchTextBox.PlaceholderText = "Book title or exemplar";
            loanSearchTextBox.Size = new Size(600, 40);
            loanSearchTextBox.TabIndex = 1;
            //
            // createLoanButton
            //
            createLoanButton.AccessibleName = "Create loan";
            createLoanButton.AccessibleDescription = "Design preview action. Creating loans is not connected.";
            createLoanButton.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            createLoanButton.AutoSize = false;
            createLoanButton.BorderColor = Color.FromArgb(57, 112, 41);
            createLoanButton.BorderRadius = 6;
            createLoanButton.BorderThickness = 1;
            createLoanButton.FillColor = Color.FromArgb(57, 112, 41);
            createLoanButton.FocusedColor = Color.FromArgb(38, 74, 28);
            createLoanButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            createLoanButton.ForeColor = Color.White;
            createLoanButton.HoverState.FillColor = Color.FromArgb(38, 74, 28);
            createLoanButton.MinimumSize = new Size(144, 40);
            createLoanButton.Name = "createLoanButton";
            createLoanButton.PressedColor = Color.FromArgb(38, 74, 28);
            createLoanButton.Size = new Size(144, 40);
            createLoanButton.TabIndex = 1;
            createLoanButton.Text = "Create Loan";
            //
            // loansGrid
            //
            loansGrid.AccessibleName = "Loans and returns";
            loansGrid.AccessibleDescription = "Empty design preview. Loans and return actions are not connected.";
            loansGrid.AllowUserToAddRows = false;
            loansGrid.AllowUserToDeleteRows = false;
            loansGrid.AllowUserToResizeRows = false;
            loansGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
            loansGrid.AutoGenerateColumns = false;
            loansGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            loansGrid.BackgroundColor = Color.White;
            loansGrid.BorderStyle = BorderStyle.None;
            loansGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            loansGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            loansGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(223, 241, 218);
            loansGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            loansGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(26, 26, 26);
            loansGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(223, 241, 218);
            loansGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);
            loansGrid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            loansGrid.ColumnHeadersHeight = 36;
            loansGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            loansGrid.Columns.AddRange(new DataGridViewColumn[] { titleColumn, authorColumn, exemplarColumn, statusColumn, returnColumn });
            loansGrid.DefaultCellStyle.BackColor = Color.White;
            loansGrid.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            loansGrid.DefaultCellStyle.ForeColor = Color.FromArgb(26, 26, 26);
            loansGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(223, 241, 218);
            loansGrid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);
            loansGrid.Dock = DockStyle.Fill;
            loansGrid.EnableHeadersVisualStyles = false;
            loansGrid.GridColor = Color.FromArgb(204, 204, 204);
            loansGrid.Margin = new Padding(0);
            loansGrid.MultiSelect = false;
            loansGrid.Name = "loansGrid";
            loansGrid.ReadOnly = true;
            loansGrid.RowHeadersVisible = false;
            loansGrid.RowTemplate.Height = 36;
            loansGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            loansGrid.TabIndex = 1;
            //
            // loan columns
            //
            titleColumn.FillWeight = 160F;
            titleColumn.HeaderText = "Title";
            titleColumn.MinimumWidth = 180;
            titleColumn.Name = "titleColumn";
            titleColumn.ReadOnly = true;
            authorColumn.FillWeight = 120F;
            authorColumn.HeaderText = "Author";
            authorColumn.MinimumWidth = 140;
            authorColumn.Name = "authorColumn";
            authorColumn.ReadOnly = true;
            exemplarColumn.HeaderText = "Exemplar";
            exemplarColumn.MinimumWidth = 110;
            exemplarColumn.Name = "exemplarColumn";
            exemplarColumn.ReadOnly = true;
            statusColumn.HeaderText = "Status";
            statusColumn.MinimumWidth = 110;
            statusColumn.Name = "statusColumn";
            statusColumn.ReadOnly = true;
            returnColumn.FillWeight = 65F;
            returnColumn.FlatStyle = FlatStyle.Standard;
            returnColumn.HeaderText = "Return";
            returnColumn.MinimumWidth = 88;
            returnColumn.Name = "returnColumn";
            returnColumn.ReadOnly = true;
            returnColumn.Text = "Return";
            returnColumn.UseColumnTextForButtonValue = true;
            //
            // loansPreviewLabel
            //
            loansPreviewLabel.AutoSize = true;
            loansPreviewLabel.Dock = DockStyle.Fill;
            loansPreviewLabel.Font = new Font("Segoe UI", 10F);
            loansPreviewLabel.ForeColor = Color.FromArgb(102, 102, 102);
            loansPreviewLabel.Margin = new Padding(0, 8, 0, 0);
            loansPreviewLabel.Name = "loansPreviewLabel";
            loansPreviewLabel.Text = "Design preview — loans, search and actions not connected.";
            //
            // LoansReturnsPage
            //
            AccessibleName = "Manage loans and returns";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(242, 242, 242);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.FromArgb(26, 26, 26);
            Name = "LoansReturnsPage";
            Size = new Size(1000, 700);
            pageLayout.ResumeLayout(false);
            pageLayout.PerformLayout();
            studentsPanel.ResumeLayout(false);
            studentsLayout.ResumeLayout(false);
            studentsLayout.PerformLayout();
            studentSearchLayout.ResumeLayout(false);
            studentSearchLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)studentsGrid).EndInit();
            loansPanel.ResumeLayout(false);
            loansLayout.ResumeLayout(false);
            loansLayout.PerformLayout();
            loansToolbar.ResumeLayout(false);
            loansToolbar.PerformLayout();
            loanActionLayout.ResumeLayout(false);
            loanActionLayout.PerformLayout();
            loanSearchLayout.ResumeLayout(false);
            loanSearchLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)loansGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel pageLayout;
        private Label headingLabel;
        private Label studentContextLabel;
        private Guna.UI2.WinForms.Guna2Panel studentsPanel;
        private TableLayoutPanel studentsLayout;
        private Label studentsHeadingLabel;
        private TableLayoutPanel studentSearchLayout;
        private Label studentSearchLabel;
        private Guna.UI2.WinForms.Guna2TextBox studentSearchTextBox;
        private Guna.UI2.WinForms.Guna2DataGridView studentsGrid;
        private DataGridViewTextBoxColumn usernameColumn;
        private DataGridViewTextBoxColumn displayNameColumn;
        private DataGridViewButtonColumn selectColumn;
        private Label studentsPreviewLabel;
        private Guna.UI2.WinForms.Guna2Panel loansPanel;
        private TableLayoutPanel loansLayout;
        private TableLayoutPanel loansToolbar;
        private FlowLayoutPanel loanActionLayout;
        private TableLayoutPanel loanSearchLayout;
        private Label loanSearchLabel;
        private Guna.UI2.WinForms.Guna2TextBox loanSearchTextBox;
        private Guna.UI2.WinForms.Guna2Button createLoanButton;
        private Guna.UI2.WinForms.Guna2DataGridView loansGrid;
        private DataGridViewTextBoxColumn titleColumn;
        private DataGridViewTextBoxColumn authorColumn;
        private DataGridViewTextBoxColumn exemplarColumn;
        private DataGridViewTextBoxColumn statusColumn;
        private DataGridViewButtonColumn returnColumn;
        private Label loansPreviewLabel;
    }
}
