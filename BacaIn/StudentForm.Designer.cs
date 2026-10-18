namespace BacaIn
{
    partial class StudentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentForm));
            shellLayout = new TableLayoutPanel();
            sidebarLayout = new TableLayoutPanel();
            brandingLayout = new TableLayoutPanel();
            logoPictureBox = new Guna.UI2.WinForms.Guna2PictureBox();
            brandLabel = new Label();
            roleLabel = new Label();
            navigationLayout = new TableLayoutPanel();
            catalogButton = new Guna.UI2.WinForms.Guna2Button();
            loansButton = new Guna.UI2.WinForms.Guna2Button();
            reservationsButton = new Guna.UI2.WinForms.Guna2Button();
            historyButton = new Guna.UI2.WinForms.Guna2Button();
            previewLabel = new Label();
            logoutButton = new Guna.UI2.WinForms.Guna2Button();
            contentPanel = new Guna.UI2.WinForms.Guna2Panel();
            catalogPage = new CatalogPage();
            bookDetailPage = new BookDetailPage();
            myLoansPage = new MyLoansPage();
            myReservationsPage = new MyReservationsPage();
            checkInHistoryPage = new CheckInHistoryPage();
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
            brandLabel.ForeColor = Color.FromArgb(47, 93, 80);
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
            roleLabel.ForeColor = Color.FromArgb(95, 111, 103);
            roleLabel.Margin = new Padding(0);
            roleLabel.Name = "roleLabel";
            roleLabel.TabIndex = 2;
            roleLabel.Text = "STUDENT PORTAL";
            roleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // navigationLayout
            // 
            navigationLayout.AutoSize = true;
            navigationLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            navigationLayout.ColumnCount = 1;
            navigationLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            navigationLayout.Controls.Add(catalogButton, 0, 0);
            navigationLayout.Controls.Add(loansButton, 0, 1);
            navigationLayout.Controls.Add(reservationsButton, 0, 2);
            navigationLayout.Controls.Add(historyButton, 0, 3);
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
            // catalogButton
            // 
            catalogButton.AccessibleName = "Catalog";
            catalogButton.AccessibleDescription = "Open the Catalog design-preview page";
            catalogButton.BorderColor = Color.White;
            catalogButton.BorderThickness = 1;
            catalogButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            catalogButton.Checked = true;
            catalogButton.CheckedState.BorderColor = Color.FromArgb(229, 239, 232);
            catalogButton.CheckedState.CustomBorderColor = Color.FromArgb(47, 93, 80);
            catalogButton.CheckedState.FillColor = Color.FromArgb(229, 239, 232);
            catalogButton.CheckedState.ForeColor = Color.FromArgb(47, 93, 80);
            catalogButton.CustomBorderColor = Color.White;
            catalogButton.CustomBorderThickness = new Padding(4, 0, 0, 0);
            catalogButton.Dock = DockStyle.Top;
            catalogButton.FillColor = Color.White;
            catalogButton.FocusedColor = Color.FromArgb(47, 93, 80);
            catalogButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            catalogButton.ForeColor = Color.FromArgb(36, 51, 46);
            catalogButton.HoverState.BorderColor = Color.FromArgb(120, 135, 126);
            catalogButton.HoverState.FillColor = Color.FromArgb(229, 239, 232);
            catalogButton.HoverState.ForeColor = Color.FromArgb(36, 72, 62);
            catalogButton.Margin = new Padding(0, 0, 0, 8);
            catalogButton.Name = "catalogButton";
            catalogButton.PressedColor = Color.FromArgb(36, 72, 62);
            catalogButton.Size = new Size(200, 48);
            catalogButton.TabIndex = 0;
            catalogButton.Text = "Catalog";
            catalogButton.TextAlign = HorizontalAlignment.Left;
            catalogButton.TextOffset = new Point(12, 0);
            catalogButton.Click += catalogButton_Click;
            // 
            // loansButton
            // 
            loansButton.AccessibleName = "My Loans";
            loansButton.AccessibleDescription = "Open the My Loans design-preview page";
            loansButton.BorderColor = Color.White;
            loansButton.BorderThickness = 1;
            loansButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            loansButton.CheckedState.BorderColor = Color.FromArgb(229, 239, 232);
            loansButton.CheckedState.CustomBorderColor = Color.FromArgb(47, 93, 80);
            loansButton.CheckedState.FillColor = Color.FromArgb(229, 239, 232);
            loansButton.CheckedState.ForeColor = Color.FromArgb(47, 93, 80);
            loansButton.CustomBorderColor = Color.White;
            loansButton.CustomBorderThickness = new Padding(4, 0, 0, 0);
            loansButton.Dock = DockStyle.Top;
            loansButton.FillColor = Color.White;
            loansButton.FocusedColor = Color.FromArgb(47, 93, 80);
            loansButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            loansButton.ForeColor = Color.FromArgb(36, 51, 46);
            loansButton.HoverState.BorderColor = Color.FromArgb(120, 135, 126);
            loansButton.HoverState.FillColor = Color.FromArgb(229, 239, 232);
            loansButton.HoverState.ForeColor = Color.FromArgb(36, 72, 62);
            loansButton.Margin = new Padding(0, 0, 0, 8);
            loansButton.Name = "loansButton";
            loansButton.PressedColor = Color.FromArgb(36, 72, 62);
            loansButton.Size = new Size(200, 48);
            loansButton.TabIndex = 1;
            loansButton.Text = "My Loans";
            loansButton.TextAlign = HorizontalAlignment.Left;
            loansButton.TextOffset = new Point(12, 0);
            loansButton.Click += loansButton_Click;
            // 
            // reservationsButton
            // 
            reservationsButton.AccessibleName = "My Reservations";
            reservationsButton.AccessibleDescription = "Open the My Reservations design-preview page";
            reservationsButton.BorderColor = Color.White;
            reservationsButton.BorderThickness = 1;
            reservationsButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            reservationsButton.CheckedState.BorderColor = Color.FromArgb(229, 239, 232);
            reservationsButton.CheckedState.CustomBorderColor = Color.FromArgb(47, 93, 80);
            reservationsButton.CheckedState.FillColor = Color.FromArgb(229, 239, 232);
            reservationsButton.CheckedState.ForeColor = Color.FromArgb(47, 93, 80);
            reservationsButton.CustomBorderColor = Color.White;
            reservationsButton.CustomBorderThickness = new Padding(4, 0, 0, 0);
            reservationsButton.Dock = DockStyle.Top;
            reservationsButton.FillColor = Color.White;
            reservationsButton.FocusedColor = Color.FromArgb(47, 93, 80);
            reservationsButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            reservationsButton.ForeColor = Color.FromArgb(36, 51, 46);
            reservationsButton.HoverState.BorderColor = Color.FromArgb(120, 135, 126);
            reservationsButton.HoverState.FillColor = Color.FromArgb(229, 239, 232);
            reservationsButton.HoverState.ForeColor = Color.FromArgb(36, 72, 62);
            reservationsButton.Margin = new Padding(0, 0, 0, 8);
            reservationsButton.Name = "reservationsButton";
            reservationsButton.PressedColor = Color.FromArgb(36, 72, 62);
            reservationsButton.Size = new Size(200, 48);
            reservationsButton.TabIndex = 2;
            reservationsButton.Text = "My Reservations";
            reservationsButton.TextAlign = HorizontalAlignment.Left;
            reservationsButton.TextOffset = new Point(12, 0);
            reservationsButton.Click += reservationsButton_Click;
            // 
            // historyButton
            // 
            historyButton.AccessibleName = "Check-in History";
            historyButton.AccessibleDescription = "Open the Check-in History design-preview page";
            historyButton.BorderColor = Color.White;
            historyButton.BorderThickness = 1;
            historyButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            historyButton.CheckedState.BorderColor = Color.FromArgb(229, 239, 232);
            historyButton.CheckedState.CustomBorderColor = Color.FromArgb(47, 93, 80);
            historyButton.CheckedState.FillColor = Color.FromArgb(229, 239, 232);
            historyButton.CheckedState.ForeColor = Color.FromArgb(47, 93, 80);
            historyButton.CustomBorderColor = Color.White;
            historyButton.CustomBorderThickness = new Padding(4, 0, 0, 0);
            historyButton.Dock = DockStyle.Top;
            historyButton.FillColor = Color.White;
            historyButton.FocusedColor = Color.FromArgb(47, 93, 80);
            historyButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            historyButton.ForeColor = Color.FromArgb(36, 51, 46);
            historyButton.HoverState.BorderColor = Color.FromArgb(120, 135, 126);
            historyButton.HoverState.FillColor = Color.FromArgb(229, 239, 232);
            historyButton.HoverState.ForeColor = Color.FromArgb(36, 72, 62);
            historyButton.Margin = new Padding(0, 0, 0, 8);
            historyButton.Name = "historyButton";
            historyButton.PressedColor = Color.FromArgb(36, 72, 62);
            historyButton.Size = new Size(200, 48);
            historyButton.TabIndex = 3;
            historyButton.Text = "Check-in History";
            historyButton.TextAlign = HorizontalAlignment.Left;
            historyButton.TextOffset = new Point(12, 0);
            historyButton.Click += historyButton_Click;
            // 
            // previewLabel
            // 
            previewLabel.AutoSize = true;
            previewLabel.Dock = DockStyle.Fill;
            previewLabel.Font = new Font("Segoe UI", 10F);
            previewLabel.ForeColor = Color.FromArgb(95, 111, 103);
            previewLabel.Margin = new Padding(8, 16, 8, 16);
            previewLabel.Name = "previewLabel";
            previewLabel.TabIndex = 2;
            previewLabel.Text = "Design preview — student services not connected.";
            // 
            // logoutButton
            // 
            logoutButton.AccessibleName = "Log out";
            logoutButton.AccessibleDescription = "Design preview only. Authentication is not connected.";
            logoutButton.BorderColor = Color.FromArgb(120, 135, 126);
            logoutButton.BorderThickness = 1;
            logoutButton.Dock = DockStyle.Top;
            logoutButton.FillColor = Color.White;
            logoutButton.FocusedColor = Color.FromArgb(47, 93, 80);
            logoutButton.Font = new Font("Segoe UI", 11F);
            logoutButton.ForeColor = Color.FromArgb(36, 51, 46);
            logoutButton.HoverState.BorderColor = Color.FromArgb(47, 93, 80);
            logoutButton.HoverState.FillColor = Color.FromArgb(229, 239, 232);
            logoutButton.Margin = new Padding(0);
            logoutButton.Name = "logoutButton";
            logoutButton.PressedColor = Color.FromArgb(36, 72, 62);
            logoutButton.Size = new Size(200, 48);
            logoutButton.TabIndex = 3;
            logoutButton.Text = "Log out";
            // 
            // contentPanel
            // 
            contentPanel.AccessibleName = "Student portal page content";
            contentPanel.BackColor = Color.FromArgb(247, 248, 244);
            contentPanel.Controls.Add(catalogPage);
            contentPanel.Controls.Add(bookDetailPage);
            contentPanel.Controls.Add(myLoansPage);
            contentPanel.Controls.Add(myReservationsPage);
            contentPanel.Controls.Add(checkInHistoryPage);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.FillColor = Color.FromArgb(247, 248, 244);
            contentPanel.Margin = new Padding(0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1048, 800);
            contentPanel.TabIndex = 1;
            // 
            // catalogPage
            // 
            catalogPage.Dock = DockStyle.Fill;
            catalogPage.Margin = new Padding(0);
            catalogPage.Name = "catalogPage";
            catalogPage.Size = new Size(1048, 800);
            catalogPage.TabIndex = 0;
            catalogPage.ViewDetailRequested += catalogPage_ViewDetailRequested;
            // 
            // bookDetailPage
            // 
            bookDetailPage.Dock = DockStyle.Fill;
            bookDetailPage.Margin = new Padding(0);
            bookDetailPage.Name = "bookDetailPage";
            bookDetailPage.Size = new Size(1048, 800);
            bookDetailPage.TabIndex = 1;
            bookDetailPage.BackToCatalogRequested += bookDetailPage_BackToCatalogRequested;
            // 
            // myLoansPage
            // 
            myLoansPage.Dock = DockStyle.Fill;
            myLoansPage.Margin = new Padding(0);
            myLoansPage.Name = "myLoansPage";
            myLoansPage.Size = new Size(1048, 800);
            myLoansPage.TabIndex = 2;
            // 
            // myReservationsPage
            // 
            myReservationsPage.Dock = DockStyle.Fill;
            myReservationsPage.Margin = new Padding(0);
            myReservationsPage.Name = "myReservationsPage";
            myReservationsPage.Size = new Size(1048, 800);
            myReservationsPage.TabIndex = 3;
            // 
            // checkInHistoryPage
            // 
            checkInHistoryPage.Dock = DockStyle.Fill;
            checkInHistoryPage.Margin = new Padding(0);
            checkInHistoryPage.Name = "checkInHistoryPage";
            checkInHistoryPage.Size = new Size(1048, 800);
            checkInHistoryPage.TabIndex = 4;
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 248, 244);
            ClientSize = new Size(1280, 800);
            Controls.Add(shellLayout);
            Font = new Font("Segoe UI", 9F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1100, 720);
            Name = "StudentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BacaIn — Student Portal";
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
        private Guna.UI2.WinForms.Guna2Button catalogButton;
        private Guna.UI2.WinForms.Guna2Button loansButton;
        private Guna.UI2.WinForms.Guna2Button reservationsButton;
        private Guna.UI2.WinForms.Guna2Button historyButton;
        private Label previewLabel;
        private Guna.UI2.WinForms.Guna2Button logoutButton;
        private Guna.UI2.WinForms.Guna2Panel contentPanel;
        private CatalogPage catalogPage;
        private BookDetailPage bookDetailPage;
        private MyLoansPage myLoansPage;
        private MyReservationsPage myReservationsPage;
        private CheckInHistoryPage checkInHistoryPage;
    }
}
