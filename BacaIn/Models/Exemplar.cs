using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BacaIn.Models;

/// <summary>Physical status of a copy.</summary>
public enum ExemplarStatus
{
    Available,
    Borrowed,
    Damaged,
    Lost
}

/// <summary>Physical condition of a copy.</summary>
public enum ExemplarCondition
{
    New,
    Good,
    Fair,
    Poor
}

/// <summary>Physical copy of a bibliography (catalog <c>Exemplars</c> table).</summary>
[Index(nameof(Barcode), IsUnique = true)]
public class Exemplar : SoftDeletableModel
{
    public int BibliographyId { get; set; }
    public Bibliography Bibliography { get; set; } = null!;

    [MaxLength(50)]
    public string Barcode { get; set; } = string.Empty;
    public ExemplarStatus Status { get; set; } = ExemplarStatus.Available;
    public ExemplarCondition Condition { get; set; } = ExemplarCondition.New;

    public ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
