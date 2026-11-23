using BacaIn.Data;
using BacaIn.Models;
using Microsoft.EntityFrameworkCore;

namespace BacaIn
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Sign In",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new AppDbContext();
                var user = db.Users.AsNoTracking()
                    .FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

                if (user is null || !DatabaseSeeder.VerifyPassword(password, user.PasswordHash))
                {
                    MessageBox.Show("Invalid username or password.", "Sign In",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.SelectAll();
                    txtPassword.Focus();
                    return;
                }

                txtPassword.Clear();
                Hide();

                if (user.Role == UserRole.Admin)
                {
                    var admin = new AdminForm(user);
                    admin.FormClosed += (_, _) =>
                    {
                        if (admin.LoggingOut)
                            Show();
                        else
                            Close();
                    };
                    admin.Show();
                }
                else
                {
                    var student = new StudentForm();
                    student.FormClosed += (_, _) => Close();
                    student.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not sign in:\n{ex.Message}", "BacaIn",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
