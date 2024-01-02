using TravelingPaws.Pages;
using TravelingPawsAPI.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace TravelingPaws.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly HttpClient _httpClient;
        private readonly string url = "api/quotes";

        public QuoteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //----------------------------------------------------
        public async Task<IEnumerable<Quote>> GetQuotes()
        {
            var result = await _httpClient.GetFromJsonAsync<Quote[]>(url);
            return result;
        }

        //*************************************************************************************************



        public async Task<Quote> CreateQuote(Quote newQuote)
        {
            var response = await _httpClient.PostAsJsonAsync<Quote>("api/Quotes", newQuote);

            if (response.IsSuccessStatusCode)
                return newQuote;

            return null;
        }

        public Task<Quote> GetQuote()
        {
            throw new System.NotImplementedException();
        }

        public Task<Quote> GetQuote(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Quote> UpdateQuote(Quote updatedQuote)
        {
            throw new System.NotImplementedException();
        }
    }
}
