using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab18DatabaseRelation.Models
{
    public class DestinationTravelItem
    {
  
        public int DestinationID { get; set; }
        public int TravelItemID { get; set; }

        public Destination Destination { get; set; }
        public TravelItem TravelItem { get; set; }
    }
}
