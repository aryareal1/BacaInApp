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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            shellLayout = new TableLayoutPanel();
            sidebarLayout = new TableLayoutPanel();
            brandingLayout = new TableLayoutPanel();
            logoPictureBox = new Guna.UI2.WinForms.Guna2PictureBox();
            brandLabel = new Label();
            roleLabel = new Label();
            navigationLayout = new TableLayoutPanel();
            booksButton = new Guna.UI2.WinForms.Guna2Button();
            loansReturnsButton = new Guna.UI2.WinForms.Guna2Button();
            studentsButton = new Guna.UI2.WinForms.Guna2Button();
            reportsButton = new Guna.UI2.WinForms.Guna2Button();
            previewLabel = new Label();
            logoutButton = new Guna.UI2.WinForms.Guna2Button();
            contentPanel = new Guna.UI2.WinForms.Guna2Panel();
            booksPage = new BooksPage();
            loansReturnsPage = new LoansReturnsPage();
            studentsPage = new StudentsPage();
            reportsPage = new ReportsPage();
            shellLayout.SuspendLayout();
            sidebarLayout.SuspendLayout();
            brandingLayout.SuspendLayout();
            navigationLayout.SuspendLayout();
            contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            SuspendLayout();
            //
            // shellLayout
            //
            shellLayout.ColumnCount = 2;
            shellLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 232F));
            shellLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            shellLayout.Controls.Add(sidebarLayout, 0, 0);
            shellLayout.Controls.Add(contentPanel, 1, 0);
            shellLayout.Dock = DockStyle.Fill;
            shellLayout.Margin = new Padding(0);
            shellLayout.Name = "shellLayout";
            shellLayout.RowCount = 1;
            shellLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            shellLayout.Size = new Size(1280, 800);
            shellLayout.TabIndex = 0;
            //
            // sidebarLayout
            //
            sidebarLayout.AutoScroll = true;
            sidebarLayout.BackColor = Color.White;
            sidebarLayout.ColumnCount = 1;
            sidebarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            sidebarLayout.Controls.Add(brandingLayout, 0, 0);
            sidebarLayout.Controls.Add(navigationLayout, 0, 1);
            sidebarLayout.Controls.Add(previewLabel, 0, 3);
            sidebarLayout.Controls.Add(logoutButton, 0, 4);
            sidebarLayout.Dock = DockStyle.Fill;
            sidebarLayout.Margin = new Padding(0);
            sidebarLayout.Name = "sidebarLayout";
            sidebarLayout.Padding = new Padding(16, 24, 16, 24);
            sidebarLayout.RowCount = 5;
            sidebarLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            sidebarLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            sidebarLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            sidebarLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            sidebarLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            sidebarLayout.Size = new Size(232, 800);
            sidebarLayout.TabIndex = 0;
            //
            // brandingLayout
            //
            brandingLayout.AutoSize = true;
            brandingLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            brandingLayout.ColumnCount = 1;
            brandingLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            brandingLayout.Controls.Add(logoPictureBox, 0, 0);
            brandingLayout.Controls.Add(brandLabel, 0, 1);
            brandingLayout.Controls.Add(roleLabel, 0, 2);
            brandingLayout.Dock = DockStyle.Top;
            brandingLayout.Margin = new Padding(0, 0, 0, 32);
            brandingLayout.Name = "brandingLayout";
            brandingLayout.RowCount = 3;
            brandingLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            brandingLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            brandingLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            brandingLayout.TabIndex = 0;
            //
            // logoPictureBox
            //
            logoPictureBox.AccessibleName = "BacaIn library logo";
            logoPictureBox.Anchor = AnchorStyles.None;
            logoPictureBox.BackColor = Color.Transparent;
            logoPictureBox.Image = (Image)resources.GetObject("logoPictureBox.Image");
            logoPictureBox.ImageRotate = 0F;
            logoPictureBox.Margin = new Padding(0, 0, 0, 8);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(72, 72);
            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPictureBox.TabIndex = 0;
            logoPictureBox.TabStop = false;
            //
            // brandLabel
            //
            brandLabel.AutoSize = true;
            brandLabel.Dock = DockStyle.Fill;
            brandLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            brandLabel.ForeColor = Color.FromArgb(57, 112, 41);
            brandLabel.Margin = new Padding(0, 0, 0, 4);
            brandLabel.Name = "brandLabel";
            brandLabel.TabIndex = 1;
            brandLabel.Text = "BacaIn";
            brandLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // roleLabel
            //
            roleLabel.AutoSize = true;
            roleLabel.Dock = DockStyle.Fill;
            roleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            roleLabel.ForeColor = Color.FromArgb(102, 102, 102);
            roleLabel.Margin = new Padding(0);
            roleLabel.Name = "roleLabel";
            roleLabel.TabIndex = 2;
            roleLabel.Text = "LIBRARY ADMIN";
            roleLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // navigationLayout
            //
            navigationLayout.AutoSize = true;
            navigationLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            navigationLayout.ColumnCount = 1;
            navigationLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            navigationLayout.Controls.Add(booksButton, 0, 0);
            navigationLayout.Controls.Add(loansReturnsButton, 0, 1);
            navigationLayout.Controls.Add(studentsButton, 0, 2);
            navigationLayout.Controls.Add(reportsButton, 0, 3);
            navigationLayout.Dock = DockStyle.Top;
            navigationLayout.Margin = new Padding(0);
            navigationLayout.Name = "navigationLayout";
            navigationLayout.RowCount = 4;
            navigationLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            navigationLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            navigationLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            navigationLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            navigationLayout.TabIndex = 1;
            //
            // booksButton
            //
            booksButton.AccessibleName = "Books";
            booksButton.AccessibleDescription = "Open the Books design-preview page";
            booksButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            booksButton.BorderColor = Color.White;
            booksButton.BorderThickness = 1;
            booksButton.CheckedState.BorderColor = Color.FromArgb(223, 241, 218);
            booksButton.CheckedState.CustomBorderColor = Color.FromArgb(57, 112, 41);
            booksButton.CheckedState.FillColor = Color.FromArgb(223, 241, 218);
            booksButton.CheckedState.ForeColor = Color.FromArgb(57, 112, 41);
            booksButton.CustomBorderColor = Color.White;
            booksButton.CustomBorderThickness = new Padding(4, 0, 0, 0);
            booksButton.Dock = DockStyle.Top;
            booksButton.FillColor = Color.White;
            booksButton.FocusedColor = Color.FromArgb(57, 112, 41);
            booksButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            booksButton.ForeColor = Color.FromArgb(26, 26, 26);
            booksButton.HoverState.BorderColor = Color.FromArgb(128, 128, 128);
            booksButton.HoverState.FillColor = Color.FromArgb(223, 241, 218);
            booksButton.HoverState.ForeColor = Color.FromArgb(38, 74, 28);
            booksButton.Margin = new Padding(0, 0, 0, 8);
            booksButton.Name = "booksButton";
            booksButton.PressedColor = Color.FromArgb(38, 74, 28);
            booksButton.Size = new Size(200, 48);
            booksButton.TabIndex = 0;
            booksButton.Text = "Books";
            booksButton.TextAlign = HorizontalAlignment.Left;
            booksButton.TextOffset = new Point(12, 0);
            booksButton.Click += booksButton_Click;
            //
            // loansReturnsButton
            //
            loansReturnsButton.AccessibleName = "Loans & Returns";
            loansReturnsButton.AccessibleDescription = "Open the Loans & Returns design-preview page";
            loansReturnsButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            loansReturnsButton.BorderColor = Color.White;
            loansReturnsButton.BorderThickness = 1;
            loansReturnsButton.CheckedState.BorderColor = Color.FromArgb(223, 241, 218);
            loansReturnsButton.CheckedState.CustomBorderColor = Color.FromArgb(57, 112, 41);
            loansReturnsButton.CheckedState.FillColor = Color.FromArgb(223, 241, 218);
            loansReturnsButton.CheckedState.ForeColor = Color.FromArgb(57, 112, 41);
            loansReturnsButton.CustomBorderColor = Color.White;
            loansReturnsButton.CustomBorderThickness = new Padding(4, 0, 0, 0);
            loansReturnsButton.Dock = DockStyle.Top;
            loansReturnsButton.FillColor = Color.White;
            loansReturnsButton.FocusedColor = Color.FromArgb(57, 112, 41);
            loansReturnsButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            loansReturnsButton.ForeColor = Color.FromArgb(26, 26, 26);
            loansReturnsButton.HoverState.BorderColor = Color.FromArgb(128, 128, 128);
            loansReturnsButton.HoverState.FillColor = Color.FromArgb(223, 241, 218);
            loansReturnsButton.HoverState.ForeColor = Color.FromArgb(38, 74, 28);
            loansReturnsButton.Margin = new Padding(0, 0, 0, 8);
            loansReturnsButton.Name = "loansReturnsButton";
            loansReturnsButton.PressedColor = Color.FromArgb(38, 74, 28);
            loansReturnsButton.Size = new Size(200, 48);
            loansReturnsButton.TabIndex = 1;
            loansReturnsButton.Text = "Loans && Returns";
            loansReturnsButton.TextAlign = HorizontalAlignment.Left;
            loansReturnsButton.TextOffset = new Point(12, 0);
            loansReturnsButton.Click += loansReturnsButton_Click;
            //
            // studentsButton
            //
            studentsButton.AccessibleName = "Students";
            studentsButton.AccessibleDescription = "Open the Students design-preview page";
            studentsButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            studentsButton.BorderColor = Color.White;
            studentsButton.BorderThickness = 1;
            studentsButton.CheckedState.BorderColor = Color.FromArgb(223, 241, 218);
            studentsButton.CheckedState.CustomBorderColor = Color.FromArgb(57, 112, 41);
            studentsButton.CheckedState.FillColor = Color.FromArgb(223, 241, 218);
            studentsButton.CheckedState.ForeColor = Color.FromArgb(57, 112, 41);
            studentsButton.CustomBorderColor = Color.White;
            studentsButton.CustomBorderThickness = new Padding(4, 0, 0, 0);
            studentsButton.Dock = DockStyle.Top;
            studentsButton.FillColor = Color.White;
            studentsButton.FocusedColor = Color.FromArgb(57, 112, 41);
            studentsButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            studentsButton.ForeColor = Color.FromArgb(26, 26, 26);
            studentsButton.HoverState.BorderColor = Color.FromArgb(128, 128, 128);
            studentsButton.HoverState.FillColor = Color.FromArgb(223, 241, 218);
            studentsButton.HoverState.ForeColor = Color.FromArgb(38, 74, 28);
            studentsButton.Margin = new Padding(0, 0, 0, 8);
            studentsButton.Name = "studentsButton";
            studentsButton.PressedColor = Color.FromArgb(38, 74, 28);
            studentsButton.Size = new Size(200, 48);
            studentsButton.TabIndex = 2;
            studentsButton.Text = "Students";
            studentsButton.TextAlign = HorizontalAlignment.Left;
            studentsButton.TextOffset = new Point(12, 0);
            studentsButton.Click += studentsButton_Click;
            //
            // reportsButton
            //
            reportsButton.AccessibleName = "Reports";
            reportsButton.AccessibleDescription = "Open the Reports design-preview page";
            reportsButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            reportsButton.BorderColor = Color.White;
            reportsButton.BorderThickness = 1;
            reportsButton.CheckedState.BorderColor = Color.FromArgb(223, 241, 218);
            reportsButton.CheckedState.CustomBorderColor = Color.FromArgb(57, 112, 41);
            reportsButton.CheckedState.FillColor = Color.FromArgb(223, 241, 218);
            reportsButton.CheckedState.ForeColor = Color.FromArgb(57, 112, 41);
            reportsButton.CustomBorderColor = Color.White;
            reportsButton.CustomBorderThickness = new Padding(4, 0, 0, 0);
            reportsButton.Dock = DockStyle.Top;
            reportsButton.FillColor = Color.White;
            reportsButton.FocusedColor = Color.FromArgb(57, 112, 41);
            reportsButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            reportsButton.ForeColor = Color.FromArgb(26, 26, 26);
            reportsButton.HoverState.BorderColor = Color.FromArgb(128, 128, 128);
            reportsButton.HoverState.FillColor = Color.FromArgb(223, 241, 218);
            reportsButton.HoverState.ForeColor = Color.FromArgb(38, 74, 28);
            reportsButton.Margin = new Padding(0, 0, 0, 8);
            reportsButton.Name = "reportsButton";
            reportsButton.PressedColor = Color.FromArgb(38, 74, 28);
            reportsButton.Size = new Size(200, 48);
            reportsButton.TabIndex = 3;
            reportsButton.Text = "Reports";
            reportsButton.TextAlign = HorizontalAlignment.Left;
            reportsButton.TextOffset = new Point(12, 0);
            reportsButton.Click += reportsButton_Click;
            booksButton.Checked = true;
            //
            // previewLabel
            //
            previewLabel.AutoSize = true;
            previewLabel.Dock = DockStyle.Fill;
            previewLabel.Font = new Font("Segoe UI", 10F);
            previewLabel.ForeColor = Color.FromArgb(102, 102, 102);
            previewLabel.Margin = new Padding(8, 16, 8, 16);
            previewLabel.Name = "previewLabel";
            previewLabel.TabIndex = 2;
            previewLabel.Text = "Design preview — admin services not connected.";
            //
            // logoutButton
            //
            logoutButton.AccessibleName = "Log out";
            logoutButton.AccessibleDescription = "Design preview only. Authentication is not connected.";
            logoutButton.BorderColor = Color.FromArgb(128, 128, 128);
            logoutButton.BorderThickness = 1;
            logoutButton.Dock = DockStyle.Top;
            logoutButton.FillColor = Color.White;
            logoutButton.FocusedColor = Color.FromArgb(57, 112, 41);
            logoutButton.Font = new Font("Segoe UI", 11F);
            logoutButton.ForeColor = Color.FromArgb(26, 26, 26);
            logoutButton.HoverState.BorderColor = Color.FromArgb(57, 112, 41);
            logoutButton.HoverState.FillColor = Color.FromArgb(223, 241, 218);
            logoutButton.Margin = new Padding(0);
            logoutButton.Name = "logoutButton";
            logoutButton.PressedColor = Color.FromArgb(38, 74, 28);
            logoutButton.Size = new Size(200, 48);
            logoutButton.TabIndex = 3;
            logoutButton.Text = "Log out";
            //
            // contentPanel
            //
            contentPanel.AccessibleName = "Administration page content";
            contentPanel.BackColor = Color.FromArgb(242, 242, 242);
            contentPanel.Controls.Add(booksPage);
            contentPanel.Controls.Add(loansReturnsPage);
            contentPanel.Controls.Add(studentsPage);
            contentPanel.Controls.Add(reportsPage);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.FillColor = Color.FromArgb(242, 242, 242);
            contentPanel.Margin = new Padding(0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1048, 800);
            contentPanel.TabIndex = 1;
            //
            // booksPage
            //
            booksPage.Dock = DockStyle.Fill;
            booksPage.Margin = new Padding(0);
            booksPage.Name = "booksPage";
            booksPage.Size = new Size(1048, 800);
            booksPage.TabIndex = 0;
            //
            // loansReturnsPage
            //
            loansReturnsPage.Dock = DockStyle.Fill;
            loansReturnsPage.Margin = new Padding(0);
            loansReturnsPage.Name = "loansReturnsPage";
            loansReturnsPage.Size = new Size(1048, 800);
            loansReturnsPage.TabIndex = 1;
            //
            // studentsPage
            //
            studentsPage.Dock = DockStyle.Fill;
            studentsPage.Margin = new Padding(0);
            studentsPage.Name = "studentsPage";
            studentsPage.Size = new Size(1048, 800);
            studentsPage.TabIndex = 2;
            //
            // reportsPage
            //
            reportsPage.Dock = DockStyle.Fill;
            reportsPage.Margin = new Padding(0);
            reportsPage.Name = "reportsPage";
            reportsPage.Size = new Size(1048, 800);
            reportsPage.TabIndex = 3;
            //
            // AdminForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 242, 242);
            ClientSize = new Size(1280, 800);
            Controls.Add(shellLayout);
            Font = new Font("Segoe UI", 9F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1100, 720);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BacaIn — Administration";
            shellLayout.ResumeLayout(false);
            sidebarLayout.ResumeLayout(false);
            sidebarLayout.PerformLayout();
            brandingLayout.ResumeLayout(false);
            brandingLayout.PerformLayout();
            navigationLayout.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel shellLayout;
        private TableLayoutPanel sidebarLayout;
        private TableLayoutPanel brandingLayout;
        private Guna.UI2.WinForms.Guna2PictureBox logoPictureBox;
        private Label brandLabel;
        private Label roleLabel;
        private TableLayoutPanel navigationLayout;
        private Guna.UI2.WinForms.Guna2Button booksButton;
        private Guna.UI2.WinForms.Guna2Button loansReturnsButton;
        private Guna.UI2.WinForms.Guna2Button studentsButton;
        private Guna.UI2.WinForms.Guna2Button reportsButton;
        private Label previewLabel;
        private Guna.UI2.WinForms.Guna2Button logoutButton;
        private Guna.UI2.WinForms.Guna2Panel contentPanel;
        private BooksPage booksPage;
        private LoansReturnsPage loansReturnsPage;
        private StudentsPage studentsPage;
        private ReportsPage reportsPage;
    }
}