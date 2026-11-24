namespace BacaIn.Controls
{
    partial class ManageLoansReturns
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
            btnEdit = new Button();
            btnCreate = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            label1 = new Label();
            label2 = new Label();
            lblSelectedUser = new Label();
            pbSelectedUser = new CircularPictureBox();
            pnlMain = new Panel();
            dataGridView1 = new DataGridView();
            selectUser = new SelectUser();
            ((System.ComponentModel.ISupportInitialize)pbSelectedUser).BeginInit();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.BackColor = SystemColors.ControlLightLight;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(539, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(78, 23);
            btnEdit.TabIndex = 12;
            btnEdit.Text = "🔙 Return";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnCreate
            // 
            btnCreate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreate.BackColor = Color.FromArgb(153, 204, 51);
            btnCreate.BackgroundImageLayout = ImageLayout.None;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Location = new Point(623, 0);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(104, 23);
            btnCreate.TabIndex = 11;
            btnCreate.Text = "➕ Create Loan";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.ControlLightLight;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Location = new Point(261, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(28, 23);
            btnSearch.TabIndex = 10;
            btnSearch.Text = "🔍";
            btnSearch.TextAlign = ContentAlignment.TopCenter;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Location = new Point(0, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search title, author, etc...";
            txtSearch.Size = new Size(255, 23);
            txtSearch.TabIndex = 9;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 5);
            label1.Name = "label1";
            label1.Size = new Size(236, 25);
            label1.TabIndex = 8;
            label1.Text = "Manage Loans && Returns";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(9, 30);
            label2.Name = "label2";
            label2.Size = new Size(225, 15);
            label2.TabIndex = 15;
            label2.Text = "Manage students' book loans and returns";
            // 
            // lblSelectedUser
            // 
            lblSelectedUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSelectedUser.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelectedUser.Location = new Point(450, 9);
            lblSelectedUser.Name = "lblSelectedUser";
            lblSelectedUser.Size = new Size(258, 24);
            lblSelectedUser.TabIndex = 18;
            lblSelectedUser.Text = "-";
            lblSelectedUser.TextAlign = ContentAlignment.MiddleRight;
            lblSelectedUser.Visible = false;
            // 
            // pbSelectedUser
            // 
            pbSelectedUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbSelectedUser.Image = Properties.Resources.pfp;
            pbSelectedUser.Location = new Point(714, 9);
            pbSelectedUser.Name = "pbSelectedUser";
            pbSelectedUser.Size = new Size(24, 24);
            pbSelectedUser.SizeMode = PictureBoxSizeMode.Zoom;
            pbSelectedUser.TabIndex = 19;
            pbSelectedUser.TabStop = false;
            pbSelectedUser.Visible = false;
            // 
            // pnlMain
            // 
            pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlMain.Controls.Add(dataGridView1);
            pnlMain.Controls.Add(txtSearch);
            pnlMain.Controls.Add(btnEdit);
            pnlMain.Controls.Add(btnSearch);
            pnlMain.Controls.Add(btnCreate);
            pnlMain.Location = new Point(11, 64);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(727, 368);
            pnlMain.TabIndex = 16;
            // 
            // dataGridView1
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
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AlternatingRowsDefaultCellStyle = alternatingStyle;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = SystemColors.ControlLight;
            dataGridView1.ColumnHeadersDefaultCellStyle = headerStyle;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(0, 37);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowsDefaultCellStyle = rowStyle;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(727, 328);
            dataGridView1.TabIndex = 13;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // selectUser
            // 
            selectUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            selectUser.Location = new Point(11, 64);
            selectUser.Name = "selectUser";
            selectUser.Size = new Size(727, 368);
            selectUser.TabIndex = 17;
            selectUser.UserSelected += SelectUser_UserSelected;
            // 
            // ManageLoansReturns
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            Controls.Add(pnlMain);
            Controls.Add(selectUser);
            Controls.Add(pbSelectedUser);
            Controls.Add(lblSelectedUser);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "ManageLoansReturns";
            Size = new Size(749, 450);
            ((System.ComponentModel.ISupportInitialize)pbSelectedUser).EndInit();
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnEdit;
        private Button btnCreate;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label label1;
        private Label label2;
        private Label lblSelectedUser;
        private CircularPictureBox pbSelectedUser;
        private Panel pnlMain;
        private SelectUser selectUser;
        private DataGridView dataGridView1;
    }
}
