using BacaIn.Data;
using BacaIn.Models;
using Microsoft.EntityFrameworkCore;

namespace BacaIn.Controls;

public partial class SelectUser : UserControl
{
    private static readonly Font NameFont = new("Segoe UI", 9.75F, FontStyle.Bold);
    private static readonly Font HandleFont = new("Segoe UI", 7.5F);
    private static readonly Image DefaultAvatar = Properties.Resources.pfp;
    private List<User> _students = new();

    public SelectUser()
    {
        InitializeComponent();
    }

    private void btnSearch_Click(object? sender, EventArgs e) => ApplyFilter();

    private void txtSearch_TextChanged(object? sender, EventArgs e) => ApplyFilter();

    /// <summary>Most recently clicked student; <c>null</c> until a card is clicked.</summary>
    public User? SelectedUser { get; private set; }

    /// <summary>Raised when a student card is clicked.</summary>
    public event EventHandler? UserSelected;

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (DesignMode)
            return;
        LoadStudents();
    }

    private void LoadStudents()
    {
        try
        {
            using var db = new AppDbContext();
            _students = db.Users.AsNoTracking()
                .Where(u => u.Role == UserRole.Student)
                .OrderBy(u => u.DisplayName ?? u.Username)
                .ToList();
        }
        catch (Exception ex)
        {
            _students = new();
            MessageBox.Show($"Could not load students:\n{ex.Message}", "BacaIn",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        ApplyFilter();
    }

    private void ApplyFilter()
    {
        var term = txtSearch.Text.Trim();
        var matches = term.Length == 0
            ? _students
            : _students.Where(u =>
                u.Username.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                (u.DisplayName?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false)).ToList();

        RenderCards(matches);
    }

    private void RenderCards(IEnumerable<User> users)
    {
        flowLayoutPanel1.SuspendLayout();
        flowLayoutPanel1.Controls.Clear();

        foreach (var user in users)
            flowLayoutPanel1.Controls.Add(CreateCard(user));

        flowLayoutPanel1.ResumeLayout();
    }

    private Panel CreateCard(User user)
    {
        var card = new Panel
        {
            Size = new Size(220, 56),
            Margin = new Padding(0, 0, 8, 8),
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = SystemColors.ControlLightLight,
            Cursor = Cursors.Hand,
            Tag = user,
        };

        var avatar = new CircularPictureBox
        {
            Image = DefaultAvatar,
            SizeMode = PictureBoxSizeMode.Zoom,
            Size = new Size(36, 36),
            Location = new Point(10, 10),
            Cursor = Cursors.Hand,
            Tag = user,
        };

        var name = new Label
        {
            AutoSize = true,
            Font = NameFont,
            Location = new Point(54, 8),
            Text = user.DisplayName ?? user.Username,
            Cursor = Cursors.Hand,
            Tag = user,
        };

        var handle = new Label
        {
            AutoSize = true,
            Font = HandleFont,
            ForeColor = SystemColors.GrayText,
            Location = new Point(54, 30),
            Text = "@" + user.Username,
            Cursor = Cursors.Hand,
            Tag = user,
        };

        card.Controls.Add(avatar);
        card.Controls.Add(name);
        card.Controls.Add(handle);

        card.Click += Card_Click;
        avatar.Click += Card_Click;
        name.Click += Card_Click;
        handle.Click += Card_Click;

        return card;
    }

    private void Card_Click(object? sender, EventArgs e)
    {
        if (sender is not Control { Tag: User user })
            return;

        SelectedUser = user;
        UserSelected?.Invoke(this, EventArgs.Empty);
    }
}
