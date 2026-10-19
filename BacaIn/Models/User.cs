using System;

namespace BacaIn.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string? DisplayName { get; set; }
        public string Role { get; set; } = "student"; // "student" or "admin"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public bool IsAdmin => string.Equals(Role, "admin", StringComparison.OrdinalIgnoreCase);
        public bool IsStudent => string.Equals(Role, "student", StringComparison.OrdinalIgnoreCase);
    }
}
