﻿// <auto-generated />
using System;
using FIAP.Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FIAP.Library.Infrastructure.Migrations
{
    [DbContext(typeof(MSContext))]
    [Migration("20240509135731_CreateRentBookTable")]
    partial class CreateRentBookTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FIAP.Library.Domain.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("genre")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("FIAP.Library.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("document")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FIAP.Library.Domain.Entities.RentBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("bookId")
                        .HasColumnType("int");

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("datePossibleLocation")
                        .HasColumnType("datetime2");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("bookId");

                    b.HasIndex("customerId");

                    b.ToTable("RentBooks");
                });

            modelBuilder.Entity("FIAP.Library.Domain.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("bookId")
                        .HasColumnType("int");

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("bookId");

                    b.HasIndex("customerId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("FIAP.Library.Domain.Entities.RentBook", b =>
                {
                    b.HasOne("FIAP.Library.Domain.Entities.Book", "books")
                        .WithMany("rentBooks")
                        .HasForeignKey("bookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIAP.Library.Domain.Entities.Customer", "customers")
                        .WithMany("rentBooks")
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("books");

                    b.Navigation("customers");
                });

            modelBuilder.Entity("FIAP.Library.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("FIAP.Library.Domain.Entities.Book", "books")
                        .WithMany("reservations")
                        .HasForeignKey("bookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIAP.Library.Domain.Entities.Customer", "customers")
                        .WithMany("reservations")
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("books");

                    b.Navigation("customers");
                });

            modelBuilder.Entity("FIAP.Library.Domain.Entities.Book", b =>
                {
                    b.Navigation("rentBooks");

                    b.Navigation("reservations");
                });

            modelBuilder.Entity("FIAP.Library.Domain.Entities.Customer", b =>
                {
                    b.Navigation("rentBooks");

                    b.Navigation("reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
