using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TablePerComponent.App.Models;

namespace TablePerComponent.App.Persistence;

internal sealed class PetEntityConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.UseTpcMappingStrategy();
    }
}