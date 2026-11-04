using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BacaIn.Models;

/// <summary>Bibliographic record of a title (catalog <c>Bibliographies</c> table).</summary>
[Index(nameof(Isbn))]
public class Bibliography : SoftDeletableModel
{
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;
    [MaxLength(13)]
    public string? Isbn { get; set; }
    [MaxLength(255)]
    public string Author { get; set; } = string.Empty;
    [MaxLength(255)]
    public string Publisher { get; set; } = string.Empty;
    public int? PublisherYear { get; set; }
    public string? Description { get; set; }
    public string? CoverUrl { get; set; }

    public ICollection<Exemplar> Exemplars { get; set; } = new List<Exemplar>();
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
