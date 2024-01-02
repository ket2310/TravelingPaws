using System.Collections.Generic;
using System.Threading.Tasks;
using TravelingPawsAPI.Maps;
using TravelingPawsAPI.Models;

namespace TravelingPawsAPI.Repositories
{

    public interface IQuoteRepository
    {
        Task<IEnumerable<Quote>> GetQuotes();
        bool DoesItLive(int id);
        Task<Quote> CreateAQuote(QuoteMap obj);
        Task<Quote> UpdateQuote(Quote Quote);
    }
}
