using BacaIn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BacaIn.Data;

/// <summary>EF Core database context for the BacaIn catalog.</summary>
/// <remarks>When no options are supplied (e.g. by <c>dotnet ef</c>), it falls back to appsettings.json.</remarks>
internal class AppDbContext(DbContextOptions<AppDbContext> options = null!) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Bibliography> Bibliographies => Set<Bibliography>();
    public DbSet<Exemplar> Exemplars => Set<Exemplar>();
    public DbSet<Loan> Loans => Set<Loan>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<CheckIn> CheckIns => Set<CheckIn>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
            return;

        var connectionString = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables("BACAIN_")
            .Build()
            .GetConnectionString("BacaIn");
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException("Connection string 'BacaIn' is not configured (appsettings.json or BACAIN_CONNECTION_STRING).");

        optionsBuilder
            .UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Enums are persisted as lowercase labels (e.g. 'student', 'available') to match the ERD.
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                var enumType = Nullable.GetUnderlyingType(property.ClrType) ?? property.ClrType;
                if (!enumType.IsEnum)
                    continue;

                var converterType = typeof(EnumLabelConverter<>).MakeGenericType(enumType);
                var converter = (ValueConverter)Activator.CreateInstance(converterType)!;
                modelBuilder.Entity(entityType.ClrType).Property(property.Name)
                    .HasColumnType("text")
                    .HasConversion(converter);
            }
        }

        // Global query filters hide soft-deleted rows; use IgnoreQueryFilters() to include them.
        modelBuilder.Entity<Bibliography>().HasQueryFilter(b => b.DeletedAt == null);
        modelBuilder.Entity<Exemplar>().HasQueryFilter(e => e.DeletedAt == null);
    }
}

/// <summary>Converts enum values to/from their lowercase names.</summary>
public sealed class EnumLabelConverter<TEnum> : ValueConverter<TEnum, string>
    where TEnum : struct, Enum
{
    public EnumLabelConverter()
        : base(v => Enum.GetName(v)!.ToLowerInvariant(),
               v => Enum.Parse<TEnum>(v, ignoreCase: true))
    {
    }
}
