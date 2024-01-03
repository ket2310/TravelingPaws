using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelingPawsAPI.Models;

namespace TravelingPaws.Services
{
    public interface IInMemoryQuoteService
    {
        Task<IEnumerable<Quote>> GetQuotes();
        Task<Quote> GetQuote();
        Task<Quote> GetQuote(int id);
        Task<Quote> UpdateQuote(Quote updatedQuote);
        Task<Quote> CreateQuote(Quote newQuote);
    }
}
