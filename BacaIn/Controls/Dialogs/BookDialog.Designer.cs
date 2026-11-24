namespace BacaIn.Controls
{
    partial class BookDialog
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
            lblIsbn = new Label();
            txtIsbn = new TextBox();
            btnLookup = new Button();
            lblIsbnStatus = new Label();
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblAuthor = new Label();
            txtAuthor = new TextBox();
            lblPublisher = new Label();
            txtPublisher = new TextBox();
            lblYear = new Label();
            txtYear = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblCover = new Label();
            txtCoverUrl = new TextBox();
            btnSelectCover = new Button();
            lblExemplars = new Label();
            btnRemoveCopy = new Button();
            btnAddCopy = new Button();
            dgvExemplars = new DataGridView();
            colBarcode = new DataGridViewTextBoxColumn();
            colCondition = new DataGridViewComboBoxColumn();
            colStatus = new DataGridViewComboBoxColumn();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvExemplars).BeginInit();
            SuspendLayout();
            // 
            // lblIsbn
            // 
            lblIsbn.AutoSize = true;
            lblIsbn.Location = new Point(16, 19);
            lblIsbn.Name = "lblIsbn";
            lblIsbn.Size = new Size(32, 15);
            lblIsbn.TabIndex = 0;
            lblIsbn.Text = "ISBN";
            // 
            // txtIsbn
            // 
            txtIsbn.Location = new Point(126, 16);
            txtIsbn.MaxLength = 13;
            txtIsbn.Name = "txtIsbn";
            txtIsbn.PlaceholderText = "10 or 13 digits";
            txtIsbn.Size = new Size(203, 23);
            txtIsbn.TabIndex = 1;
            // 
            // btnLookup
            // 
            btnLookup.BackColor = SystemColors.ControlLightLight;
            btnLookup.FlatStyle = FlatStyle.Flat;
            btnLookup.Location = new Point(335, 15);
            btnLookup.Name = "btnLookup";
            btnLookup.Size = new Size(66, 25);
            btnLookup.TabIndex = 2;
            btnLookup.Text = "Lookup";
            btnLookup.UseVisualStyleBackColor = false;
            btnLookup.Click += btnLookup_Click;
            // 
            // lblIsbnStatus
            // 
            lblIsbnStatus.AutoSize = true;
            lblIsbnStatus.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblIsbnStatus.ForeColor = SystemColors.GrayText;
            lblIsbnStatus.Location = new Point(126, 42);
            lblIsbnStatus.Name = "lblIsbnStatus";
            lblIsbnStatus.Size = new Size(0, 13);
            lblIsbnStatus.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(16, 65);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(39, 15);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "Title *";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(126, 62);
            txtTitle.MaxLength = 255;
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(275, 23);
            txtTitle.TabIndex = 5;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(16, 94);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(53, 15);
            lblAuthor.TabIndex = 6;
            lblAuthor.Text = "Author *";
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(126, 91);
            txtAuthor.MaxLength = 255;
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(275, 23);
            txtAuthor.TabIndex = 7;
            // 
            // lblPublisher
            // 
            lblPublisher.AutoSize = true;
            lblPublisher.Location = new Point(16, 123);
            lblPublisher.Name = "lblPublisher";
            lblPublisher.Size = new Size(56, 15);
            lblPublisher.TabIndex = 8;
            lblPublisher.Text = "Publisher";
            // 
            // txtPublisher
            // 
            txtPublisher.Location = new Point(126, 120);
            txtPublisher.MaxLength = 255;
            txtPublisher.Name = "txtPublisher";
            txtPublisher.Size = new Size(275, 23);
            txtPublisher.TabIndex = 9;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(16, 152);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(94, 15);
            lblYear.TabIndex = 10;
            lblYear.Text = "Publication Year";
            // 
            // txtYear
            // 
            txtYear.Location = new Point(126, 149);
            txtYear.MaxLength = 4;
            txtYear.Name = "txtYear";
            txtYear.PlaceholderText = "e.g. 2024";
            txtYear.Size = new Size(275, 23);
            txtYear.TabIndex = 11;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(16, 181);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(67, 15);
            lblDescription.TabIndex = 12;
            lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtDescription.Location = new Point(126, 178);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(275, 130);
            txtDescription.TabIndex = 13;
            // 
            // lblCover
            // 
            lblCover.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCover.AutoSize = true;
            lblCover.Location = new Point(16, 320);
            lblCover.Name = "lblCover";
            lblCover.Size = new Size(38, 15);
            lblCover.TabIndex = 14;
            lblCover.Text = "Cover";
            // 
            // txtCoverUrl
            // 
            txtCoverUrl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtCoverUrl.Location = new Point(126, 317);
            txtCoverUrl.Name = "txtCoverUrl";
            txtCoverUrl.PlaceholderText = "Image path or URL";
            txtCoverUrl.Size = new Size(187, 23);
            txtCoverUrl.TabIndex = 15;
            // 
            // btnSelectCover
            // 
            btnSelectCover.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSelectCover.BackColor = SystemColors.ControlLightLight;
            btnSelectCover.FlatStyle = FlatStyle.Flat;
            btnSelectCover.Location = new Point(319, 316);
            btnSelectCover.Name = "btnSelectCover";
            btnSelectCover.Size = new Size(82, 25);
            btnSelectCover.TabIndex = 16;
            btnSelectCover.Text = "Select File";
            btnSelectCover.UseVisualStyleBackColor = false;
            btnSelectCover.Click += btnSelectCover_Click;
            // 
            // lblExemplars
            // 
            lblExemplars.AutoSize = true;
            lblExemplars.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblExemplars.Location = new Point(421, 18);
            lblExemplars.Name = "lblExemplars";
            lblExemplars.Size = new Size(64, 15);
            lblExemplars.TabIndex = 17;
            lblExemplars.Text = "Exemplars";
            // 
            // btnRemoveCopy
            // 
            btnRemoveCopy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemoveCopy.BackColor = Color.FromArgb(255, 153, 102);
            btnRemoveCopy.FlatStyle = FlatStyle.Flat;
            btnRemoveCopy.Location = new Point(674, 14);
            btnRemoveCopy.Name = "btnRemoveCopy";
            btnRemoveCopy.Size = new Size(32, 25);
            btnRemoveCopy.TabIndex = 18;
            btnRemoveCopy.Text = "🗑️";
            btnRemoveCopy.UseVisualStyleBackColor = false;
            btnRemoveCopy.Click += btnRemoveCopy_Click;
            // 
            // btnAddCopy
            // 
            btnAddCopy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddCopy.BackColor = SystemColors.ControlLightLight;
            btnAddCopy.FlatStyle = FlatStyle.Flat;
            btnAddCopy.Location = new Point(712, 14);
            btnAddCopy.Name = "btnAddCopy";
            btnAddCopy.Size = new Size(32, 25);
            btnAddCopy.TabIndex = 19;
            btnAddCopy.Text = "➕";
            btnAddCopy.UseVisualStyleBackColor = false;
            btnAddCopy.Click += btnAddCopy_Click;
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
            dgvExemplars.Columns.AddRange(new DataGridViewColumn[] { colBarcode, colCondition, colStatus });
            dgvExemplars.EnableHeadersVisualStyles = false;
            dgvExemplars.Location = new Point(421, 45);
            dgvExemplars.MultiSelect = false;
            dgvExemplars.Name = "dgvExemplars";
            dgvExemplars.RowHeadersVisible = false;
            dgvExemplars.RowsDefaultCellStyle = rowStyle;
            dgvExemplars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExemplars.Size = new Size(323, 295);
            dgvExemplars.TabIndex = 20;
            dgvExemplars.CellBeginEdit += dgvExemplars_CellBeginEdit;
            // 
            // colBarcode
            // 
            colBarcode.DataPropertyName = "Barcode";
            colBarcode.HeaderText = "Barcode";
            colBarcode.Name = "colBarcode";
            // 
            // colCondition
            // 
            colCondition.DataPropertyName = "Condition";
            colCondition.HeaderText = "Condition";
            colCondition.Name = "colCondition";
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(153, 204, 51);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(558, 362);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 30);
            btnSave.TabIndex = 21;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = SystemColors.ControlLightLight;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(654, 362);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 30);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // BookDialog
            // 
            AcceptButton = btnSave;
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(760, 410);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dgvExemplars);
            Controls.Add(btnAddCopy);
            Controls.Add(btnRemoveCopy);
            Controls.Add(lblExemplars);
            Controls.Add(btnSelectCover);
            Controls.Add(txtCoverUrl);
            Controls.Add(lblCover);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(txtYear);
            Controls.Add(lblYear);
            Controls.Add(txtPublisher);
            Controls.Add(lblPublisher);
            Controls.Add(txtAuthor);
            Controls.Add(lblAuthor);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
            Controls.Add(lblIsbnStatus);
            Controls.Add(btnLookup);
            Controls.Add(txtIsbn);
            Controls.Add(lblIsbn);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add & Modify Book";
            Load += BookDialog_Load;
            ((System.ComponentModel.ISupportInitialize)dgvExemplars).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIsbn;
        private TextBox txtIsbn;
        private Button btnLookup;
        private Label lblIsbnStatus;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblAuthor;
        private TextBox txtAuthor;
        private Label lblPublisher;
        private TextBox txtPublisher;
        private Label lblYear;
        private TextBox txtYear;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblCover;
        private TextBox txtCoverUrl;
        private Button btnSelectCover;
        private Label lblExemplars;
        private Button btnRemoveCopy;
        private Button btnAddCopy;
        private DataGridView dgvExemplars;
        private DataGridViewTextBoxColumn colBarcode;
        private DataGridViewComboBoxColumn colCondition;
        private DataGridViewComboBoxColumn colStatus;
        private Button btnSave;
        private Button btnCancel;
    }
}
