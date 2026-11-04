using System;
using System.Collections.Generic;
using System.Text;

namespace BacaIn.Models;

/// <summary>
/// Base entity that carries the common primary key and audit timestamps shared by every table.
/// </summary>
public abstract class BaseModel
{
    /// <summary>Gets or sets the surrogate primary key.</summary>
    public int Id { get; set; }

    /// <summary>Gets or sets the UTC timestamp the row was inserted at.</summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>Gets or sets the UTC timestamp of the last update, or <c>null</c> if never updated.</summary>
    public DateTime? UpdatedAt { get; set; }
}
