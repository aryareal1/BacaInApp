using System;
using System.Drawing;
using System.Windows.Forms;
using BacaIn.Services;

namespace BacaIn
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            KeyPreview = true;
            loginButton.Click += async (s, e) => await HandleLoginAsync();
            KeyDown += LoginForm_KeyDown;
        }

        private async Task HandleLoginAsync()
        {
            var username = usernameTextBox.Text.Trim();
            var password = passwordTextBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                accessHelpLabel.ForeColor = Color.FromArgb(153, 27, 27);
                accessHelpLabel.Text = "Please enter username and password.";
                return;
            }

            loginButton.Enabled = false;
            loginButton.Text = "Logging in...";

            try
            {
                var user = await AuthService.Instance.LoginAsync(username, password);
                if (user == null)
                {
                    accessHelpLabel.ForeColor = Color.FromArgb(153, 27, 27);
                    accessHelpLabel.Text = "Invalid username or password.";
                    passwordTextBox.Clear();
                    passwordTextBox.Focus();
                    return;
                }

                // Reset error state
                accessHelpLabel.ForeColor = Color.FromArgb(102, 102, 102);
                accessHelpLabel.Text = "Need access? Ask your librarian.";
                passwordTextBox.Clear();

                Hide();

                if (user.IsAdmin)
                {
                    var adminForm = new AdminForm();
                    adminForm.FormClosed += (s, e) =>
                    {
                        usernameTextBox.Clear();
                        Show();
                        usernameTextBox.Focus();
                    };
                    adminForm.Show();
                }
                else
                {
                    var studentForm = new StudentForm();
                    studentForm.FormClosed += (s, e) =>
                    {
                        usernameTextBox.Clear();
                        Show();
                        usernameTextBox.Focus();
                    };
                    studentForm.Show();
                }
            }
            catch (Exception ex)
            {
                accessHelpLabel.ForeColor = Color.FromArgb(153, 27, 27);
                accessHelpLabel.Text = "Database connection error: " + ex.Message;
            }
            finally
            {
                loginButton.Enabled = true;
                loginButton.Text = "Log In";
            }
        }

        private void LoginForm_KeyDown(object? sender, KeyEventArgs e)
        {
            // Secret hotkey Ctrl+Shift+K to open Check-in Kiosk
            if (e.Control && e.Shift && e.KeyCode == Keys.K)
            {
                e.SuppressKeyPress = true;
                OpenCheckinKiosk();
            }
        }

        private void OpenCheckinKiosk()
        {
            // Placeholder: CheckinForm will be opened here once created in Task 3
            var checkinType = Type.GetType("BacaIn.CheckinForm, BacaIn");
            if (checkinType != null)
            {
                var form = (Form)Activator.CreateInstance(checkinType)!;
                form.Show();
            }
        }
    }
}
