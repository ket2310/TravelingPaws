using AutoMapper;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using TravelingPaws.Services;
using TravelingPawsAPI.Enums;
using TravelingPawsAPI.Maps;
using TravelingPawsAPI.Models;

namespace TravelingPaws.Components
{
    public class QuoteComponentBase : ComponentBase
    {
        [Inject]
        public IQuoteService QuoteService { get; set; }
        public Quote Quote { get; set; } = new Quote { petOwner = new PetOwner() };
        public QuoteMap quoteMap { get; set; } = new QuoteMap { petOwner = new PetOwner() };

        [Parameter]
        public string Id { get; set; }
 
        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int QuoteId);

            if (QuoteId != 0)
            {
                Quote = await QuoteService.GetQuote(int.Parse(Id));
            }
            else
            {
                Quote = new Quote
                {
                    petOwner = new PetOwner()
                    {
                        dog = new Dog(),
                        cat = new Cat()
                    },
                    TravelType = TravelTypes.TwoWay
                   
                };
            }

            Mapper.Map(Quote, quoteMap);
        }
       
        protected async Task HandleValidSubmit()
        {
           Mapper.Map(quoteMap, Quote);

            Quote result = null;

            if (Quote.QuoteId != 0)
            {
                result = await QuoteService.UpdateQuote(Quote);
            }
            else
            {
                result = await QuoteService.CreateQuote(Quote);
            }
            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
