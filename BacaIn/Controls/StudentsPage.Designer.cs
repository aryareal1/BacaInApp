namespace BacaIn
{
    partial class StudentsPage
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>Releases owned components.</summary>
        /// <param name="disposing">Whether managed resources should be released.</param>
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
            pageLayout = new TableLayoutPanel();
            headingLabel = new Label();
            descriptionLabel = new Label();
            searchLayout = new TableLayoutPanel();
            searchLabel = new Label();
            searchTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            addStudentButton = new Guna.UI2.WinForms.Guna2Button();
            previewLabel = new Label();
            studentsGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            usernameColumn = new DataGridViewTextBoxColumn();
            displayNameColumn = new DataGridViewTextBoxColumn();
            editColumn = new DataGridViewButtonColumn();
            manageLoansReturnsColumn = new DataGridViewButtonColumn();
            pageLayout.SuspendLayout();
            searchLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)studentsGrid).BeginInit();
            SuspendLayout();
            //
            // pageLayout
            //
            pageLayout.ColumnCount = 1;
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.Controls.Add(headingLabel, 0, 0);
            pageLayout.Controls.Add(descriptionLabel, 0, 1);
            pageLayout.Controls.Add(searchLayout, 0, 2);
            pageLayout.Controls.Add(previewLabel, 0, 3);
            pageLayout.Controls.Add(studentsGrid, 0, 4);
            pageLayout.Dock = DockStyle.Fill;
            pageLayout.Margin = new Padding(0);
            pageLayout.MinimumSize = new Size(720, 520);
            pageLayout.Name = "pageLayout";
            pageLayout.Padding = new Padding(24);
            pageLayout.RowCount = 5;
            pageLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pageLayout.Size = new Size(960, 640);
            pageLayout.TabIndex = 0;
            //
            // headingLabel
            //
            headingLabel.AutoSize = true;
            headingLabel.Dock = DockStyle.Fill;
            headingLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            headingLabel.ForeColor = Color.FromArgb(36, 51, 46);
            headingLabel.Margin = new Padding(0, 0, 0, 8);
            headingLabel.Name = "headingLabel";
            headingLabel.TabIndex = 0;
            headingLabel.Text = "Manage Students";
            //
            // descriptionLabel
            //
            descriptionLabel.AutoSize = true;
            descriptionLabel.Dock = DockStyle.Fill;
            descriptionLabel.Font = new Font("Segoe UI", 10.5F);
            descriptionLabel.ForeColor = Color.FromArgb(95, 111, 103);
            descriptionLabel.Margin = new Padding(0, 0, 0, 24);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.TabIndex = 1;
            descriptionLabel.Text = "Student accounts and library borrowing access.";
            //
            // searchLayout
            //
            searchLayout.AutoSize = true;
            searchLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            searchLayout.ColumnCount = 2;
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            searchLayout.Controls.Add(searchLabel, 0, 0);
            searchLayout.Controls.Add(searchTextBox, 0, 1);
            searchLayout.Controls.Add(addStudentButton, 1, 1);
            searchLayout.Dock = DockStyle.Fill;
            searchLayout.Margin = new Padding(0, 0, 0, 16);
            searchLayout.Name = "searchLayout";
            searchLayout.RowCount = 2;
            searchLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            searchLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            searchLayout.TabIndex = 2;
            //
            // searchLabel
            //
            searchLabel.AutoSize = true;
            searchLabel.Dock = DockStyle.Fill;
            searchLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            searchLabel.ForeColor = Color.FromArgb(36, 51, 46);
            searchLabel.Margin = new Padding(0, 0, 16, 8);
            searchLabel.Name = "searchLabel";
            searchLabel.TabIndex = 0;
            searchLabel.Text = "Search students by username or display name";
            //
            // searchTextBox
            //
            searchTextBox.AccessibleName = "Search students by username or display name";
            searchTextBox.AccessibleDescription = "Design preview. Student search is not connected.";
            searchTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            searchTextBox.BorderColor = Color.FromArgb(120, 135, 126);
            searchTextBox.BorderRadius = 4;
            searchTextBox.Cursor = Cursors.IBeam;
            searchTextBox.DefaultText = "";
            searchTextBox.FillColor = Color.White;
            searchTextBox.FocusedState.BorderColor = Color.FromArgb(47, 93, 80);
            searchTextBox.Font = new Font("Segoe UI", 11F);
            searchTextBox.ForeColor = Color.FromArgb(36, 51, 46);
            searchTextBox.HoverState.BorderColor = Color.FromArgb(47, 93, 80);
            searchTextBox.Margin = new Padding(0, 0, 16, 0);
            searchTextBox.MinimumSize = new Size(240, 44);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderForeColor = Color.FromArgb(95, 111, 103);
            searchTextBox.PlaceholderText = "Username or display name";
            searchTextBox.Size = new Size(736, 44);
            searchTextBox.TabIndex = 1;
            //
            // addStudentButton
            //
            addStudentButton.AccessibleName = "Add Student";
            addStudentButton.AccessibleDescription = "Design preview. Adding students is not connected.";
            addStudentButton.Anchor = AnchorStyles.Right;
            addStudentButton.BorderColor = Color.FromArgb(47, 93, 80);
            addStudentButton.BorderRadius = 4;
            addStudentButton.BorderThickness = 1;
            addStudentButton.FillColor = Color.FromArgb(47, 93, 80);
            addStudentButton.FocusedColor = Color.FromArgb(36, 72, 62);
            addStudentButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            addStudentButton.ForeColor = Color.White;
            addStudentButton.HoverState.BorderColor = Color.FromArgb(36, 72, 62);
            addStudentButton.HoverState.FillColor = Color.FromArgb(36, 72, 62);
            addStudentButton.IndicateFocus = true;
            addStudentButton.Margin = new Padding(0);
            addStudentButton.MinimumSize = new Size(160, 44);
            addStudentButton.Name = "addStudentButton";
            addStudentButton.Size = new Size(160, 44);
            addStudentButton.TabIndex = 2;
            addStudentButton.Text = "Add Student";
            //
            // previewLabel
            //
            previewLabel.AutoSize = true;
            previewLabel.Dock = DockStyle.Fill;
            previewLabel.Font = new Font("Segoe UI", 10.5F);
            previewLabel.ForeColor = Color.FromArgb(95, 111, 103);
            previewLabel.Margin = new Padding(0, 0, 0, 16);
            previewLabel.Name = "previewLabel";
            previewLabel.TabIndex = 3;
            previewLabel.Text = "Design preview — student data, search, Add Student, Edit, and Manage Loans & Returns actions are not connected.";
            previewLabel.UseMnemonic = false;
            //
            // studentsGrid
            //
            studentsGrid.AccessibleName = "Students";
            studentsGrid.AccessibleDescription = "Empty design preview with Username, Display Name, Edit, and Manage Loans & Returns columns.";
            studentsGrid.AllowUserToAddRows = false;
            studentsGrid.AllowUserToDeleteRows = false;
            studentsGrid.AllowUserToResizeRows = false;
            studentsGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 248, 244);
            studentsGrid.AutoGenerateColumns = false;
            studentsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            studentsGrid.BackgroundColor = Color.White;
            studentsGrid.BorderStyle = BorderStyle.None;
            studentsGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            studentsGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            studentsGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            studentsGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(229, 239, 232);
            studentsGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            studentsGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(36, 51, 46);
            studentsGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(229, 239, 232);
            studentsGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(36, 51, 46);
            studentsGrid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            studentsGrid.ColumnHeadersHeight = 48;
            studentsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            studentsGrid.ColumnHeadersVisible = true;
            studentsGrid.Columns.AddRange(new DataGridViewColumn[] { usernameColumn, displayNameColumn, editColumn, manageLoansReturnsColumn });
            studentsGrid.DefaultCellStyle.BackColor = Color.White;
            studentsGrid.DefaultCellStyle.Font = new Font("Segoe UI", 10.5F);
            studentsGrid.DefaultCellStyle.ForeColor = Color.FromArgb(36, 51, 46);
            studentsGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(229, 239, 232);
            studentsGrid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(36, 51, 46);
            studentsGrid.Dock = DockStyle.Fill;
            studentsGrid.EnableHeadersVisualStyles = false;
            studentsGrid.GridColor = Color.FromArgb(216, 223, 216);
            studentsGrid.Margin = new Padding(0);
            studentsGrid.MinimumSize = new Size(0, 260);
            studentsGrid.MultiSelect = false;
            studentsGrid.Name = "studentsGrid";
            studentsGrid.ReadOnly = true;
            studentsGrid.RowHeadersVisible = false;
            studentsGrid.RowTemplate.Height = 44;
            studentsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            studentsGrid.Size = new Size(912, 348);
            studentsGrid.TabIndex = 4;
            studentsGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(247, 248, 244);
            studentsGrid.ThemeStyle.BackColor = Color.White;
            studentsGrid.ThemeStyle.GridColor = Color.FromArgb(216, 223, 216);
            studentsGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(229, 239, 232);
            studentsGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            studentsGrid.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(36, 51, 46);
            studentsGrid.ThemeStyle.HeaderStyle.Height = 48;
            studentsGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            studentsGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 10.5F);
            studentsGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(36, 51, 46);
            studentsGrid.ThemeStyle.RowsStyle.Height = 44;
            studentsGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(229, 239, 232);
            studentsGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(36, 51, 46);
            //
            // columns
            //
            usernameColumn.FillWeight = 25F;
            usernameColumn.HeaderText = "Username";
            usernameColumn.MinimumWidth = 150;
            usernameColumn.Name = "usernameColumn";
            usernameColumn.ReadOnly = true;
            displayNameColumn.FillWeight = 35F;
            displayNameColumn.HeaderText = "Display Name";
            displayNameColumn.MinimumWidth = 180;
            displayNameColumn.Name = "displayNameColumn";
            displayNameColumn.ReadOnly = true;
            editColumn.FillWeight = 10F;
            editColumn.FlatStyle = FlatStyle.Standard;
            editColumn.HeaderText = "Edit";
            editColumn.MinimumWidth = 80;
            editColumn.Name = "editColumn";
            editColumn.ReadOnly = true;
            editColumn.Text = "Edit";
            editColumn.UseColumnTextForButtonValue = true;
            manageLoansReturnsColumn.FillWeight = 30F;
            manageLoansReturnsColumn.FlatStyle = FlatStyle.Standard;
            manageLoansReturnsColumn.HeaderText = "Manage Loans & Returns";
            manageLoansReturnsColumn.MinimumWidth = 250;
            manageLoansReturnsColumn.Name = "manageLoansReturnsColumn";
            manageLoansReturnsColumn.ReadOnly = true;
            manageLoansReturnsColumn.Text = "Manage Loans & Returns";
            manageLoansReturnsColumn.UseColumnTextForButtonValue = true;
            //
            // StudentsPage
            //
            AccessibleName = "Manage Students";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(247, 248, 244);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Name = "StudentsPage";
            Size = new Size(960, 640);
            pageLayout.ResumeLayout(false);
            pageLayout.PerformLayout();
            searchLayout.ResumeLayout(false);
            searchLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)studentsGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel pageLayout;
        private Label headingLabel;
        private Label descriptionLabel;
        private TableLayoutPanel searchLayout;
        private Label searchLabel;
        private Guna.UI2.WinForms.Guna2TextBox searchTextBox;
        private Guna.UI2.WinForms.Guna2Button addStudentButton;
        private Label previewLabel;
        private Guna.UI2.WinForms.Guna2DataGridView studentsGrid;
        private DataGridViewTextBoxColumn usernameColumn;
        private DataGridViewTextBoxColumn displayNameColumn;
        private DataGridViewButtonColumn editColumn;
        private DataGridViewButtonColumn manageLoansReturnsColumn;
    }
}
