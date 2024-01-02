using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelingPawsAPI.Models
{
    public class Cat
    {
        public int CatId { get; set; }

     

        public string Breed { get; set; }

        public int Quantity { get; set; }

        public int Age { get; set; }

        public int Weight { get; set; }

        
    }
}


/*
 *  // Dependent (child)
public class 

{
    public int Id { get; set; }
    public int BlogId { get; set; } // Optional foreign key property
    public Blog Blog { get; set; } // Optional reference navigation to principal
}

*/