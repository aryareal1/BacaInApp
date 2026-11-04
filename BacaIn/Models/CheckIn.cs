using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BacaIn.Models;

/// <summary>A student's library attendance record (catalog <c>CheckIns</c> table).</summary>
[Index(nameof(StudentId), nameof(CheckedInAt))]
public class CheckIn : BaseModel
{
    public int StudentId { get; set; }
    public User Student { get; set; } = null!;

    public DateTime CheckedInAt { get; set; }
}
