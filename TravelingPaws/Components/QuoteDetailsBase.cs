using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelingPaws.Services;
using TravelingPawsAPI.Models;

namespace TravelingPaws.Components
{
    public class QuoteDetailsBase : GlobaldataService
    {
        public Quote quote { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            // If Id value is not supplied in the URL, use the value 1
            Id = Id ?? "1";
            quote = await InMemoryQuoteService.GetQuote(int.Parse(Id));
        }
    }
}
