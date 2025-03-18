using Microsoft.EntityFrameworkCore;

using TablePerComponent.App.Persistence;

namespace TablePerComponent.App.Host;

internal static class DbContextHostBuilderExtensions
{
    public static void AddDbContext(this WebApplicationBuilder webApplicationBuilder)
    {
        const string connectionName = "database";

        var connectionString = webApplicationBuilder.Configuration.GetConnectionString(connectionName) ??
                               throw new InvalidOperationException(
                                   $"Connection String for '{connectionName}' was not found in config");
        webApplicationBuilder.Services.AddDbContext<PetDbContext>(options => { options.UseSqlServer(connectionString); });
        webApplicationBuilder.EnrichSqlServerDbContext<PetDbContext>();
    }

    public static async Task ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<PetDbContext>();
        //await dbContext.Database.EnsureCreatedAsync();
        await dbContext.Database.MigrateAsync();
    }
}