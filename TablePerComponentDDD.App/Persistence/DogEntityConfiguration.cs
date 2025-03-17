using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TablePerComponent.App.Models;

namespace TablePerComponent.App.Persistence;

internal sealed class DogEntityConfiguration : IEntityTypeConfiguration<Dog>
{
    public void Configure(EntityTypeBuilder<Dog> builder)
    {
        builder.Property(d => d.Breed).HasMaxLength(80).IsRequired();
        builder.Property(d => d.Color).HasMaxLength(10);
        builder.Property(d => d.Name).HasMaxLength(50);
        builder.OwnsOne(d => d.Owner);
    }
}