using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab18DatabaseRelation.Models
{
    public class Destination
    {
        public int ID { get; set; }
        public string LocationName { get; set; }
        public string Description { get; set; }
        public string Distance { get; set; }
        public string PosterPath { get; set; }
        public virtual ICollection<DestinationTravelItem> DestinationTravelItems { get; set; }
    }
}
