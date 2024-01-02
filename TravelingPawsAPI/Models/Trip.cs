using System;

namespace TravelingPawsAPI.Models
{
    public class Trip
    {
                          
        public int TripId { get; set; }

        public int TravelTypeId { get; set; }
        public DateTime traveldate { get; set; }

        public DateTime returndate { get; set; }
        public string pickupaddress { get; set; }

        public string pickupaddress2 { get; set; }

        public string pickupcity { get; set; }

        public string pickupstate { get; set; }
        public string pickupzip { get; set; }

        public string destinationaddress { get; set; }
        public string destinationaddress2 { get; set; }

        public string destinationcity { get; set; }

        public string destinationstate { get; set; }

        public string destinationzip { get; set; }

        public string otherinfo { get; set; }

   
    }

}
