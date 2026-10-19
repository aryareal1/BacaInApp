using System;

namespace BacaIn.Models
{
    public class Exemplar
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid BibliographyId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string Status { get; set; } = "AVAILABLE"; // AVAILABLE, BORROWED, DAMAGED, LOST
        public string Condition { get; set; } = "GOOD";   // NEW, GOOD, FAIR, POOR
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public string? BookTitle { get; set; }
        public string? BookAuthor { get; set; }
    }
}
