using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelingPaws.Services;

namespace TravelingPaws.Components
{
    public class GlobaldataService : ComponentBase
    {
        [Inject]
        public IQuoteService QuoteService { get; set; }

        [Inject]
        public IInMemoryQuoteService InMemoryQuoteService { get; set; }

    }
}
