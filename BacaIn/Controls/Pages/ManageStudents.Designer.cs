namespace BacaIn.Controls
{
    partial class ManageStudents
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnLoans = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnCreate = new Button();
            dataGridView1 = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colUsername = new DataGridViewTextBoxColumn();
            colDisplayName = new DataGridViewTextBoxColumn();
            colActiveLoans = new DataGridViewTextBoxColumn();
            colOverdueLoans = new DataGridViewTextBoxColumn();
            colCheckIns = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 5);
            label1.Name = "label1";
            label1.Size = new Size(164, 25);
            label1.TabIndex = 0;
            label1.Text = "Manage Students";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(9, 30);
            label2.Name = "label2";
            label2.Size = new Size(227, 15);
            label2.TabIndex = 1;
            label2.Text = "Manage student accounts and library access";
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Location = new Point(11, 64);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search username or display name...";
            txtSearch.Size = new Size(255, 23);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.ControlLightLight;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Location = new Point(272, 64);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(28, 23);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "🔍";
            btnSearch.TextAlign = ContentAlignment.TopCenter;
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnLoans
            // 
            btnLoans.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLoans.BackColor = SystemColors.ControlLightLight;
            btnLoans.FlatStyle = FlatStyle.Flat;
            btnLoans.Location = new Point(455, 64);
            btnLoans.Name = "btnLoans";
            btnLoans.Size = new Size(106, 23);
            btnLoans.TabIndex = 4;
            btnLoans.Text = "Loans && Returns";
            btnLoans.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BackColor = Color.FromArgb(255, 153, 102);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(567, 64);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(28, 23);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "🗑️";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.BackColor = SystemColors.ControlLightLight;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(601, 64);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(28, 23);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "✏️";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnCreate
            // 
            btnCreate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreate.BackColor = Color.FromArgb(153, 204, 51);
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Location = new Point(635, 64);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(103, 23);
            btnCreate.TabIndex = 7;
            btnCreate.Text = "➕ Add Student";
            btnCreate.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colId, colUsername, colDisplayName, colActiveLoans, colOverdueLoans, colCheckIns });
            dataGridView1.Location = new Point(11, 100);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(727, 328);
            dataGridView1.TabIndex = 8;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colUsername
            // 
            colUsername.DataPropertyName = "Username";
            colUsername.HeaderText = "Username";
            colUsername.Name = "colUsername";
            colUsername.ReadOnly = true;
            // 
            // colDisplayName
            // 
            colDisplayName.DataPropertyName = "DisplayName";
            colDisplayName.HeaderText = "Display Name";
            colDisplayName.Name = "colDisplayName";
            colDisplayName.ReadOnly = true;
            // 
            // colActiveLoans
            // 
            colActiveLoans.DataPropertyName = "ActiveLoans";
            colActiveLoans.HeaderText = "Active Loans";
            colActiveLoans.Name = "colActiveLoans";
            colActiveLoans.ReadOnly = true;
            // 
            // colOverdueLoans
            // 
            colOverdueLoans.DataPropertyName = "OverdueLoans";
            colOverdueLoans.HeaderText = "Overdue";
            colOverdueLoans.Name = "colOverdueLoans";
            colOverdueLoans.ReadOnly = true;
            // 
            // colCheckIns
            // 
            colCheckIns.DataPropertyName = "CheckIns";
            colCheckIns.HeaderText = "Check-ins";
            colCheckIns.Name = "colCheckIns";
            colCheckIns.ReadOnly = true;
            // 
            // ManageStudents
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            BackColor = SystemColors.Control;
            Controls.Add(dataGridView1);
            Controls.Add(btnCreate);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnLoans);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ManageStudents";
            Size = new Size(749, 450);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnLoans;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnCreate;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colUsername;
        private DataGridViewTextBoxColumn colDisplayName;
        private DataGridViewTextBoxColumn colActiveLoans;
        private DataGridViewTextBoxColumn colOverdueLoans;
        private DataGridViewTextBoxColumn colCheckIns;
    }
}
