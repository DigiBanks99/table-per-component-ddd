using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TablePerComponent.App.Models;

namespace TablePerComponent.App.Persistence.EntityConfigurations;

internal sealed class DogEntityConfiguration : IEntityTypeConfiguration<Dog>
{
    public void Configure(EntityTypeBuilder<Dog> builder)
    {
        builder.Property(d => d.Breed).HasMaxLength(80).IsRequired();
        builder.Property(d => d.Color).HasMaxLength(10);
        builder.Property(d => d.Name).HasMaxLength(50);
        builder.OwnsOne(d => d.Owner, ConfigureOwner);
    }

    private static void ConfigureOwner(OwnedNavigationBuilder<Dog, Owner> builder)
    {
        builder.WithOwner();

        builder.Property(o => o.Name).HasMaxLength(50).IsRequired();
        builder.Property(o => o.PhoneNumber).HasMaxLength(15).IsRequired();
        builder.OwnsOne(o => o.Address, ConfigureAddress);
    }

    private static void ConfigureAddress(OwnedNavigationBuilder<Owner, Address> builder)
    {
        builder.WithOwner();

        builder.Property(a => a.Line1).HasMaxLength(100).IsRequired();
        builder.Property(a => a.Line2).HasMaxLength(100);
        builder.Property(a => a.City).HasMaxLength(50).IsRequired();
        builder.Property(a => a.Province).HasMaxLength(50).IsRequired();
        builder.Property(a => a.PostalCode).HasMaxLength(8).IsRequired();
    }
}