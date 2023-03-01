﻿// <auto-generated />
using System;
using BurgerSystem.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BurgerSystem.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(BurgerSystemDbContext))]
    [Migration("20230226124140_init2")]
    partial class init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BurgerSystem.Domain.AccountInfo.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("RegisterTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BurgerSystem.Domain.CommentInfo.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TasteScore")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TextureScore")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VisualScore")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("BurgerSystem.Domain.StoreInfo.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MenusInfo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OpeningTime")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Store");
                });
#pragma warning restore 612, 618
        }
    }
}
