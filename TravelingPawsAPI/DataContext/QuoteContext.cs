using Microsoft.EntityFrameworkCore;
using TravelingPawsAPI.Models;
using System.Reflection;
using System;
using TravelingPawsAPI.Enums;
using ExecPetTransportBlazorAPI517.Models;

namespace TravelingPaws.DataContexts
{
    public class QuoteContext : DbContext
    {
        private readonly string sysName = Environment.MachineName;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=" + sysName + "\\sqlexpress;Initial Catalog=TravelingPaws;Integrated Security=True");
        }

        public DbSet<Quote> Quotes { get; set; }

        public DbSet<PetOwner> PetOwners { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Trip> Trips { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PetOwner>().HasData(new PetOwner
            {
                PetOwnerId = 1,
                FirstName = "Kirk",
                LastName = "Thomas",
                Email = "dablumaroon@gmail.com",
                PhoneNumber = "1234567890",
                CellNumber = "1234567890",
            });

            modelBuilder.Entity<Quote>().HasData(new Quote
            {
                QuoteId = 1,
                petOwnerId = 1,
                TravelType = TravelTypes.Oneway
            });


            }
        }
}
