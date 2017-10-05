using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab18miya.Models
{
    public class Weather
    {
        [Key]
        public int WeatherID
        {
            get; set;
        }
        public string WeatherType
        {
            get; set;
        }
        public ICollection<Supplies> Supplies
        {
            get; set;
        }
        public ICollection<Destination> Destinations
        {
            get; set;
        }
    }
}
