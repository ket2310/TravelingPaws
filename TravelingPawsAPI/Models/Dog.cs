using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelingPawsAPI.Models
{
    public class Dog
    {
        public int DogId { get; set; }

     
        public string Breed { get; set; }

        public int Quantity { get; set; }

        public int Age { get; set; }

        public int Weight { get; set; }

 
    }
}
