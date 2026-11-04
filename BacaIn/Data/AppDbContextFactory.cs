using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace BacaIn.Data;

/// <summary>
/// Design-time factory so <c>dotnet ef</c> can construct the context without launching the WinForms entry point.
/// </summary>
/// <remarks>
/// Deliberately kept even though <see cref="AppDbContext"/> can configure itself: without it, running
/// <c>dotnet ef</c> would boot a WinForms UI in the background just to open a DbContext.
/// </remarks>
internal sealed class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables("BACAIN_")
            .Build();

        var connectionString = configuration.GetConnectionString("BacaIn")
            ?? Environment.GetEnvironmentVariable("BACAIN_CONNECTION_STRING")
            ?? throw new InvalidOperationException("Set ConnectionStrings:BacaIn in appsettings.json or BACAIN_CONNECTION_STRING.");

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention()
            .Options;

        return new AppDbContext(options);
    }
}
