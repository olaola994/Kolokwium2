﻿// <auto-generated />
using System;
using Kolokwium2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kolokwium2.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240611091320_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.4.24267.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kolokwium2.Models.Backpacks", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("Backpacks2");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            ItemId = 1,
                            Amount = 2
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Character_titles", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AcquiredAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CharacterId", "TitleId");

                    b.HasIndex("TitleId");

                    b.ToTable("CharacterTitles2");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            TitleId = 1,
                            AcquiredAt = new DateTime(2024, 6, 11, 11, 13, 19, 924, DateTimeKind.Local).AddTicks(4244)
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Characters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrentWeight")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MaxWeight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Characters2");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrentWeight = 43,
                            FirstName = "John",
                            LastName = "Yakuza",
                            MaxWeight = 200
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Items", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items2");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Item1",
                            Weight = 10
                        },
                        new
                        {
                            Id = 2,
                            Name = "Item2",
                            Weight = 11
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Titles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Titles2");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Title1"
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Backpacks", b =>
                {
                    b.HasOne("Kolokwium2.Models.Characters", "Characters")
                        .WithMany("BackpacksCollection")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium2.Models.Items", "Items")
                        .WithMany("BackpacksCollection")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Characters");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("Kolokwium2.Models.Character_titles", b =>
                {
                    b.HasOne("Kolokwium2.Models.Characters", "Characters")
                        .WithMany("CharacterTitlesCollection")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium2.Models.Titles", "Titles")
                        .WithMany("CharacterTitlesCollection")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Characters");

                    b.Navigation("Titles");
                });

            modelBuilder.Entity("Kolokwium2.Models.Characters", b =>
                {
                    b.Navigation("BackpacksCollection");

                    b.Navigation("CharacterTitlesCollection");
                });

            modelBuilder.Entity("Kolokwium2.Models.Items", b =>
                {
                    b.Navigation("BackpacksCollection");
                });

            modelBuilder.Entity("Kolokwium2.Models.Titles", b =>
                {
                    b.Navigation("CharacterTitlesCollection");
                });
#pragma warning restore 612, 618
        }
    }
}