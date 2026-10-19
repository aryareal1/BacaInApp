using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BacaIn.Models;
using BacaIn.Services;

namespace BacaIn.Controls
{
    public partial class StudentEditDialog : Form
    {
        private readonly User? _student;

        public StudentEditDialog(User? student = null)
        {
            InitializeComponent();
            _student = student;

            if (_student != null)
            {
                headingLabel.Text = "Edit Student Profile";
                usernameTextBox.Text = _student.Username;
                usernameTextBox.Enabled = false; // Username cannot be changed
                displayNameTextBox.Text = _student.DisplayName ?? "";
                passwordTextBox.PlaceholderText = "Leave empty to keep current password";
                saveButton.Text = "Save Changes";
            }
            else
            {
                headingLabel.Text = "Register Student";
                saveButton.Text = "Register";
            }

            saveButton.Click += async (s, e) => await HandleSaveAsync();
            cancelButton.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        private async Task HandleSaveAsync()
        {
            var username = usernameTextBox.Text.Trim();
            var displayName = displayNameTextBox.Text.Trim();
            var password = passwordTextBox.Text;

            if (string.IsNullOrEmpty(username))
            {
                ShowStatus("Username is required.", isError: true);
                usernameTextBox.Focus();
                return;
            }

            if (_student == null && string.IsNullOrEmpty(password))
            {
                ShowStatus("Password is required for new students.", isError: true);
                passwordTextBox.Focus();
                return;
            }

            saveButton.Enabled = false;
            saveButton.Text = "Saving...";

            try
            {
                if (_student == null)
                {
                    await AuthService.Instance.RegisterStudentAsync(username, displayName, password);
                }
                else
                {
                    await AuthService.Instance.UpdateStudentAsync(_student.Id, displayName, string.IsNullOrEmpty(password) ? null : password);
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ShowStatus("Error: " + ex.Message, isError: true);
                saveButton.Enabled = true;
                saveButton.Text = _student == null ? "Register" : "Save Changes";
            }
        }

        private void ShowStatus(string message, bool isError)
        {
            statusLabel.Text = message;
            statusLabel.ForeColor = isError ? Color.FromArgb(153, 27, 27) : Color.FromArgb(22, 101, 52);
            statusLabel.Visible = true;
        }
    }
}
