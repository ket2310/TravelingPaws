using ExecPetTransportBlazorAPI517.Models;
using System.ComponentModel.DataAnnotations;

namespace TravelingPawsAPI.Models
{
    public class PetOwner
    {
        [Key]
        public int PetOwnerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CellNumber { get; set; }
        public string Instructions { get; set; }


        public int catId { get; set; }
        public Cat cat { get; set; }

        public int dogId { get; set; }

        public Dog dog { get; set; }
    }
}
