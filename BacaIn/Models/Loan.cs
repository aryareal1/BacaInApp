using System;

namespace BacaIn.Models
{
    public class Loan
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentUsername { get; set; }
        public Guid ExemplarId { get; set; }
        public string? Barcode { get; set; }
        public string? BookTitle { get; set; }
        public string? Author { get; set; }
        public DateTime BorrowedAt { get; set; } = DateTime.UtcNow;
        public DateTime DueAt { get; set; } = DateTime.UtcNow.AddDays(14);
        public DateTime? ReturnedAt { get; set; }
        public string Status { get; set; } = "ACTIVATE"; // ACTIVATE, RETURNED
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public bool IsOverdue => string.Equals(Status, "ACTIVATE", StringComparison.OrdinalIgnoreCase) && DateTime.UtcNow > DueAt;

        public int DaysOverdue
        {
            get
            {
                if (!IsOverdue) return 0;
                var diff = DateTime.UtcNow - DueAt;
                return Math.Max(1, (int)Math.Ceiling(diff.TotalDays));
            }
        }

        public decimal FineAmount => DaysOverdue * 1000m;
    }
}
