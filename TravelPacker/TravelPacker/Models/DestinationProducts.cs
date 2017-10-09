using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPacker.Models
{
    public class DestinationProducts
    {
        [Key]
        public int DestinationProductsID { get; set; }
        public int DestinationID { get; set; }
        public int ProductID { get; set; }

        public Destination Destination { get; set; }
        public Product Product { get; set; }
    }
}
