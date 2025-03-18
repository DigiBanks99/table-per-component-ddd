using System.Reflection;

using Microsoft.EntityFrameworkCore;

using TablePerComponent.App.Models;
using TablePerComponent.App.Persistence.ValueConverters;

namespace TablePerComponent.App.Persistence;

public class PetDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Dog> Dogs { get; set; }
    public DbSet<Cat> Cats { get; set; }
    public DbSet<Bird> Birds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo((a) => System.Diagnostics.Debug.WriteLine(a));
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<NonEmptyString>()
            .HaveConversion<NonEmptyStringValueConverter>()
            .HaveMaxLength(250);

        configurationBuilder
            .Properties<RichColor?>()
            .HaveConversion<RichColorValueConverter>()
            .HaveMaxLength(80);

        base.ConfigureConventions(configurationBuilder);
    }
}