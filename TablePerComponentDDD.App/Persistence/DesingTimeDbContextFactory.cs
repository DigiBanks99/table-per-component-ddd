using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TablePerComponent.App.Persistence;

internal sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PetDbContext>
{
    public PetDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<PetDbContext> builder = new();
        builder.UseSqlServer("connection-string-placeholder",
            b => b.MigrationsAssembly(typeof(PetDbContext).Assembly.FullName));
        return new PetDbContext(builder.Options);
    }
}