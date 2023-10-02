﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SatrackBank.Repositories.EFCore.DataContext;

#nullable disable

namespace SatrackBank.Repositories.EFCore.Migrations
{
    [DbContext(typeof(SatrackBankContext))]
    partial class SatrackBankContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SatrackBank.Entities.POCOEntities.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerType")
                        .HasColumnType("int");

                    b.Property<int>("DocumentType")
                        .HasColumnType("int");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LegalRepresentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LegalRepresentPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = "e265fcfe-b0ff-4125-bf43-67201a2fa7d9",
                            CellPhone = "3000000000",
                            CreationDate = new DateTime(2023, 9, 30, 15, 15, 7, 979, DateTimeKind.Local).AddTicks(5792),
                            CustomerType = 0,
                            DocumentType = 0,
                            Identification = "1013666666",
                            Name = "John Doe",
                            Password = "$2a$11$aMvcvJ6t0xJCZZ/TMkfqo.hbGthbZ8l6osZajcJXdEenVKlghatEy"
                        });
                });

            modelBuilder.Entity("SatrackBank.Entities.POCOEntities.CustomerProducts", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProductId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerProducts");

                    b.HasData(
                        new
                        {
                            ProductId = "819d08db-c025-4a01-84a7-d305338d4244",
                            CustomerId = "e265fcfe-b0ff-4125-bf43-67201a2fa7d9"
                        });
                });

            modelBuilder.Entity("SatrackBank.Entities.POCOEntities.Movement", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("MovementType")
                        .HasColumnType("int");

                    b.Property<double>("PreviousBalance")
                        .HasColumnType("float");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Movement");

                    b.HasData(
                        new
                        {
                            Id = "a9197ad9-8101-42d0-9b4a-f1097d7675e1",
                            Date = new DateTime(2023, 9, 30, 15, 15, 7, 979, DateTimeKind.Local).AddTicks(5897),
                            Description = "Creación de cuenta.",
                            MovementType = 6,
                            PreviousBalance = 0.0,
                            ProductId = "819d08db-c025-4a01-84a7-d305338d4244",
                            Value = 1000000.0
                        });
                });

            modelBuilder.Entity("SatrackBank.Entities.POCOEntities.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("CurrentBalance")
                        .HasColumnType("float");

                    b.Property<double>("Interest")
                        .HasColumnType("float");

                    b.Property<int>("ProductStatus")
                        .HasColumnType("int");

                    b.Property<int>("ProductType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = "819d08db-c025-4a01-84a7-d305338d4244",
                            CreationDate = new DateTime(2023, 9, 30, 15, 15, 7, 979, DateTimeKind.Local).AddTicks(5878),
                            CurrentBalance = 1000000.0,
                            Interest = 0.040000000000000001,
                            ProductStatus = 0,
                            ProductType = 0
                        });
                });

            modelBuilder.Entity("SatrackBank.Entities.POCOEntities.CustomerProducts", b =>
                {
                    b.HasOne("SatrackBank.Entities.POCOEntities.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SatrackBank.Entities.POCOEntities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SatrackBank.Entities.POCOEntities.Movement", b =>
                {
                    b.HasOne("SatrackBank.Entities.POCOEntities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
