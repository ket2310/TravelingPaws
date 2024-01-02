using TravelingPawsAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace TravelingPawsAPI.Models
{
    public class Quote
    {
        [Key]
        public int QuoteId { get; set; }

        public int petOwnerId { get; set; }

        public PetOwner petOwner { get; set; }

        public TravelTypes TravelType { get; set; }

        public int tripId { get; set; }

        public Trip trip { get; set; }
    }
}
