using System;

namespace BacaIn.Models
{
    public class Bibliography
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string? Isbn { get; set; }
        public string Author { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public int? PublisherYear { get; set; }
        public string? Description { get; set; }
        public string? CoverUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
    }
}
