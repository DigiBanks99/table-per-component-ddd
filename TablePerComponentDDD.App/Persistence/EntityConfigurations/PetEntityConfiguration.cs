using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TablePerComponent.App.Models;

namespace TablePerComponent.App.Persistence.EntityConfigurations;

internal sealed class PetEntityConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.UseTpcMappingStrategy();

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).HasMaxLength(80).IsRequired();
    }
}