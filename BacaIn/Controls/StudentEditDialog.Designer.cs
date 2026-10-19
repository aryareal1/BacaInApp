namespace BacaIn.Controls
{
    partial class StudentEditDialog
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
            layout = new TableLayoutPanel();
            headingLabel = new Label();
            usernameLabel = new Label();
            usernameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            displayNameLabel = new Label();
            displayNameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            passwordLabel = new Label();
            passwordTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            actionsLayout = new FlowLayoutPanel();
            saveButton = new Guna.UI2.WinForms.Guna2Button();
            cancelButton = new Guna.UI2.WinForms.Guna2Button();
            statusLabel = new Label();
            layout.SuspendLayout();
            actionsLayout.SuspendLayout();
            SuspendLayout();
            // 
            // layout
            // 
            layout.ColumnCount = 1;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.Controls.Add(headingLabel, 0, 0);
            layout.Controls.Add(usernameLabel, 0, 1);
            layout.Controls.Add(usernameTextBox, 0, 2);
            layout.Controls.Add(displayNameLabel, 0, 3);
            layout.Controls.Add(displayNameTextBox, 0, 4);
            layout.Controls.Add(passwordLabel, 0, 5);
            layout.Controls.Add(passwordTextBox, 0, 6);
            layout.Controls.Add(actionsLayout, 0, 7);
            layout.Dock = DockStyle.Fill;
            layout.Location = new Point(0, 0);
            layout.Name = "layout";
            layout.Padding = new Padding(24);
            layout.RowCount = 8;
            layout.RowStyles.Add(new RowStyle());
            layout.RowStyles.Add(new RowStyle());
            layout.RowStyles.Add(new RowStyle());
            layout.RowStyles.Add(new RowStyle());
            layout.RowStyles.Add(new RowStyle());
            layout.RowStyles.Add(new RowStyle());
            layout.RowStyles.Add(new RowStyle());
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.Size = new Size(460, 420);
            layout.TabIndex = 0;
            // 
            // headingLabel
            // 
            headingLabel.AutoSize = true;
            headingLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            headingLabel.ForeColor = Color.FromArgb(26, 26, 26);
            headingLabel.Location = new Point(24, 24);
            headingLabel.Margin = new Padding(0, 0, 0, 16);
            headingLabel.Name = "headingLabel";
            headingLabel.Size = new Size(198, 30);
            headingLabel.TabIndex = 0;
            headingLabel.Text = "Register Student";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            usernameLabel.ForeColor = Color.FromArgb(26, 26, 26);
            usernameLabel.Location = new Point(24, 70);
            usernameLabel.Margin = new Padding(0, 0, 0, 4);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(73, 17);
            usernameLabel.TabIndex = 1;
            usernameLabel.Text = "Username:";
            // 
            // usernameTextBox
            // 
            usernameTextBox.BorderColor = Color.FromArgb(128, 128, 128);
            usernameTextBox.BorderRadius = 4;
            usernameTextBox.DefaultText = "";
            usernameTextBox.Dock = DockStyle.Fill;
            usernameTextBox.Font = new Font("Segoe UI", 9.5F);
            usernameTextBox.Location = new Point(24, 91);
            usernameTextBox.Margin = new Padding(0, 0, 0, 14);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.PlaceholderText = "e.g. aji";
            usernameTextBox.Size = new Size(412, 38);
            usernameTextBox.TabIndex = 2;
            // 
            // displayNameLabel
            // 
            displayNameLabel.AutoSize = true;
            displayNameLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            displayNameLabel.ForeColor = Color.FromArgb(26, 26, 26);
            displayNameLabel.Location = new Point(24, 143);
            displayNameLabel.Margin = new Padding(0, 0, 0, 4);
            displayNameLabel.Name = "displayNameLabel";
            displayNameLabel.Size = new Size(98, 17);
            displayNameLabel.TabIndex = 3;
            displayNameLabel.Text = "Display Name:";
            // 
            // displayNameTextBox
            // 
            displayNameTextBox.BorderColor = Color.FromArgb(128, 128, 128);
            displayNameTextBox.BorderRadius = 4;
            displayNameTextBox.DefaultText = "";
            displayNameTextBox.Dock = DockStyle.Fill;
            displayNameTextBox.Font = new Font("Segoe UI", 9.5F);
            displayNameTextBox.Location = new Point(24, 164);
            displayNameTextBox.Margin = new Padding(0, 0, 0, 14);
            displayNameTextBox.Name = "displayNameTextBox";
            displayNameTextBox.PlaceholderText = "e.g. Aji Pratama";
            displayNameTextBox.Size = new Size(412, 38);
            displayNameTextBox.TabIndex = 4;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            passwordLabel.ForeColor = Color.FromArgb(26, 26, 26);
            passwordLabel.Location = new Point(24, 216);
            passwordLabel.Margin = new Padding(0, 0, 0, 4);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(70, 17);
            passwordLabel.TabIndex = 5;
            passwordLabel.Text = "Password:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.BorderColor = Color.FromArgb(128, 128, 128);
            passwordTextBox.BorderRadius = 4;
            passwordTextBox.DefaultText = "";
            passwordTextBox.Dock = DockStyle.Fill;
            passwordTextBox.Font = new Font("Segoe UI", 9.5F);
            passwordTextBox.Location = new Point(24, 237);
            passwordTextBox.Margin = new Padding(0, 0, 0, 18);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PlaceholderText = "Password";
            passwordTextBox.Size = new Size(412, 38);
            passwordTextBox.TabIndex = 6;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // actionsLayout
            // 
            actionsLayout.Controls.Add(saveButton);
            actionsLayout.Controls.Add(cancelButton);
            actionsLayout.Controls.Add(statusLabel);
            actionsLayout.Dock = DockStyle.Fill;
            actionsLayout.FlowDirection = FlowDirection.RightToLeft;
            actionsLayout.Location = new Point(24, 293);
            actionsLayout.Margin = new Padding(0);
            actionsLayout.Name = "actionsLayout";
            actionsLayout.Size = new Size(412, 103);
            actionsLayout.TabIndex = 7;
            // 
            // saveButton
            // 
            saveButton.BorderColor = Color.FromArgb(57, 112, 41);
            saveButton.BorderRadius = 4;
            saveButton.BorderThickness = 1;
            saveButton.FillColor = Color.FromArgb(57, 112, 41);
            saveButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(312, 0);
            saveButton.Margin = new Padding(8, 0, 0, 0);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(100, 38);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            // 
            // cancelButton
            // 
            cancelButton.BorderColor = Color.FromArgb(128, 128, 128);
            cancelButton.BorderRadius = 4;
            cancelButton.BorderThickness = 1;
            cancelButton.FillColor = Color.White;
            cancelButton.Font = new Font("Segoe UI", 10F);
            cancelButton.ForeColor = Color.FromArgb(26, 26, 26);
            cancelButton.Location = new Point(204, 0);
            cancelButton.Margin = new Padding(0);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 38);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Font = new Font("Segoe UI", 9F);
            statusLabel.ForeColor = Color.FromArgb(153, 27, 27);
            statusLabel.Location = new Point(360, 48);
            statusLabel.Margin = new Padding(0, 10, 0, 0);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(52, 15);
            statusLabel.TabIndex = 2;
            statusLabel.Text = "status...";
            statusLabel.Visible = false;
            // 
            // StudentEditDialog
            // 
            AcceptButton = saveButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 242, 242);
            ClientSize = new Size(460, 420);
            Controls.Add(layout);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StudentEditDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Student Profile";
            layout.ResumeLayout(false);
            layout.PerformLayout();
            actionsLayout.ResumeLayout(false);
            actionsLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel layout;
        private Label headingLabel;
        private Label usernameLabel;
        private Guna.UI2.WinForms.Guna2TextBox usernameTextBox;
        private Label displayNameLabel;
        private Guna.UI2.WinForms.Guna2TextBox displayNameTextBox;
        private Label passwordLabel;
        private Guna.UI2.WinForms.Guna2TextBox passwordTextBox;
        private FlowLayoutPanel actionsLayout;
        private Guna.UI2.WinForms.Guna2Button saveButton;
        private Guna.UI2.WinForms.Guna2Button cancelButton;
        private Label statusLabel;
    }
}
