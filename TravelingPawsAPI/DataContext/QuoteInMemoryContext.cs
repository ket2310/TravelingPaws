using Microsoft.EntityFrameworkCore;
using TravelingPawsAPI.Enums;
using TravelingPawsAPI.Models;

namespace TravelingPawsAPI.DataContext
{
    public class QuoteInMemoryContext : DbContext
    {
        protected override void OnConfiguring (DbContextOptionsBuilder builder)
        {
            builder.UseInMemoryDatabase(databaseName: "TravelingPawsInMemorydb");

        }


        public DbSet<Quote> Quotes { get; set; }
        public DbSet<PetOwner> PetOwners { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Trip> Trips { get; set; }
    }
}
