using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BacaIn.Models;

/// <summary>Roles a user can hold.</summary>
public enum UserRole
{
    Student,
    Admin
}

/// <summary>Application user (catalog <c>Users</c> table).</summary>
[Index(nameof(Username), IsUnique = true), Index(nameof(DisplayName))]
public class User : BaseModel
{
    [MaxLength(255)]
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    [MaxLength(255)]
    public string? DisplayName { get; set; }
    public UserRole Role { get; set; }
    public string? AvatarUrl { get; set; }

    public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    public ICollection<CheckIn> CheckIns { get; set; } = new List<CheckIn>();
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
