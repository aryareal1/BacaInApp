namespace BacaIn
{
    partial class AdminForm
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
            pnlSidebaar = new Panel();
            tableLayoutPanel5 = new TableLayoutPanel();
            pictureBox5 = new BacaIn.Controls.CircularPictureBox();
            label5 = new Label();
            pbLogout = new PictureBox();
            sbReports = new TableLayoutPanel();
            pictureBox4 = new PictureBox();
            label4 = new Label();
            sbStudents = new TableLayoutPanel();
            pictureBox3 = new PictureBox();
            label3 = new Label();
            sbLoansReturns = new TableLayoutPanel();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            sbBooks = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            manageBooks = new BacaIn.Controls.ManageBooks();
            manageLoansReturns = new BacaIn.Controls.ManageLoansReturns();
            pnlSidebaar.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogout).BeginInit();
            sbReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            sbStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            sbLoansReturns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            sbBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlSidebaar
            // 
            pnlSidebaar.BackColor = SystemColors.ControlLight;
            pnlSidebaar.Controls.Add(tableLayoutPanel5);
            pnlSidebaar.Controls.Add(sbReports);
            pnlSidebaar.Controls.Add(sbStudents);
            pnlSidebaar.Controls.Add(sbLoansReturns);
            pnlSidebaar.Controls.Add(sbBooks);
            pnlSidebaar.Dock = DockStyle.Left;
            pnlSidebaar.Location = new Point(0, 0);
            pnlSidebaar.Name = "pnlSidebaar";
            pnlSidebaar.Size = new Size(187, 450);
            pnlSidebaar.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tableLayoutPanel5.ColumnCount = 3;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel5.Controls.Add(pictureBox5, 0, 0);
            tableLayoutPanel5.Controls.Add(label5, 1, 0);
            tableLayoutPanel5.Controls.Add(pbLogout, 2, 0);
            tableLayoutPanel5.Location = new Point(0, 404);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.Padding = new Padding(10, 3, 10, 3);
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(187, 34);
            tableLayoutPanel5.TabIndex = 1;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.pfp;
            pictureBox5.Location = new Point(13, 6);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(22, 22);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 0;
            pictureBox5.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(41, 3);
            label5.Name = "label5";
            label5.Size = new Size(103, 28);
            label5.TabIndex = 1;
            label5.Text = "Adumi";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pbLogout
            // 
            pbLogout.Cursor = Cursors.Hand;
            pbLogout.Image = Properties.Resources.user_logout;
            pbLogout.Location = new Point(150, 6);
            pbLogout.Name = "pbLogout";
            pbLogout.Size = new Size(24, 22);
            pbLogout.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogout.TabIndex = 2;
            pbLogout.TabStop = false;
            pbLogout.Click += pbLogout_Click;
            // 
            // sbReports
            // 
            sbReports.BackColor = SystemColors.ControlLight;
            sbReports.ColumnCount = 2;
            sbReports.ColumnStyles.Add(new ColumnStyle());
            sbReports.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            sbReports.Controls.Add(pictureBox4, 0, 0);
            sbReports.Controls.Add(label4, 1, 0);
            sbReports.Location = new Point(0, 102);
            sbReports.Name = "sbReports";
            sbReports.Padding = new Padding(10, 3, 10, 3);
            sbReports.RowCount = 1;
            sbReports.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            sbReports.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            sbReports.Size = new Size(187, 34);
            sbReports.TabIndex = 3;
            // 
            // pictureBox4
            // 
            pictureBox4.Dock = DockStyle.Fill;
            pictureBox4.Image = Properties.Resources.newspaper;
            pictureBox4.Location = new Point(13, 6);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(22, 22);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label4.Location = new Point(41, 3);
            label4.Name = "label4";
            label4.Size = new Size(133, 28);
            label4.TabIndex = 1;
            label4.Text = "Reports";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sbStudents
            // 
            sbStudents.BackColor = SystemColors.ControlLight;
            sbStudents.ColumnCount = 2;
            sbStudents.ColumnStyles.Add(new ColumnStyle());
            sbStudents.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            sbStudents.Controls.Add(pictureBox3, 0, 0);
            sbStudents.Controls.Add(label3, 1, 0);
            sbStudents.Location = new Point(0, 68);
            sbStudents.Name = "sbStudents";
            sbStudents.Padding = new Padding(10, 3, 10, 3);
            sbStudents.RowCount = 1;
            sbStudents.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            sbStudents.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            sbStudents.Size = new Size(187, 34);
            sbStudents.TabIndex = 2;
            // 
            // pictureBox3
            // 
            pictureBox3.Dock = DockStyle.Fill;
            pictureBox3.Image = Properties.Resources.users;
            pictureBox3.Location = new Point(13, 6);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(22, 22);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label3.Location = new Point(41, 3);
            label3.Name = "label3";
            label3.Size = new Size(133, 28);
            label3.TabIndex = 1;
            label3.Text = "Students";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sbLoansReturns
            // 
            sbLoansReturns.BackColor = SystemColors.ControlLight;
            sbLoansReturns.ColumnCount = 2;
            sbLoansReturns.ColumnStyles.Add(new ColumnStyle());
            sbLoansReturns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            sbLoansReturns.Controls.Add(pictureBox2, 0, 0);
            sbLoansReturns.Controls.Add(label2, 1, 0);
            sbLoansReturns.Cursor = Cursors.Hand;
            sbLoansReturns.Location = new Point(0, 34);
            sbLoansReturns.Name = "sbLoansReturns";
            sbLoansReturns.Padding = new Padding(10, 3, 10, 3);
            sbLoansReturns.RowCount = 1;
            sbLoansReturns.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            sbLoansReturns.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            sbLoansReturns.Size = new Size(187, 34);
            sbLoansReturns.TabIndex = 1;
            sbLoansReturns.Click += sbLoansReturns_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Image = Properties.Resources.loan;
            pictureBox2.Location = new Point(13, 6);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(22, 22);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += sbLoansReturns_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label2.Location = new Point(41, 3);
            label2.Name = "label2";
            label2.Size = new Size(133, 28);
            label2.TabIndex = 1;
            label2.Text = "Loans && Returns";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Click += sbLoansReturns_Click;
            // 
            // sbBooks
            // 
            sbBooks.BackColor = Color.FromArgb(117, 194, 59);
            sbBooks.ColumnCount = 2;
            sbBooks.ColumnStyles.Add(new ColumnStyle());
            sbBooks.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            sbBooks.Controls.Add(pictureBox1, 0, 0);
            sbBooks.Controls.Add(label1, 1, 0);
            sbBooks.Location = new Point(0, 0);
            sbBooks.Name = "sbBooks";
            sbBooks.Padding = new Padding(10, 3, 10, 3);
            sbBooks.RowCount = 1;
            sbBooks.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            sbBooks.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            sbBooks.Size = new Size(187, 34);
            sbBooks.TabIndex = 0;
            sbBooks.Click += sbBooks_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.books;
            pictureBox1.Location = new Point(13, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(22, 22);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += sbBooks_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label1.Location = new Point(41, 3);
            label1.Name = "label1";
            label1.Size = new Size(133, 28);
            label1.TabIndex = 1;
            label1.Text = "Books";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.Click += sbBooks_Click;
            // 
            // manageBooks
            // 
            manageBooks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            manageBooks.BackColor = SystemColors.Control;
            manageBooks.Location = new Point(187, 0);
            manageBooks.Name = "manageBooks";
            manageBooks.Size = new Size(749, 450);
            manageBooks.TabIndex = 1;
            // 
            // manageLoansReturns
            // 
            manageLoansReturns.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            manageLoansReturns.Location = new Point(187, 0);
            manageLoansReturns.Name = "manageLoansReturns";
            manageLoansReturns.Size = new Size(749, 450);
            manageLoansReturns.TabIndex = 2;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(936, 450);
            Controls.Add(manageBooks);
            Controls.Add(manageLoansReturns);
            Controls.Add(pnlSidebaar);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BacaIn App";
            pnlSidebaar.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogout).EndInit();
            sbReports.ResumeLayout(false);
            sbReports.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            sbStudents.ResumeLayout(false);
            sbStudents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            sbLoansReturns.ResumeLayout(false);
            sbLoansReturns.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            sbBooks.ResumeLayout(false);
            sbBooks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebaar;
        private TableLayoutPanel sbBooks;
        private PictureBox pictureBox1;
        private Label label1;
        private TableLayoutPanel sbLoansReturns;
        private PictureBox pictureBox2;
        private Label label2;
        private TableLayoutPanel sbStudents;
        private PictureBox pictureBox3;
        private Label label3;
        private TableLayoutPanel sbReports;
        private PictureBox pictureBox4;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel5;
        private Controls.CircularPictureBox pictureBox5;
        private Label label5;
        private PictureBox pbLogout;
        private Controls.ManageBooks manageBooks;
        private Controls.ManageLoansReturns manageLoansReturns;
    }
}