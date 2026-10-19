using System;

namespace BacaIn.Models
{
    public class Reservation
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid StudentId { get; set; }
        public string? StudentName { get; set; }
        public Guid BibliographyId { get; set; }
        public string? BookTitle { get; set; }
        public DateTime ReservedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "PENDING"; // PENDING, READY, FULFILLED, CANCELLED, EXPIRED
        public int QueuePosition { get; set; } = 1;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
