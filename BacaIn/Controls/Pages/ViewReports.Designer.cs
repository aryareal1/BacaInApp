namespace BacaIn.Controls
{
    partial class ViewReports
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
            lblReportType = new Label();
            cmbReportType = new ComboBox();
            btnPrint = new Button();
            lblFrom = new Label();
            dtpFrom = new DateTimePicker();
            lblTo = new Label();
            dtpTo = new DateTimePicker();
            btnApply = new Button();
            tlpCards = new TableLayoutPanel();
            pnlCard1 = new Panel();
            lblCard1Value = new Label();
            lblCard1Title = new Label();
            pnlCard2 = new Panel();
            lblCard2Value = new Label();
            lblCard2Title = new Label();
            pnlCard3 = new Panel();
            lblCard3Value = new Label();
            lblCard3Title = new Label();
            dataGridView1 = new DataGridView();
            tlpCards.SuspendLayout();
            pnlCard1.SuspendLayout();
            pnlCard2.SuspendLayout();
            pnlCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 5);
            label1.Name = "label1";
            label1.Size = new Size(131, 25);
            label1.TabIndex = 0;
            label1.Text = "View Reports";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(9, 30);
            label2.Name = "label2";
            label2.Size = new Size(216, 15);
            label2.TabIndex = 1;
            label2.Text = "View and print library activity reports";
            // 
            // lblReportType
            // 
            lblReportType.AutoSize = true;
            lblReportType.Location = new Point(11, 64);
            lblReportType.Name = "lblReportType";
            lblReportType.Size = new Size(69, 15);
            lblReportType.TabIndex = 2;
            lblReportType.Text = "Report type";
            // 
            // cmbReportType
            // 
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportType.FormattingEnabled = true;
            cmbReportType.Location = new Point(92, 61);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(190, 23);
            cmbReportType.TabIndex = 3;
            cmbReportType.SelectedIndexChanged += cmbReportType_SelectedIndexChanged;
            // 
            // btnPrint
            // 
            btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrint.BackColor = SystemColors.ControlLightLight;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Location = new Point(642, 60);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(96, 25);
            btnPrint.TabIndex = 4;
            btnPrint.Text = "🖨️ Print";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(11, 97);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(35, 15);
            lblFrom.TabIndex = 5;
            lblFrom.Text = "From";
            // 
            // dtpFrom
            // 
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(52, 94);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(120, 23);
            dtpFrom.TabIndex = 6;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new Point(182, 97);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(20, 15);
            lblTo.TabIndex = 7;
            lblTo.Text = "To";
            // 
            // dtpTo
            // 
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(208, 94);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(120, 23);
            dtpTo.TabIndex = 8;
            // 
            // btnApply
            // 
            btnApply.BackColor = Color.FromArgb(153, 204, 51);
            btnApply.FlatStyle = FlatStyle.Flat;
            btnApply.Location = new Point(338, 93);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(75, 25);
            btnApply.TabIndex = 9;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = false;
            btnApply.Click += btnApply_Click;
            // 
            // tlpCards
            // 
            tlpCards.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlpCards.ColumnCount = 3;
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpCards.Controls.Add(pnlCard1, 0, 0);
            tlpCards.Controls.Add(pnlCard2, 1, 0);
            tlpCards.Controls.Add(pnlCard3, 2, 0);
            tlpCards.Location = new Point(11, 130);
            tlpCards.Name = "tlpCards";
            tlpCards.RowCount = 1;
            tlpCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpCards.Size = new Size(727, 56);
            tlpCards.TabIndex = 10;
            // 
            // pnlCard1
            // 
            pnlCard1.BackColor = Color.FromArgb(236, 246, 226);
            pnlCard1.BorderStyle = BorderStyle.FixedSingle;
            pnlCard1.Controls.Add(lblCard1Value);
            pnlCard1.Controls.Add(lblCard1Title);
            pnlCard1.Dock = DockStyle.Fill;
            pnlCard1.Location = new Point(0, 0);
            pnlCard1.Margin = new Padding(0, 0, 6, 0);
            pnlCard1.Name = "pnlCard1";
            pnlCard1.Size = new Size(236, 56);
            pnlCard1.TabIndex = 0;
            // 
            // lblCard1Value
            // 
            lblCard1Value.AutoSize = true;
            lblCard1Value.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCard1Value.ForeColor = Color.Black;
            lblCard1Value.Location = new Point(10, 24);
            lblCard1Value.Name = "lblCard1Value";
            lblCard1Value.Size = new Size(19, 21);
            lblCard1Value.TabIndex = 1;
            lblCard1Value.Text = "0";
            // 
            // lblCard1Title
            // 
            lblCard1Title.AutoSize = true;
            lblCard1Title.ForeColor = Color.FromArgb(64, 64, 64);
            lblCard1Title.Location = new Point(10, 6);
            lblCard1Title.Name = "lblCard1Title";
            lblCard1Title.Size = new Size(74, 15);
            lblCard1Title.TabIndex = 0;
            lblCard1Title.Text = "Loans issued";
            // 
            // pnlCard2
            // 
            pnlCard2.BackColor = Color.FromArgb(219, 239, 199);
            pnlCard2.BorderStyle = BorderStyle.FixedSingle;
            pnlCard2.Controls.Add(lblCard2Value);
            pnlCard2.Controls.Add(lblCard2Title);
            pnlCard2.Dock = DockStyle.Fill;
            pnlCard2.Location = new Point(248, 0);
            pnlCard2.Margin = new Padding(6, 0, 6, 0);
            pnlCard2.Name = "pnlCard2";
            pnlCard2.Size = new Size(230, 56);
            pnlCard2.TabIndex = 1;
            // 
            // lblCard2Value
            // 
            lblCard2Value.AutoSize = true;
            lblCard2Value.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCard2Value.ForeColor = Color.Black;
            lblCard2Value.Location = new Point(10, 24);
            lblCard2Value.Name = "lblCard2Value";
            lblCard2Value.Size = new Size(19, 21);
            lblCard2Value.TabIndex = 1;
            lblCard2Value.Text = "0";
            // 
            // lblCard2Title
            // 
            lblCard2Title.AutoSize = true;
            lblCard2Title.ForeColor = Color.FromArgb(64, 64, 64);
            lblCard2Title.Location = new Point(10, 6);
            lblCard2Title.Name = "lblCard2Title";
            lblCard2Title.Size = new Size(47, 15);
            lblCard2Title.TabIndex = 0;
            lblCard2Title.Text = "Returns";
            // 
            // pnlCard3
            // 
            pnlCard3.BackColor = Color.FromArgb(255, 232, 219);
            pnlCard3.BorderStyle = BorderStyle.FixedSingle;
            pnlCard3.Controls.Add(lblCard3Value);
            pnlCard3.Controls.Add(lblCard3Title);
            pnlCard3.Dock = DockStyle.Fill;
            pnlCard3.Location = new Point(490, 0);
            pnlCard3.Margin = new Padding(6, 0, 0, 0);
            pnlCard3.Name = "pnlCard3";
            pnlCard3.Size = new Size(237, 56);
            pnlCard3.TabIndex = 2;
            // 
            // lblCard3Value
            // 
            lblCard3Value.AutoSize = true;
            lblCard3Value.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCard3Value.ForeColor = Color.Black;
            lblCard3Value.Location = new Point(10, 24);
            lblCard3Value.Name = "lblCard3Value";
            lblCard3Value.Size = new Size(19, 21);
            lblCard3Value.TabIndex = 1;
            lblCard3Value.Text = "0";
            // 
            // lblCard3Title
            // 
            lblCard3Title.AutoSize = true;
            lblCard3Title.ForeColor = Color.FromArgb(64, 64, 64);
            lblCard3Title.Location = new Point(10, 6);
            lblCard3Title.Name = "lblCard3Title";
            lblCard3Title.Size = new Size(79, 15);
            lblCard3Title.TabIndex = 0;
            lblCard3Title.Text = "Overdue now";
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLight;
            dataGridView1.ColumnHeadersDefaultCellStyle = headerStyle;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(11, 196);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowsDefaultCellStyle = rowStyle;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(727, 236);
            dataGridView1.TabIndex = 13;
            // 
            // ViewReports
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            BackColor = SystemColors.Control;
            Controls.Add(dataGridView1);
            Controls.Add(tlpCards);
            Controls.Add(btnApply);
            Controls.Add(dtpTo);
            Controls.Add(lblTo);
            Controls.Add(dtpFrom);
            Controls.Add(lblFrom);
            Controls.Add(btnPrint);
            Controls.Add(cmbReportType);
            Controls.Add(lblReportType);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ViewReports";
            Size = new Size(749, 450);
            tlpCards.ResumeLayout(false);
            pnlCard1.ResumeLayout(false);
            pnlCard1.PerformLayout();
            pnlCard2.ResumeLayout(false);
            pnlCard2.PerformLayout();
            pnlCard3.ResumeLayout(false);
            pnlCard3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label lblReportType;
        private ComboBox cmbReportType;
        private Button btnPrint;
        private Label lblFrom;
        private DateTimePicker dtpFrom;
        private Label lblTo;
        private DateTimePicker dtpTo;
        private Button btnApply;
        private TableLayoutPanel tlpCards;
        private Panel pnlCard1;
        private Label lblCard1Value;
        private Label lblCard1Title;
        private Panel pnlCard2;
        private Label lblCard2Value;
        private Label lblCard2Title;
        private Panel pnlCard3;
        private Label lblCard3Value;
        private Label lblCard3Title;
        private DataGridView dataGridView1;
    }
}
