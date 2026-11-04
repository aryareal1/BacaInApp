using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BacaIn.Models;

/// <summary>State of a loan.</summary>
public enum LoanStatus
{
    Active,
    Returned
}

/// <summary>A copy borrowed by a student (catalog <c>Loans</c> table).</summary>
[Index(nameof(StudentId))]
[Index(nameof(ExemplarId))]
[Index(nameof(DueAt))]
public class Loan : BaseModel
{
    public int StudentId { get; set; }
    public User Student { get; set; } = null!;

    public int ExemplarId { get; set; }
    public Exemplar Exemplar { get; set; } = null!;

    public DateTime BorrowedAt { get; set; }
    public DateTime DueAt { get; set; }
    public DateTime? ReturnedAt { get; set; }
    public LoanStatus Status { get; set; } = LoanStatus.Active;
}
