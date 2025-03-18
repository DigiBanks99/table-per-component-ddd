using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TablePerComponent.App.Models;

namespace TablePerComponent.App.Persistence.EntityConfigurations;

internal sealed class CatEntityConfiguration : IEntityTypeConfiguration<Cat>
{
    public void Configure(EntityTypeBuilder<Cat> builder)
    {
        builder.Property(c => c.Breed).HasMaxLength(80).IsRequired();
        builder.Property(c => c.Color).HasMaxLength(10);
        builder.Property(c => c.Name).HasMaxLength(50);
    }
}