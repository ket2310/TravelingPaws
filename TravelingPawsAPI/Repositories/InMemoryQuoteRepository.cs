using Microsoft.EntityFrameworkCore;
using TravelingPawsAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelingPaws.DataContexts;
using TravelingPawsAPI.Maps;

namespace TravelingPawsAPI.Repositories
{
    public class InMemoryQuoteRepository : IInMemoryQuoteRepository
    {
        private readonly QuoteInMemoryContext _context;

        public InMemoryQuoteRepository(QuoteInMemoryContext context)
        {
            _context = context;
        }

        //-------------------------------------------------
        public async Task<IEnumerable<Quote>> GetQuotes()
        {
            var quotes = await _context.Quotes.ToListAsync();

            foreach (var quote in quotes)
            {
                var owner = await _context.PetOwners.FirstOrDefaultAsync(p => p.PetOwnerId == quote.petOwnerId);

                if (owner != null)
                {
                    quote.petOwner.FirstName = owner.FirstName;
                    quote.petOwner.LastName = owner.LastName;
                    quote.petOwner.Email = owner.Email;
                    quote.petOwner.PhoneNumber = owner.PhoneNumber;
                    quote.petOwner.CellNumber = owner.CellNumber;
                    quote.petOwner.Instructions = owner.Instructions;

                    var cat = await _context.Cats.FirstOrDefaultAsync(c => c.CatId == quote.petOwner.catId);
                    if (cat != null)
                    {
                        quote.petOwner.cat.Age = cat.Age;
                        quote.petOwner.cat.Quantity = cat.Quantity;
                        quote.petOwner.cat.Breed = cat.Breed;
                        quote.petOwner.cat.Weight = cat.Weight;
                    }

                    var dog = await _context.Dogs.FirstOrDefaultAsync(d => d.DogId == quote.petOwner.dogId);
                    if (dog !=null)
                    {
                        quote.petOwner.dog.Age = dog.Age;
                        quote.petOwner.dog.Quantity = dog.Quantity;
                        quote.petOwner.dog.Breed = dog.Breed;
                        quote.petOwner.dog.Weight = dog.Weight;
                    }

                    var trip = await _context.Trips.FirstOrDefaultAsync(t => t.TripId == quote.tripId);

                    return quotes;
                }
            }
            return quotes;
        }

        public async Task<Quote> CreateAQuote(QuoteMap obj)
        {

            Quote q = new Quote();
            q.petOwner = new PetOwner();
            q.petOwner.PetOwnerId = 1;
            q.petOwner.FirstName = obj.petOwner.FirstName;
            q.petOwner.LastName = obj.petOwner.LastName;
            q.petOwner.Email = obj.petOwner.Email;
            q.petOwner.PhoneNumber = obj.petOwner.PhoneNumber;
            q.petOwner.CellNumber = obj.petOwner.CellNumber;
            q.petOwner.Instructions = obj.petOwner.Instructions;
            q.petOwner.cat = new Cat();
            q.petOwner.cat.Breed = obj.petOwner.cat.Breed;
            q.petOwner.cat.Quantity = obj.petOwner.cat.Quantity;
            q.petOwner.cat.Age  =  obj.petOwner.cat.Age;
            q.petOwner.cat.Weight  = obj.petOwner.cat.Weight;

            q.petOwner.dog = new Dog();
            q.petOwner.dog.Breed = obj.petOwner.dog.Breed;
            q.petOwner.dog.Quantity =   obj.petOwner.dog.Quantity;
            q.petOwner.dog.Age  = obj.petOwner.dog.Age;
            q.petOwner.dog.Weight = obj.petOwner.dog.Weight;
            q.TravelType = obj.TravelType;

            await _context.Quotes.AddAsync(q);
            await _context.SaveChangesAsync();

            return q;
        }

        public async Task<Quote> UpdateQuote(Quote updQuote)
        {
            var result = await _context.Quotes.FirstOrDefaultAsync(q => q.QuoteId == updQuote.QuoteId);

            if (result != null)
            {
                
                if (await _context.PetOwners.FirstOrDefaultAsync(p => p.PetOwnerId ==
                 result.petOwnerId) != null)
                {
                    result.petOwner.FirstName = updQuote.petOwner.FirstName;
                    result.petOwner.LastName = updQuote.petOwner.LastName;
                    result.petOwner.Email = updQuote.petOwner.Email;
                    result.petOwner.PhoneNumber = updQuote.petOwner.PhoneNumber;
                    result.petOwner.CellNumber = updQuote.petOwner.CellNumber;
                    result.TravelType = updQuote.TravelType;
                    result.petOwner.Instructions = updQuote.petOwner.Instructions;
            
                    if(await _context.Cats.FirstOrDefaultAsync(c => c.CatId == result.petOwner.catId) != null)
                    {
                        result.petOwner.cat.Age = updQuote.petOwner.cat.Age;
                        result.petOwner.cat.Quantity = updQuote.petOwner.cat.Quantity;
                        result.petOwner.cat.Breed = updQuote.petOwner.cat.Breed;
                        result.petOwner.cat.Weight = updQuote.petOwner.cat.Weight;
                    }

                    if (await _context.Dogs.FirstOrDefaultAsync(c => c.DogId == result.petOwner.dogId) != null)
                    {
                        result.petOwner.dog.Age = updQuote.petOwner.dog.Age;
                        result.petOwner.dog.Quantity = updQuote.petOwner.dog.Quantity;
                        result.petOwner.dog.Breed = updQuote.petOwner.dog.Breed;
                        result.petOwner.dog.Weight = updQuote.petOwner.dog.Weight;
                    }
                    await _context.SaveChangesAsync();
                    return result;
                }
            }
            return null;
        }

        public bool DoesItLive(int id)
        {
            return _context.Quotes.Any(e => e.QuoteId == id);
        }
    }
}
