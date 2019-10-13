﻿// <auto-generated />
using System;
using CarDealership.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarDealership.Migrations
{
    [DbContext(typeof(CarDealershipContext))]
    [Migration("20191012001909_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarDealership.Models.Branch", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Branch_City")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("Branch_Rating");

                    b.Property<bool>("IsOperational");

                    b.Property<int>("Review_Count");

                    b.Property<int>("Zip_Code");

                    b.HasKey("ID");

                    b.ToTable("Branch");
                });

            modelBuilder.Entity("CarDealership.Models.Car", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId");

                    b.Property<int>("MakeID");

                    b.Property<int>("Manufactured_Year");

                    b.Property<int?>("OwnerId");

                    b.Property<DateTime?>("Sale_Date");

                    b.Property<int>("Showroom_Price");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.HasIndex("BranchId");

                    b.HasIndex("MakeID");

                    b.HasIndex("OwnerId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("CarDealership.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contact_Number")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Customer_Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Email_ID")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CarDealership.Models.Make", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MakeTypeID");

                    b.Property<int>("ManufacturerID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.HasIndex("MakeTypeID");

                    b.HasIndex("ManufacturerID");

                    b.ToTable("Make");
                });

            modelBuilder.Entity("CarDealership.Models.MakeType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Make_Type")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("MakeType");
                });

            modelBuilder.Entity("CarDealership.Models.Manufacturer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("CarDealership.Models.Car", b =>
                {
                    b.HasOne("CarDealership.Models.Branch", "Branch")
                        .WithMany("Cars")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarDealership.Models.Make", "Make")
                        .WithMany("Cars")
                        .HasForeignKey("MakeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarDealership.Models.Customer", "Owner")
                        .WithMany("Cars")
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("CarDealership.Models.Make", b =>
                {
                    b.HasOne("CarDealership.Models.MakeType", "MakeType")
                        .WithMany("Makes")
                        .HasForeignKey("MakeTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarDealership.Models.Manufacturer", "Manufacturer")
                        .WithMany("Makes")
                        .HasForeignKey("ManufacturerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
