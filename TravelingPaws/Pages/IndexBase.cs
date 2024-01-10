using TravelingPawsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelingPaws.Components;
using System;

namespace TravelingPaws.Pages
{
    public class IndexBase : GlobaldataService
    {

        // Instantiate all objects
        public IEnumerable<Quote> Quotes { get; set; } = new List<Quote>();

        protected override async Task OnInitializedAsync()
        {
            if (Environment.MachineName == "Coyote2" || Environment.MachineName == "ROADRUNNER2")
                Quotes = await QuoteService.GetQuotes();
            else
                Quotes = await InMemoryQuoteService.GetQuotes();

        }
    }
}
