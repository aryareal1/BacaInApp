namespace BacaIn.Controls
{
    partial class CreateLoanDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblStudent = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvExemplars = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colBarcode = new DataGridViewTextBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colAuthor = new DataGridViewTextBoxColumn();
            colCondition = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            lblDueInfo = new Label();
            btnCreate = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvExemplars).BeginInit();
            SuspendLayout();
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStudent.Location = new Point(14, 14);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new Size(60, 17);
            lblStudent.TabIndex = 0;
            lblStudent.Text = "Student:";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Location = new Point(14, 42);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search barcode, title, author, ISBN...";
            txtSearch.Size = new Size(572, 23);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = SystemColors.ControlLightLight;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Location = new Point(592, 42);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(32, 23);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "🔍";
            btnSearch.TextAlign = ContentAlignment.TopCenter;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvExemplars
            // 
            DataGridViewCellStyle alternatingStyle = new DataGridViewCellStyle();
            alternatingStyle.BackColor = Color.FromArgb(236, 246, 226);
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(117, 194, 59);
            headerStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headerStyle.ForeColor = Color.Black;
            headerStyle.SelectionBackColor = Color.FromArgb(117, 194, 59);
            headerStyle.SelectionForeColor = Color.Black;
            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.White;
            rowStyle.ForeColor = Color.Black;
            rowStyle.SelectionBackColor = Color.FromArgb(117, 194, 59);
            rowStyle.SelectionForeColor = Color.Black;
            dgvExemplars.AllowUserToAddRows = false;
            dgvExemplars.AllowUserToDeleteRows = false;
            dgvExemplars.AlternatingRowsDefaultCellStyle = alternatingStyle;
            dgvExemplars.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvExemplars.AutoGenerateColumns = false;
            dgvExemplars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExemplars.BackgroundColor = SystemColors.ControlLight;
            dgvExemplars.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvExemplars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExemplars.Columns.AddRange(new DataGridViewColumn[] { colId, colBarcode, colTitle, colAuthor, colCondition, colStatus });
            dgvExemplars.EnableHeadersVisualStyles = false;
            dgvExemplars.Location = new Point(14, 75);
            dgvExemplars.MultiSelect = false;
            dgvExemplars.Name = "dgvExemplars";
            dgvExemplars.ReadOnly = true;
            dgvExemplars.RowHeadersVisible = false;
            dgvExemplars.RowsDefaultCellStyle = rowStyle;
            dgvExemplars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExemplars.Size = new Size(610, 268);
            dgvExemplars.TabIndex = 3;
            dgvExemplars.CellDoubleClick += dgvExemplars_CellDoubleClick;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colBarcode
            // 
            colBarcode.DataPropertyName = "Barcode";
            colBarcode.HeaderText = "Barcode";
            colBarcode.Name = "colBarcode";
            colBarcode.ReadOnly = true;
            // 
            // colTitle
            // 
            colTitle.DataPropertyName = "Title";
            colTitle.HeaderText = "Title";
            colTitle.Name = "colTitle";
            colTitle.ReadOnly = true;
            // 
            // colAuthor
            // 
            colAuthor.DataPropertyName = "Author";
            colAuthor.HeaderText = "Author";
            colAuthor.Name = "colAuthor";
            colAuthor.ReadOnly = true;
            // 
            // colCondition
            // 
            colCondition.DataPropertyName = "Condition";
            colCondition.HeaderText = "Condition";
            colCondition.Name = "colCondition";
            colCondition.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "StatusText";
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // lblDueInfo
            // 
            lblDueInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblDueInfo.AutoSize = true;
            lblDueInfo.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblDueInfo.ForeColor = SystemColors.GrayText;
            lblDueInfo.Location = new Point(14, 365);
            lblDueInfo.Name = "lblDueInfo";
            lblDueInfo.Size = new Size(110, 15);
            lblDueInfo.TabIndex = 4;
            lblDueInfo.Text = "Loan period: 14 days";
            // 
            // btnCreate
            // 
            btnCreate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCreate.BackColor = Color.FromArgb(153, 204, 51);
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Location = new Point(428, 358);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(100, 30);
            btnCreate.TabIndex = 5;
            btnCreate.Text = "Create Loan";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = SystemColors.ControlLightLight;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(534, 358);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 30);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // CreateLoanDialog
            // 
            AcceptButton = btnCreate;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(640, 402);
            Controls.Add(btnCancel);
            Controls.Add(btnCreate);
            Controls.Add(lblDueInfo);
            Controls.Add(dgvExemplars);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblStudent);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateLoanDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Create Loan";
            Load += CreateLoanDialog_Load;
            ((System.ComponentModel.ISupportInitialize)dgvExemplars).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStudent;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvExemplars;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colBarcode;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colAuthor;
        private DataGridViewTextBoxColumn colCondition;
        private DataGridViewTextBoxColumn colStatus;
        private Label lblDueInfo;
        private Button btnCreate;
        private Button btnCancel;
    }
}
