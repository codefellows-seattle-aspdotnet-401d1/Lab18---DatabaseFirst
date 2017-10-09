using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab18George.Models
{
    public class Destination
    {
        [Key]
        public int DestinationID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int WeatherID { get; set; }
    }
}
