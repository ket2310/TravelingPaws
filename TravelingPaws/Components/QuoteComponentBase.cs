using AutoMapper;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using TravelingPaws.Services;
using TravelingPawsAPI.Enums;
using TravelingPawsAPI.Maps;
using TravelingPawsAPI.Models;

namespace TravelingPaws.Components
{
    public class QuoteComponentBase : GlobaldataService
    {

        public Quote Quote { get; set; } = new Quote { petOwner = new PetOwner { dog = new Dog(), cat = new Cat()}, trip = new Trip() };
        public QuoteMap quoteMap { get; set; } = new QuoteMap { petOwner = new PetOwner { dog = new Dog(), cat = new Cat() }, trip = new Trip()};

        public string PageHeaderText = string.Empty;

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
                PageHeaderText = "Edit Your Quote ";
                if (Environment.MachineName == "COYOTE2" || Environment.MachineName == "ROADRUNNER2")
                    Quote = await QuoteService.GetQuote(int.Parse(Id));
                else
                    Quote = await InMemoryQuoteService.GetQuote(int.Parse(Id));
            }
            else
            {
                PageHeaderText = "Request a FREE QUOTE ";
                Quote.petOwner.FirstName = "Kirk";
                Quote.petOwner.LastName = "Thomas";
                Quote.petOwner.Email = "dablumaroo@gmail.com";
                Quote.petOwner.PhoneNumber = "979-676-0076";
                Quote.petOwner.CellNumber = "979-676-0076";
                Quote.petOwner.Instructions = "My dog is afraid of storms";

                Quote.petOwner.cat.Quantity = 0;
                Quote.petOwner.cat.Age = 0;
                Quote.petOwner.cat.Weight = 0;
                Quote.petOwner.cat.Breed = "";

                Quote.petOwner.dog.Quantity = 1;
                Quote.petOwner.dog.Age = 10;
                Quote.petOwner.dog.Weight = 60;
                Quote.petOwner.dog.Breed = "Labrador";

                Quote.trip.TravelTypeId = TravelTypes.TwoWay;
                Quote.trip.traveldate = System.DateTime.Now;
                Quote.trip.returndate = System.DateTime.Now.AddDays(7);

                Quote.trip.pickupaddress = "5303 Creek Lane";
                Quote.trip.pickupaddress2 = "";
                Quote.trip.pickupcity = "College Station";
                Quote.trip.pickupstate = "Texas";
                Quote.trip.pickupzip = "77845";

                Quote.trip.destinationaddress = "106 Round Hill Road";
                Quote.trip.destinationaddress2 = "";
                Quote.trip.destinationcity = "Dobbs Ferry";
                Quote.trip.destinationstate = "New York";
                Quote.trip.destinationzip = "10522";

                Quote.trip.otherinfo = "";
            }

            Mapper.Map(Quote, quoteMap);

        }

        protected async Task Delete_Click()
        {
            await QuoteService.DeleteQuote(Quote.QuoteId);
            NavigationManager.NavigateTo("/");
        }
        protected async Task HandleValidSubmit()
        {
            Mapper.Map(quoteMap, Quote);

            Quote result = null;

            if (Quote.QuoteId != 0)
            {
                if (Environment.MachineName == "COYOTE2" || Environment.MachineName == "ROADRUNNER2")
                    result = await QuoteService.UpdateQuote(Quote);
                else
                    result = await InMemoryQuoteService.UpdateQuote(Quote);
            }
            else
            {
                if (Environment.MachineName == "COYOTE2" || Environment.MachineName == "ROADRUNNER2") 
                    result = await QuoteService.CreateQuote(Quote);
                else
                    result = await InMemoryQuoteService.CreateQuote(Quote);
            }
            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
