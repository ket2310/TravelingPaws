using AutoMapper;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using TravelingPaws.Services;
using TravelingPawsAPI.Enums;
using TravelingPawsAPI.Maps;
using TravelingPawsAPI.Models;

namespace TravelingPaws.Components
{
    public class QuoteComponentBase : GlobaldataService
    {
     
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
                //Quote = await QuoteService.GetQuote(int.Parse(Id));
                Quote = await InMemoryQuoteService.GetQuote(int.Parse(Id));
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
                    
                    TravelType = TravelTypes.TwoWay,
                    trip = new Trip()
                };
                Quote.petOwner.FirstName = "Kirk";
                Quote.petOwner.LastName = "Thomas";
                Quote.petOwner.Email = "dablumaroo@gmail.com";
                Quote.petOwner.PhoneNumber = "979-676-0076";
                Quote.petOwner.CellNumber = "979-676-0076";
                Quote.petOwner.Instructions = "My dog is afraid of storms";
                Quote.petOwner.dog.Quantity = 1;
                Quote.petOwner.dog.Age = 10;
                Quote.petOwner.dog.Weight = 60;
                Quote.petOwner.dog.Breed = "Labrador";
                Quote.trip.traveldate = System.DateTime.Now;
                Quote.trip.returndate = System.DateTime.Now.AddDays(7);
            }

            Mapper.Map(Quote, quoteMap);
        }
       
        protected async Task HandleValidSubmit()
        {
           Mapper.Map(quoteMap, Quote);

            Quote result = null;

            if (Quote.QuoteId != 0)
            {
                //result = await QuoteService.UpdateQuote(Quote);
                result = await InMemoryQuoteService.UpdateQuote(Quote);
            }
            else
            {
             //   result = await QuoteService.CreateQuote(Quote);
                  result = await InMemoryQuoteService.CreateQuote(Quote);
            }
            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
