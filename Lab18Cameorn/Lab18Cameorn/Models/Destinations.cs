using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab18Cameorn.Models
{
    public class Destinations
    {
        [Key]
        public int DestinationsID { get; set; } 
        public string Country { get; set; }
        public string Name { get; set; }
        public int Climate { get; set; }
    }
}
