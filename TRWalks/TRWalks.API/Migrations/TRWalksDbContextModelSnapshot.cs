﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TRWalks.API.Data;

#nullable disable

namespace TRWalks.API.Migrations
{
    [DbContext(typeof(TRWalksDbContext))]
    partial class TRWalksDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TRWalks.API.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a1c8db32-d39d-41af-bb82-89c622c8c555"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("b34ef5a1-73e4-4d22-9124-1bde6a25d53b"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("f3e8cf4a-a789-4bc7-9255-c9c8f2468d44"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("TRWalks.API.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d7c8a1c8-c349-4f27-9f17-a555e3c8c789"),
                            Code = "TSC",
                            Name = "Tomsk Central",
                            RegionImageUrl = "https://example.com/images/tomsk-central.jpg"
                        },
                        new
                        {
                            Id = new Guid("8c34ba72-4a1b-4a8e-8d23-1b5c81c56b77"),
                            Code = "SFR",
                            Name = "Siberian Forest",
                            RegionImageUrl = "https://example.com/images/siberian-forest.jpg"
                        },
                        new
                        {
                            Id = new Guid("c1e7ad3b-f2a6-4c2f-9f91-2f5c8b5a6d8c"),
                            Code = "LDN",
                            Name = "Lenin District"
                        },
                        new
                        {
                            Id = new Guid("e8f12ab3-a71d-4e2c-9f23-b8c9f3d8e74a"),
                            Code = "UA",
                            Name = "University Area",
                            RegionImageUrl = "https://example.com/images/university-area.jpg"
                        },
                        new
                        {
                            Id = new Guid("3a8f4b2c-d7c1-43a2-9f17-8e5b8f2c1d6a"),
                            Code = "HQ",
                            Name = "Historical Quarters",
                            RegionImageUrl = "https://example.com/images/historical-quarters.jpg"
                        });
                });

            modelBuilder.Entity("TRWalks.API.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("walks");
                });

            modelBuilder.Entity("TRWalks.API.Models.Domain.Walk", b =>
                {
                    b.HasOne("TRWalks.API.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TRWalks.API.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
