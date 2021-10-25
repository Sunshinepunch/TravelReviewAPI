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

            modelBuilder.Entity("Travel.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .HasColumnType("longtext");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            ReviewId = 1,
                            Comment = "Great Parks but the birds seem angry!",
                            Location = "Jurassic World",
                            Rating = 4
                        },
                        new
                        {
                            ReviewId = 2,
                            Comment = "Don't like beans",
                            Location = "Chicago",
                            Rating = 1
                        },
                        new
                        {
                            ReviewId = 3,
                            Comment = "A gorgeous man proposed to me with a ring",
                            Location = "Rivendell",
                            Rating = 5
                        },
                        new
                        {
                            ReviewId = 4,
                            Comment = "No wheelchair ramps",
                            Location = "Hogwarts",
                            Rating = 3
                        },
                        new
                        {
                            ReviewId = 5,
                            Comment = "Lonely",
                            Location = "My bathroom",
                            Rating = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
