﻿// <auto-generated />
using FreakyFashionServices.Catalog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FreakyFashionServices.Catalog.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("FreakyFashionServices.Models.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ArticleNr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AvailableStock")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArticleNr = "r333",
                            AvailableStock = 20,
                            Description = "Lorem Ipsum dollar ",
                            Price = 300,
                            Title = "Black slim T-shirt"
                        },
                        new
                        {
                            Id = 2,
                            ArticleNr = "d211",
                            AvailableStock = 20,
                            Description = "Lorem Ipsum dollar ",
                            Price = 700,
                            Title = "Pink slim T-shirt"
                        },
                        new
                        {
                            Id = 3,
                            ArticleNr = "t55",
                            AvailableStock = 10,
                            Description = "Lorem Ipsum dollar ",
                            Price = 500,
                            Title = "Blue slim T-shirt"
                        },
                        new
                        {
                            Id = 4,
                            ArticleNr = "qwrg",
                            AvailableStock = 14,
                            Description = "Lorem Ipsum dollar ",
                            Price = 100,
                            Title = "Gold slim T-shirt"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
