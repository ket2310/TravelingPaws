using TravelingPawsAPI.Enums;
using TravelingPawsAPI.Models;

namespace TravelingPawsAPI.Maps
{
    public class QuoteMap
    {
        public PetOwner petOwner { get; set; }

        public TravelTypes TravelType { get; set; }

        public Trip trip { get; set; }
    }
}
