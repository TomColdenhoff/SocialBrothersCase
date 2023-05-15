﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialBrothersCase.Database;

#nullable disable

namespace SocialBrothersCase.Database.Migrations
{
    [DbContext(typeof(AddressContext))]
    partial class AddressContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("SocialBrothersCase.AddressDomain.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Addition")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bf8a4d8b-d5fc-4259-b47e-d26ed02dc7a6"),
                            Addition = "A",
                            City = "Vianen",
                            Country = "Nederland",
                            HouseNumber = 43,
                            Postcode = "4132 XX",
                            Street = "Sparrendreef"
                        },
                        new
                        {
                            Id = new Guid("63b19780-dd72-4dfb-9cc4-558c63a4410d"),
                            City = "Utrecht",
                            Country = "Nederland",
                            HouseNumber = 1000,
                            Postcode = "3528 BD",
                            Street = "Orteliuslaan"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}