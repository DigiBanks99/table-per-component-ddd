﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TablePerComponent.App.Persistence;

#nullable disable

namespace TablePerComponent.App.Migrations
{
    [DbContext(typeof(PetDbContext))]
    [Migration("20250318092822_RichColor")]
    partial class RichColor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("PetSequence");

            modelBuilder.Entity("TablePerComponent.App.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [PetSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("TablePerComponent.App.Models.Bird", b =>
                {
                    b.HasBaseType("TablePerComponent.App.Models.Pet");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.ToTable("Birds");
                });

            modelBuilder.Entity("TablePerComponent.App.Models.Cat", b =>
                {
                    b.HasBaseType("TablePerComponent.App.Models.Pet");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Color")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.ToTable("Cats");
                });

            modelBuilder.Entity("TablePerComponent.App.Models.Dog", b =>
                {
                    b.HasBaseType("TablePerComponent.App.Models.Pet");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Color")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.ToTable("Dogs");
                });

            modelBuilder.Entity("TablePerComponent.App.Models.Dog", b =>
                {
                    b.OwnsOne("TablePerComponent.App.Models.Owner", "Owner", b1 =>
                        {
                            b1.Property<int>("DogId")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("nvarchar(15)");

                            b1.HasKey("DogId");

                            b1.ToTable("Dogs");

                            b1.WithOwner()
                                .HasForeignKey("DogId");

                            b1.OwnsOne("TablePerComponent.App.Models.Address", "Address", b2 =>
                                {
                                    b2.Property<int>("OwnerDogId")
                                        .HasColumnType("int");

                                    b2.Property<string>("City")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("nvarchar(50)");

                                    b2.Property<string>("Line1")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)");

                                    b2.Property<string>("Line2")
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)");

                                    b2.Property<string>("PostalCode")
                                        .IsRequired()
                                        .HasMaxLength(8)
                                        .HasColumnType("nvarchar(8)");

                                    b2.Property<string>("Province")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("nvarchar(50)");

                                    b2.HasKey("OwnerDogId");

                                    b2.ToTable("Dogs");

                                    b2.WithOwner()
                                        .HasForeignKey("OwnerDogId");
                                });

                            b1.Navigation("Address")
                                .IsRequired();
                        });

                    b.Navigation("Owner")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
