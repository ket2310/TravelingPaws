using TravelingPawsAPI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TravelingPaws.Services
{
    public interface IQuoteService
    {
        Task<IEnumerable<Quote>> GetQuotes();
        Task<Quote> GetQuote();               
        Task<Quote> GetQuote(int id);
        Task<Quote> UpdateQuote(Quote updatedQuote);
        Task<Quote> CreateQuote(Quote newQuote);
    }
}
