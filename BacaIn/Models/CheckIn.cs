using System;

namespace BacaIn.Models
{
    public class CheckIn
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentUsername { get; set; }
        public DateTime CheckedInAt { get; set; } = DateTime.UtcNow;
    }
}
