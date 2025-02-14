﻿// <auto-generated />
using Laboration1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Laboration1.Migrations
{
    [DbContext(typeof(ItemDBContext))]
    [Migration("20211014121559_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Laboration1.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Projektor"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Bärbar dator"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Trådlös hikrofon"
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "Trådös högtala"
                        },
                        new
                        {
                            CategoryId = 5,
                            Name = "Blädderblock"
                        },
                        new
                        {
                            CategoryId = 6,
                            Name = "TV"
                        },
                        new
                        {
                            CategoryId = 7,
                            Name = "Portabel projektorduk"
                        });
                });

            modelBuilder.Entity("Laboration1.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("PowerSourceId")
                        .HasColumnType("int");

                    b.Property<string>("ThumbnailHash")
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.HasKey("ItemId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PowerSourceId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Laboration1.Models.PowerSource", b =>
                {
                    b.Property<int>("PowerSourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("PowerSourceId");

                    b.ToTable("PowerSources");

                    b.HasData(
                        new
                        {
                            PowerSourceId = 1,
                            Name = "Inget"
                        },
                        new
                        {
                            PowerSourceId = 2,
                            Name = "Eluttag"
                        },
                        new
                        {
                            PowerSourceId = 3,
                            Name = "Batterier"
                        });
                });

            modelBuilder.Entity("Laboration1.Models.Item", b =>
                {
                    b.HasOne("Laboration1.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Laboration1.Models.PowerSource", "PowerSource")
                        .WithMany()
                        .HasForeignKey("PowerSourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("PowerSource");
                });
#pragma warning restore 612, 618
        }
    }
}
