namespace BacaIn
{
    partial class CheckinForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pageLayout = new TableLayoutPanel();
            kioskPanel = new Guna.UI2.WinForms.Guna2Panel();
            formLayout = new TableLayoutPanel();
            titleLabel = new Label();
            subtitleLabel = new Label();
            usernameLabel = new Label();
            usernameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            checkinButton = new Guna.UI2.WinForms.Guna2Button();
            feedbackPanel = new Guna.UI2.WinForms.Guna2Panel();
            feedbackLabel = new Label();
            footerLabel = new Label();
            closeButton = new Guna.UI2.WinForms.Guna2Button();
            resetTimer = new System.Windows.Forms.Timer(components);
            pageLayout.SuspendLayout();
            kioskPanel.SuspendLayout();
            formLayout.SuspendLayout();
            feedbackPanel.SuspendLayout();
            SuspendLayout();
            // 
            // pageLayout
            // 
            pageLayout.AutoScroll = true;
            pageLayout.ColumnCount = 1;
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.Controls.Add(kioskPanel, 0, 1);
            pageLayout.Dock = DockStyle.Fill;
            pageLayout.Location = new Point(0, 0);
            pageLayout.Name = "pageLayout";
            pageLayout.Padding = new Padding(24);
            pageLayout.RowCount = 3;
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            pageLayout.RowStyles.Add(new RowStyle());
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            pageLayout.Size = new Size(680, 640);
            pageLayout.TabIndex = 0;
            // 
            // kioskPanel
            // 
            kioskPanel.Anchor = AnchorStyles.None;
            kioskPanel.AutoSize = true;
            kioskPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            kioskPanel.BackColor = Color.White;
            kioskPanel.BorderColor = Color.FromArgb(204, 204, 204);
            kioskPanel.BorderRadius = 8;
            kioskPanel.BorderThickness = 1;
            kioskPanel.Controls.Add(formLayout);
            kioskPanel.FillColor = Color.White;
            kioskPanel.Location = new Point(100, 70);
            kioskPanel.Margin = new Padding(0);
            kioskPanel.MaximumSize = new Size(500, 0);
            kioskPanel.MinimumSize = new Size(460, 0);
            kioskPanel.Name = "kioskPanel";
            kioskPanel.Padding = new Padding(32);
            kioskPanel.Size = new Size(480, 500);
            kioskPanel.TabIndex = 0;
            // 
            // formLayout
            // 
            formLayout.AutoSize = true;
            formLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            formLayout.ColumnCount = 1;
            formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            formLayout.Controls.Add(titleLabel, 0, 0);
            formLayout.Controls.Add(subtitleLabel, 0, 1);
            formLayout.Controls.Add(usernameLabel, 0, 2);
            formLayout.Controls.Add(usernameTextBox, 0, 3);
            formLayout.Controls.Add(checkinButton, 0, 4);
            formLayout.Controls.Add(feedbackPanel, 0, 5);
            formLayout.Controls.Add(footerLabel, 0, 6);
            formLayout.Controls.Add(closeButton, 0, 7);
            formLayout.Dock = DockStyle.Fill;
            formLayout.Location = new Point(32, 32);
            formLayout.Name = "formLayout";
            formLayout.RowCount = 8;
            formLayout.RowStyles.Add(new RowStyle());
            formLayout.RowStyles.Add(new RowStyle());
            formLayout.RowStyles.Add(new RowStyle());
            formLayout.RowStyles.Add(new RowStyle());
            formLayout.RowStyles.Add(new RowStyle());
            formLayout.RowStyles.Add(new RowStyle());
            formLayout.RowStyles.Add(new RowStyle());
            formLayout.RowStyles.Add(new RowStyle());
            formLayout.Size = new Size(416, 436);
            formLayout.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(57, 112, 41);
            titleLabel.Location = new Point(0, 0);
            titleLabel.Margin = new Padding(0, 0, 0, 6);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(416, 41);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "BacaIn • Library Check-In";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.Dock = DockStyle.Fill;
            subtitleLabel.Font = new Font("Segoe UI", 10.5F);
            subtitleLabel.ForeColor = Color.FromArgb(102, 102, 102);
            subtitleLabel.Location = new Point(0, 47);
            subtitleLabel.Margin = new Padding(0, 0, 0, 24);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(416, 19);
            subtitleLabel.TabIndex = 1;
            subtitleLabel.Text = "Scan your student card or enter your username";
            subtitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Dock = DockStyle.Fill;
            usernameLabel.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            usernameLabel.ForeColor = Color.FromArgb(26, 26, 26);
            usernameLabel.Location = new Point(0, 90);
            usernameLabel.Margin = new Padding(0, 0, 0, 6);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(416, 19);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "Student Username / Card ID";
            // 
            // usernameTextBox
            // 
            usernameTextBox.AccessibleName = "Username";
            usernameTextBox.BorderColor = Color.FromArgb(128, 128, 128);
            usernameTextBox.BorderRadius = 4;
            usernameTextBox.Cursor = Cursors.IBeam;
            usernameTextBox.DefaultText = "";
            usernameTextBox.Dock = DockStyle.Fill;
            usernameTextBox.FocusedState.BorderColor = Color.FromArgb(57, 112, 41);
            usernameTextBox.Font = new Font("Segoe UI", 12F);
            usernameTextBox.ForeColor = Color.FromArgb(26, 26, 26);
            usernameTextBox.HoverState.BorderColor = Color.FromArgb(57, 112, 41);
            usernameTextBox.Location = new Point(0, 115);
            usernameTextBox.Margin = new Padding(0, 0, 0, 16);
            usernameTextBox.MinimumSize = new Size(0, 46);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.PlaceholderText = "e.g. aji";
            usernameTextBox.SelectedText = "";
            usernameTextBox.Size = new Size(416, 46);
            usernameTextBox.TabIndex = 3;
            // 
            // checkinButton
            // 
            checkinButton.AccessibleName = "Check In";
            checkinButton.BorderColor = Color.FromArgb(57, 112, 41);
            checkinButton.BorderRadius = 4;
            checkinButton.BorderThickness = 1;
            checkinButton.Dock = DockStyle.Fill;
            checkinButton.FillColor = Color.FromArgb(57, 112, 41);
            checkinButton.FocusedColor = Color.FromArgb(38, 74, 28);
            checkinButton.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            checkinButton.ForeColor = Color.White;
            checkinButton.HoverState.BorderColor = Color.FromArgb(38, 74, 28);
            checkinButton.HoverState.FillColor = Color.FromArgb(38, 74, 28);
            checkinButton.Location = new Point(0, 177);
            checkinButton.Margin = new Padding(0, 0, 0, 16);
            checkinButton.MinimumSize = new Size(0, 46);
            checkinButton.Name = "checkinButton";
            checkinButton.PressedDepth = 20;
            checkinButton.Size = new Size(416, 46);
            checkinButton.TabIndex = 4;
            checkinButton.Text = "Record Check-In";
            // 
            // feedbackPanel
            // 
            feedbackPanel.BorderRadius = 6;
            feedbackPanel.Controls.Add(feedbackLabel);
            feedbackPanel.Dock = DockStyle.Fill;
            feedbackPanel.FillColor = Color.FromArgb(220, 252, 231);
            feedbackPanel.Location = new Point(0, 239);
            feedbackPanel.Margin = new Padding(0, 0, 0, 16);
            feedbackPanel.MinimumSize = new Size(0, 60);
            feedbackPanel.Name = "feedbackPanel";
            feedbackPanel.Padding = new Padding(12);
            feedbackPanel.Size = new Size(416, 60);
            feedbackPanel.TabIndex = 5;
            feedbackPanel.Visible = false;
            // 
            // feedbackLabel
            // 
            feedbackLabel.Dock = DockStyle.Fill;
            feedbackLabel.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            feedbackLabel.ForeColor = Color.FromArgb(22, 101, 52);
            feedbackLabel.Location = new Point(12, 12);
            feedbackLabel.Name = "feedbackLabel";
            feedbackLabel.Size = new Size(392, 36);
            feedbackLabel.TabIndex = 0;
            feedbackLabel.Text = "Welcome! Check-in recorded.";
            feedbackLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // footerLabel
            // 
            footerLabel.AutoSize = true;
            footerLabel.Dock = DockStyle.Fill;
            footerLabel.Font = new Font("Segoe UI", 9.5F);
            footerLabel.ForeColor = Color.FromArgb(102, 102, 102);
            footerLabel.Location = new Point(0, 315);
            footerLabel.Margin = new Padding(0, 0, 0, 16);
            footerLabel.Name = "footerLabel";
            footerLabel.Size = new Size(416, 17);
            footerLabel.TabIndex = 6;
            footerLabel.Text = "Check-in is recorded once per day per student.";
            footerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.None;
            closeButton.BorderColor = Color.FromArgb(204, 204, 204);
            closeButton.BorderRadius = 4;
            closeButton.BorderThickness = 1;
            closeButton.FillColor = Color.White;
            closeButton.Font = new Font("Segoe UI", 9.5F);
            closeButton.ForeColor = Color.FromArgb(102, 102, 102);
            closeButton.HoverState.BorderColor = Color.FromArgb(128, 128, 128);
            closeButton.HoverState.FillColor = Color.FromArgb(242, 242, 242);
            closeButton.Location = new Point(158, 348);
            closeButton.Margin = new Padding(0);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(100, 32);
            closeButton.TabIndex = 7;
            closeButton.Text = "Close Kiosk";
            // 
            // resetTimer
            // 
            resetTimer.Interval = 4000;
            // 
            // CheckinForm
            // 
            AcceptButton = checkinButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 242, 242);
            ClientSize = new Size(680, 640);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.FromArgb(26, 26, 26);
            MinimumSize = new Size(540, 580);
            Name = "CheckinForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BacaIn • Entrance Check-In Kiosk";
            pageLayout.ResumeLayout(false);
            pageLayout.PerformLayout();
            kioskPanel.ResumeLayout(false);
            kioskPanel.PerformLayout();
            formLayout.ResumeLayout(false);
            formLayout.PerformLayout();
            feedbackPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel pageLayout;
        private Guna.UI2.WinForms.Guna2Panel kioskPanel;
        private TableLayoutPanel formLayout;
        private Label titleLabel;
        private Label subtitleLabel;
        private Label usernameLabel;
        private Guna.UI2.WinForms.Guna2TextBox usernameTextBox;
        private Guna.UI2.WinForms.Guna2Button checkinButton;
        private Guna.UI2.WinForms.Guna2Panel feedbackPanel;
        private Label feedbackLabel;
        private Label footerLabel;
        private Guna.UI2.WinForms.Guna2Button closeButton;
        private System.Windows.Forms.Timer resetTimer;
    }
}
