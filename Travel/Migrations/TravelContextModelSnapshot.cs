﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Travel.Models;

namespace Travel.Migrations
{
    [DbContext(typeof(TravelContext))]
    partial class TravelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Travel.Models.Destination", b =>
                {
                    b.Property<int>("DestinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("DestinationId");

                    b.ToTable("Destinations");

                    b.HasData(
                        new
                        {
                            DestinationId = 1,
                            Name = "Jurassic World"
                        },
                        new
                        {
                            DestinationId = 2,
                            Name = "Chicago"
                        },
                        new
                        {
                            DestinationId = 3,
                            Name = "Rivendell"
                        },
                        new
                        {
                            DestinationId = 4,
                            Name = "Hogwarts"
                        },
                        new
                        {
                            DestinationId = 5,
                            Name = "My Bathroom"
                        });
                });

            modelBuilder.Entity("Travel.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("DestinationId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            ReviewId = 1,
                            Comment = "Great Parks but the birds seem angry!",
                            DestinationId = 1,
                            Rating = 4
                        },
                        new
                        {
                            ReviewId = 2,
                            Comment = "Don't like beans",
                            DestinationId = 2,
                            Rating = 1
                        },
                        new
                        {
                            ReviewId = 3,
                            Comment = "A gorgeous man proposed to me with a ring",
                            DestinationId = 3,
                            Rating = 5
                        },
                        new
                        {
                            ReviewId = 4,
                            Comment = "No wheelchair ramps",
                            DestinationId = 4,
                            Rating = 3
                        },
                        new
                        {
                            ReviewId = 5,
                            Comment = "Lonely",
                            DestinationId = 5,
                            Rating = 3
                        });
                });

            modelBuilder.Entity("Travel.Models.Review", b =>
                {
                    b.HasOne("Travel.Models.Destination", "destination")
                        .WithMany("Reviews")
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("destination");
                });

            modelBuilder.Entity("Travel.Models.Destination", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
