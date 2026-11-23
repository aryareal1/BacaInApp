using BacaIn.Data;
using BacaIn.Models;
using Microsoft.EntityFrameworkCore;

namespace BacaIn.Controls;

/// <summary>Unified modal dialog for adding and modifying a student <see cref="User"/>.</summary>
public partial class StudentDialog : Form
{
    private readonly int? _studentId;

    /// <summary>Gets the ID of the created or edited student after a successful save.</summary>
    public int SavedStudentId { get; private set; }

    public StudentDialog() : this(null)
    {
    }

    public StudentDialog(int? studentId)
    {
        _studentId = studentId;
        InitializeComponent();

        if (studentId.HasValue)
        {
            Text = "Modify Student";
            lblPassword.Text = "Password";
            txtPassword.PlaceholderText = "Leave blank to keep current";
        }
        else
        {
            Text = "Add Student";
        }
    }

    private void StudentDialog_Load(object? sender, EventArgs e)
    {
        if (DesignMode || !_studentId.HasValue)
            return;

        try
        {
            using var db = new AppDbContext();
            var student = db.Users.AsNoTracking()
                .FirstOrDefault(u => u.Id == _studentId.Value && u.Role == UserRole.Student);

            if (student is null)
            {
                MessageBox.Show("The selected student could not be found.", "BacaIn",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            txtUsername.Text = student.Username;
            txtDisplayName.Text = student.DisplayName ?? string.Empty;
            txtAvatarUrl.Text = student.AvatarUrl ?? string.Empty;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not load student details:\n{ex.Message}", "BacaIn",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

    private void btnSelectAvatar_Click(object? sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog
        {
            Title = "Select Student Avatar",
            Filter = "Image Files|*.jpg;*.jpeg;*.png;*.webp;*.bmp|All Files|*.*",
        };
        if (ofd.ShowDialog(this) == DialogResult.OK)
            txtAvatarUrl.Text = ofd.FileName;
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        var username = txtUsername.Text.Trim();
        var displayName = txtDisplayName.Text.Trim();
        var password = txtPassword.Text;
        var avatarUrl = txtAvatarUrl.Text.Trim();

        if (string.IsNullOrWhiteSpace(username))
        {
            MessageBox.Show("Username is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtUsername.Focus();
            return;
        }

        if (!_studentId.HasValue && string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Password is required for a new student.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPassword.Focus();
            return;
        }

        try
        {
            using var db = new AppDbContext();
            var duplicate = db.Users.AsNoTracking()
                .Any(u => u.Username.ToLower() == username.ToLower() && u.Id != (_studentId ?? 0));

            if (duplicate)
            {
                MessageBox.Show($"Username \"{username}\" is already taken.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            var now = DateTime.UtcNow;

            if (_studentId.HasValue)
            {
                var student = db.Users.FirstOrDefault(u => u.Id == _studentId.Value && u.Role == UserRole.Student);
                if (student is null)
                {
                    MessageBox.Show("The student no longer exists.", "BacaIn",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                student.Username = username;
                student.DisplayName = displayName.Length > 0 ? displayName : null;
                student.AvatarUrl = avatarUrl.Length > 0 ? avatarUrl : null;
                if (!string.IsNullOrWhiteSpace(password))
                    student.PasswordHash = DatabaseSeeder.HashPassword(password);
                student.UpdatedAt = now;

                db.SaveChanges();
                SavedStudentId = student.Id;
            }
            else
            {
                var student = new User
                {
                    Username = username,
                    DisplayName = displayName.Length > 0 ? displayName : null,
                    PasswordHash = DatabaseSeeder.HashPassword(password),
                    AvatarUrl = avatarUrl.Length > 0 ? avatarUrl : null,
                    Role = UserRole.Student,
                    CreatedAt = now,
                };

                db.Users.Add(student);
                db.SaveChanges();
                SavedStudentId = student.Id;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not save student:\n{ex.Message}", "BacaIn",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
