using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BacaIn.Models;

/// <summary>State of a reservation.</summary>
public enum ReservationStatus
{
    Pending,
    Ready,
    Fulfilled,
    Cancelled,
    Expired
}

/// <summary>A student's queue position for a bibliography (catalog <c>Reservations</c> table).</summary>
[Index(nameof(StudentId), nameof(BibliographyId), nameof(Status))]
public class Reservation : BaseModel
{
    public int StudentId { get; set; }
    public User Student { get; set; } = null!;

    public int BibliographyId { get; set; }
    public Bibliography Bibliography { get; set; } = null!;

    public DateTime ReservedAt { get; set; }
    public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
    public int QueuePosition { get; set; }
}
