﻿// <auto-generated />
using System;
using MarketplaceObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarketplaceObjects.SQLite.Migrations
{
    [DbContext(typeof(MarketplaceSQLiteContext))]
    partial class MarketplaceSQLiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("MarketplaceObjects.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MarketplaceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.HasIndex("MarketplaceId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MarketplaceObjects.Marketplace", b =>
                {
                    b.Property<int>("MarketplaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MarketplaceId");

                    b.ToTable("Marketplaces");
                });

            modelBuilder.Entity("MarketplaceObjects.Offer", b =>
                {
                    b.Property<int>("OfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("ChangeCheck")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .HasColumnType("TEXT");

                    b.Property<int>("SellerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OfferId");

                    b.HasIndex("UserId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("MarketplaceObjects.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BuyerId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("ChangeCheck")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<int>("OfferId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("TimeSlot")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MarketplaceObjects.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Alias")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("ChangeCheck")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MarketplaceObjects.Category", b =>
                {
                    b.HasOne("MarketplaceObjects.Marketplace", null)
                        .WithMany("Categories")
                        .HasForeignKey("MarketplaceId");
                });

            modelBuilder.Entity("MarketplaceObjects.Offer", b =>
                {
                    b.HasOne("MarketplaceObjects.User", null)
                        .WithMany("Offers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MarketplaceObjects.Order", b =>
                {
                    b.HasOne("MarketplaceObjects.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MarketplaceObjects.Marketplace", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("MarketplaceObjects.User", b =>
                {
                    b.Navigation("Offers");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
