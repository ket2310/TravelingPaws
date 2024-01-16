using TravelingPaws.Pages;
using TravelingPawsAPI.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System;

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
            var response = await _httpClient.PostAsJsonAsync<Quote>(url, newQuote);

            if (response.IsSuccessStatusCode)
                return newQuote;

            return null;
        }

        public Task<Quote> GetQuote()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Quote> GetQuote(int id)
        {         
            return await _httpClient.GetFromJsonAsync<Quote>(url + "/" + id.ToString());
        }

        public async Task<Quote> UpdateQuote(Quote updatedQuote)
        {
            var response = await _httpClient.PutAsJsonAsync<Quote>(url, updatedQuote);

            if (response.IsSuccessStatusCode)
                return updatedQuote;

            return null;
        }

        public  async Task DeleteQuote(int id)
        {
            await _httpClient.DeleteAsync(url + "/" + id.ToString());
        }
    }
}
