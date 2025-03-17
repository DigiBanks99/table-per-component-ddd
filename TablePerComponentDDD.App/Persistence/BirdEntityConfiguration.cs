using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TablePerComponent.App.Models;

namespace TablePerComponent.App.Persistence;

internal sealed class BirdEntityConfiguration : IEntityTypeConfiguration<Bird>
{
    public void Configure(EntityTypeBuilder<Bird> builder)
    {
        builder.Property(b => b.Species).HasMaxLength(80);
    }
}