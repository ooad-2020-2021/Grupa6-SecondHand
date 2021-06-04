﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecondHand.Data;

namespace SecondHand.Migrations
{
    [DbContext(typeof(SecondHandContext))]
    partial class SecondHandContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SecondHand.Models.Administrator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Passwrod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("SecondHand.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("SecondHand.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Brand")
                        .HasColumnType("int");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<int>("Condition")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Material")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("ID");

                    b.HasIndex("OwnerId");

                    b.ToTable("Product");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("SecondHand.Models.Review", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("ReviewedUserId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("ID");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ReviewedUserId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("SecondHand.Models.Transactions", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BuyerId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("SelerId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("ProductID");

                    b.HasIndex("SelerId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("SecondHand.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime");

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<double>("UserRating")
                        .HasColumnType("double");

                    b.Property<string>("ValidThru")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SecondHand.Models.Accessories", b =>
                {
                    b.HasBaseType("SecondHand.Models.Product");

                    b.Property<int>("AccessoriesCategory")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Accessories");
                });

            modelBuilder.Entity("SecondHand.Models.Clothing", b =>
                {
                    b.HasBaseType("SecondHand.Models.Product");

                    b.Property<int>("ClothingCategory")
                        .HasColumnType("int");

                    b.Property<int>("ClothingSize")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Clothing");
                });

            modelBuilder.Entity("SecondHand.Models.Shoes", b =>
                {
                    b.HasBaseType("SecondHand.Models.Product");

                    b.Property<int>("ShoeSize")
                        .HasColumnType("int");

                    b.Property<int>("ShoesCategory")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Shoes");
                });

            modelBuilder.Entity("SecondHand.Models.Product", b =>
                {
                    b.HasOne("SecondHand.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SecondHand.Models.Review", b =>
                {
                    b.HasOne("SecondHand.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecondHand.Models.User", "ReviewedUser")
                        .WithMany()
                        .HasForeignKey("ReviewedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SecondHand.Models.Transactions", b =>
                {
                    b.HasOne("SecondHand.Models.User", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecondHand.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecondHand.Models.User", "Seler")
                        .WithMany()
                        .HasForeignKey("SelerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SecondHand.Models.User", b =>
                {
                    b.HasOne("SecondHand.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId");
                });
#pragma warning restore 612, 618
        }
    }
}
