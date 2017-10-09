using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPacker.Models
{
    public class Destination
    {
        [Key]
        public int DestinationID { get; set; }
        public string LocationName { get; set; }
        public string Climate { get; set; }
    }
}
