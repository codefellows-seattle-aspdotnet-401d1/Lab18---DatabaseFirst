using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab18DatabaseRelation.Models
{
    public class TravelItem
    {
        public int ID { get; set; }
        [Required]
        public string ItemName { get; set; }
        public virtual ICollection<DestinationTravelItem> DestinationTravelItems { get; set; }
    }
}
