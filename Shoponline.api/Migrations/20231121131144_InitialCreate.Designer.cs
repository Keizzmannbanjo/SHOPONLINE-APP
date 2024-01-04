﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shoponline.api.Data;

#nullable disable

namespace Shoponline.api.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20231121131144_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Shoponline.api.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Shoponline.api.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Shoponline.api.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "This masthead of your favourite super plumber bros rock",
                            ImageUrl = "/Images/Frames/Supermario.png",
                            Name = "Super Mario Masthead",
                            Price = 250000m,
                            ProductCategoryId = 1,
                            Qty = 50
                        },
                        new
                        {
                            Id = 2,
                            Description = "This masthead of your favourite super plumber bros riding on all amazing rainbow arc running for their dear lives",
                            ImageUrl = "/Images/Frames/Supermario on the rainbow.png",
                            Name = "Super Mario Rainbow Race",
                            Price = 200000m,
                            ProductCategoryId = 1,
                            Qty = 50
                        },
                        new
                        {
                            Id = 3,
                            Description = "This well cooked noodles seems to be calling your name",
                            ImageUrl = "/Images/Food/Noodles.jpg",
                            Name = "Cooked Noodles with Eggs and Supplements",
                            Price = 5000m,
                            ProductCategoryId = 2,
                            Qty = 30
                        },
                        new
                        {
                            Id = 4,
                            Description = "Welcome to the bliss of local food, Ofada rice has got you. Nuff said",
                            ImageUrl = "/Images/Food/Ofada rice.jpg",
                            Name = "Ofada Rice and Stew",
                            Price = 7000m,
                            ProductCategoryId = 2,
                            Qty = 50
                        });
                });

            modelBuilder.Entity("Shoponline.api.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Frames"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Food"
                        });
                });

            modelBuilder.Entity("Shoponline.api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
