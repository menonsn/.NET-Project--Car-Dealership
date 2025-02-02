﻿// <auto-generated />
using System;
using CoreCruds.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreCruds.Migrations
{
    [DbContext(typeof(CoreCrudsContext))]
    [Migration("20190911205618_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreCruds.Models.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName");

                    b.HasKey("ID");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("CoreCruds.Models.Destinations", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Altitude");

                    b.Property<double?>("CostOfTrip");

                    b.Property<DateTime>("DateOfVisit");

                    b.Property<string>("DestinationName");

                    b.Property<bool>("EquatorialWeather");

                    b.Property<int>("LocationId");

                    b.Property<string>("MainAttraction");

                    b.HasKey("ID");

                    b.HasIndex("LocationId");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("CoreCruds.Models.Destinations", b =>
                {
                    b.HasOne("CoreCruds.Models.Country", "Location")
                        .WithMany("Destinations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
