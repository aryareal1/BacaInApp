using System;
using System.Collections.Generic;
using System.Text;

namespace BacaIn.Models;

/// <summary>
/// Base entity for tables that use soft deletes (<c>deletedAt</c>).
/// </summary>
public abstract class SoftDeletableModel : BaseModel
{
    /// <summary>Gets or sets the UTC timestamp the row was soft-deleted at, or <c>null</c> while active.</summary>
    public DateTime? DeletedAt { get; set; }
}
