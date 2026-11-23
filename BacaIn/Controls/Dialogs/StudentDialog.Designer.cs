namespace BacaIn.Controls
{
    partial class StudentDialog
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
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblDisplayName = new Label();
            txtDisplayName = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblAvatar = new Label();
            txtAvatarUrl = new TextBox();
            btnSelectAvatar = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(16, 19);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(71, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username *";
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.Location = new Point(116, 16);
            txtUsername.MaxLength = 255;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(276, 23);
            txtUsername.TabIndex = 1;
            // 
            // lblDisplayName
            // 
            lblDisplayName.AutoSize = true;
            lblDisplayName.Location = new Point(16, 48);
            lblDisplayName.Name = "lblDisplayName";
            lblDisplayName.Size = new Size(80, 15);
            lblDisplayName.TabIndex = 2;
            lblDisplayName.Text = "Display Name";
            // 
            // txtDisplayName
            // 
            txtDisplayName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDisplayName.Location = new Point(116, 45);
            txtDisplayName.MaxLength = 255;
            txtDisplayName.Name = "txtDisplayName";
            txtDisplayName.Size = new Size(276, 23);
            txtDisplayName.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(16, 77);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(65, 15);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password *";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(116, 74);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(276, 23);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblAvatar
            // 
            lblAvatar.AutoSize = true;
            lblAvatar.Location = new Point(16, 106);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(41, 15);
            lblAvatar.TabIndex = 6;
            lblAvatar.Text = "Avatar";
            // 
            // txtAvatarUrl
            // 
            txtAvatarUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAvatarUrl.Location = new Point(116, 103);
            txtAvatarUrl.Name = "txtAvatarUrl";
            txtAvatarUrl.PlaceholderText = "Image path or URL";
            txtAvatarUrl.Size = new Size(188, 23);
            txtAvatarUrl.TabIndex = 7;
            // 
            // btnSelectAvatar
            // 
            btnSelectAvatar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelectAvatar.BackColor = SystemColors.ControlLightLight;
            btnSelectAvatar.FlatStyle = FlatStyle.Flat;
            btnSelectAvatar.Location = new Point(310, 102);
            btnSelectAvatar.Name = "btnSelectAvatar";
            btnSelectAvatar.Size = new Size(82, 25);
            btnSelectAvatar.TabIndex = 8;
            btnSelectAvatar.Text = "Select File";
            btnSelectAvatar.UseVisualStyleBackColor = false;
            btnSelectAvatar.Click += btnSelectAvatar_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(153, 204, 51);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(206, 146);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 30);
            btnSave.TabIndex = 9;
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
            btnCancel.Location = new Point(302, 146);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 30);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // StudentDialog
            // 
            AcceptButton = btnSave;
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(408, 192);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(btnSelectAvatar);
            Controls.Add(txtAvatarUrl);
            Controls.Add(lblAvatar);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtDisplayName);
            Controls.Add(lblDisplayName);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StudentDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add & Modify Student";
            Load += StudentDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblDisplayName;
        private TextBox txtDisplayName;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblAvatar;
        private TextBox txtAvatarUrl;
        private Button btnSelectAvatar;
        private Button btnSave;
        private Button btnCancel;
    }
}
