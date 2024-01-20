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
        public Quote quote { get; set; } = new Quote();

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            // If Id value is not supplied in the URL, use the value
            // 
            quote = new Quote
            {
                petOwner = new PetOwner()
                {
                    dog = new Dog(),
                    cat = new Cat()
                },

        
                trip = new Trip()
            };
            Id = Id ?? "1";

            if (Environment.MachineName == "COYOTE2" || Environment.MachineName == "ROADRUNNER2")
                quote = await QuoteService.GetQuote(int.Parse(Id));
            else
                quote = await InMemoryQuoteService.GetQuote(int.Parse(Id));
        }
    }
}
