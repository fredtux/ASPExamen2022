﻿// <auto-generated />
using System;
using Examen2022.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Examen2022.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230115155910_SeedDB")]
    partial class SeedDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Examen2022.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Content = "CO1",
                            Date = new DateTime(2023, 1, 15, 17, 59, 10, 732, DateTimeKind.Local).AddTicks(615),
                            Title = "T1"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Content = "CO2",
                            Date = new DateTime(2023, 1, 15, 17, 59, 10, 732, DateTimeKind.Local).AddTicks(644),
                            Title = "T2"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Content = "CO3",
                            Date = new DateTime(2023, 1, 15, 17, 59, 10, 732, DateTimeKind.Local).AddTicks(646),
                            Title = "T3"
                        });
                });

            modelBuilder.Entity("Examen2022.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "C1"
                        },
                        new
                        {
                            Id = 2,
                            Title = "C2"
                        },
                        new
                        {
                            Id = 3,
                            Title = "C3"
                        });
                });

            modelBuilder.Entity("Examen2022.Models.Article", b =>
                {
                    b.HasOne("Examen2022.Models.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Examen2022.Models.Category", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
