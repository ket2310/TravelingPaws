﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelingPawsAPI.DataContext;

namespace TravelingPawsAPI.Migrations
{
    [DbContext(typeof(QuoteContext))]
    [Migration("20240101152608_InitialDB")]
    partial class InitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExecPetTransportBlazorAPI517.Models.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TravelTypeId")
                        .HasColumnType("int");

                    b.Property<string>("destinationaddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("destinationaddress2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("destinationcity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("destinationstate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("destinationzip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("otherinfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pickupaddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pickupaddress2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pickupcity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pickupstate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pickupzip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("returndate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("traveldate")
                        .HasColumnType("datetime2");

                    b.HasKey("TripId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("TravelingPawsAPI.Models.Cat", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("CatId");

                    b.ToTable("Cats");
                });

            modelBuilder.Entity("TravelingPawsAPI.Models.Dog", b =>
                {
                    b.Property<int>("DogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("DogId");

                    b.ToTable("Dogs");
                });

            modelBuilder.Entity("TravelingPawsAPI.Models.PetOwner", b =>
                {
                    b.Property<int>("PetOwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CellNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("catId")
                        .HasColumnType("int");

                    b.Property<int>("dogId")
                        .HasColumnType("int");

                    b.HasKey("PetOwnerId");

                    b.ToTable("PetOwners");

                    b.HasData(
                        new
                        {
                            PetOwnerId = 1,
                            CellNumber = "1234567890",
                            Email = "dablumaroon@gmail.com",
                            FirstName = "Kirk",
                            LastName = "Thomas",
                            PhoneNumber = "1234567890",
                            catId = 0,
                            dogId = 0
                        });
                });

            modelBuilder.Entity("TravelingPawsAPI.Models.Quote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TravelType")
                        .HasColumnType("int");

                    b.Property<int>("petOwnerId")
                        .HasColumnType("int");

                    b.Property<int>("tripId")
                        .HasColumnType("int");

                    b.HasKey("QuoteId");

                    b.HasIndex("petOwnerId");

                    b.ToTable("Quotes");

                    b.HasData(
                        new
                        {
                            QuoteId = 1,
                            TravelType = 0,
                            petOwnerId = 1,
                            tripId = 0
                        });
                });

            modelBuilder.Entity("TravelingPawsAPI.Models.Quote", b =>
                {
                    b.HasOne("TravelingPawsAPI.Models.PetOwner", "petOwner")
                        .WithMany()
                        .HasForeignKey("petOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("petOwner");
                });
#pragma warning restore 612, 618
        }
    }
}
