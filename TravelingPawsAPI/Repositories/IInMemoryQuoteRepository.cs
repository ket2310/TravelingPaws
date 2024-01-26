using TravelingPawsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelingPawsAPI.Maps;

namespace TravelingPawsAPI.Repositories
{
    public interface IInMemoryQuoteRepository
    {
        Task<IEnumerable<Quote>> GetQuotes();
        bool DoesItLive(int id);
        Task<Quote> GetQuote(int id);
        Task<Quote> CreateAQuote(QuoteMap obj);
        Task<Quote> UpdateQuote(Quote Quote);
        Task<Quote> DeleteQuote(int quoteId);
    }
}
