namespace BacaIn.Controls
{
    partial class ManageBooks
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnCreate = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            titleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            authorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isbnDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            publisherDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            yearDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            copiesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bookRowBindingSource = new BindingSource(components);
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bookRowBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 5);
            label1.Name = "label1";
            label1.Size = new Size(144, 25);
            label1.TabIndex = 0;
            label1.Text = "Manage Books";
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Location = new Point(11, 64);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search title, author, etc...";
            txtSearch.Size = new Size(255, 23);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.ControlLightLight;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Location = new Point(272, 64);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(28, 23);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "🔍";
            btnSearch.TextAlign = ContentAlignment.TopCenter;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnCreate
            // 
            btnCreate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreate.BackColor = Color.FromArgb(153, 204, 51);
            btnCreate.BackgroundImageLayout = ImageLayout.None;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Location = new Point(641, 64);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(97, 23);
            btnCreate.TabIndex = 3;
            btnCreate.Text = "➕ Add Book";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.BackColor = SystemColors.ControlLightLight;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(607, 64);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(28, 23);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "✏️";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BackColor = Color.FromArgb(255, 153, 102);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(573, 64);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(28, 23);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "🗑️";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
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
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.BackgroundColor = SystemColors.ControlLight;
            dataGridView1.ColumnHeadersDefaultCellStyle = headerStyle;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, titleDataGridViewTextBoxColumn, authorDataGridViewTextBoxColumn, isbnDataGridViewTextBoxColumn, publisherDataGridViewTextBoxColumn, yearDataGridViewTextBoxColumn, copiesDataGridViewTextBoxColumn });
            dataGridView1.DataSource = bookRowBindingSource;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(11, 100);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowsDefaultCellStyle = rowStyle;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(727, 328);
            dataGridView1.TabIndex = 6;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Visible = false;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            titleDataGridViewTextBoxColumn.HeaderText = "Title";
            titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // authorDataGridViewTextBoxColumn
            // 
            authorDataGridViewTextBoxColumn.DataPropertyName = "Author";
            authorDataGridViewTextBoxColumn.HeaderText = "Author";
            authorDataGridViewTextBoxColumn.Name = "authorDataGridViewTextBoxColumn";
            authorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isbnDataGridViewTextBoxColumn
            // 
            isbnDataGridViewTextBoxColumn.DataPropertyName = "Isbn";
            isbnDataGridViewTextBoxColumn.HeaderText = "ISBN";
            isbnDataGridViewTextBoxColumn.Name = "isbnDataGridViewTextBoxColumn";
            isbnDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // publisherDataGridViewTextBoxColumn
            // 
            publisherDataGridViewTextBoxColumn.DataPropertyName = "Publisher";
            publisherDataGridViewTextBoxColumn.HeaderText = "Publisher";
            publisherDataGridViewTextBoxColumn.Name = "publisherDataGridViewTextBoxColumn";
            publisherDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // yearDataGridViewTextBoxColumn
            // 
            yearDataGridViewTextBoxColumn.DataPropertyName = "Year";
            yearDataGridViewTextBoxColumn.HeaderText = "Year";
            yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
            yearDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // copiesDataGridViewTextBoxColumn
            // 
            copiesDataGridViewTextBoxColumn.DataPropertyName = "Copies";
            copiesDataGridViewTextBoxColumn.HeaderText = "Copies";
            copiesDataGridViewTextBoxColumn.Name = "copiesDataGridViewTextBoxColumn";
            copiesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bookRowBindingSource
            // 
            bookRowBindingSource.DataSource = typeof(BookRow);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(9, 30);
            label2.Name = "label2";
            label2.Size = new Size(236, 15);
            label2.TabIndex = 7;
            label2.Text = "Manage bibliographies and their exemplars";
            // 
            // ManageBooks
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            BackColor = SystemColors.Control;
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnCreate);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Name = "ManageBooks";
            Size = new Size(749, 450);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bookRowBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnCreate;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridView dataGridView1;
        private Label label2;
        private BindingSource bookRowBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn authorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn isbnDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn publisherDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn copiesDataGridViewTextBoxColumn;
    }
}
