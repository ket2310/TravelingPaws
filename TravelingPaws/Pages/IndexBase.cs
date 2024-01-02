using Microsoft.AspNetCore.Components;
using TravelingPaws.Services;
using TravelingPawsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TravelingPaws.Pages
{
    public class IndexBase :ComponentBase
    {
        [Inject]
        public IQuoteService QuoteService { get; set; }

        // Instantiate all objects
        public IEnumerable<Quote> Quotes { get; set; } = new List<Quote>();

        protected override async Task OnInitializedAsync()
        {
            Quotes = (await QuoteService.GetQuotes());

        }
    }
}
