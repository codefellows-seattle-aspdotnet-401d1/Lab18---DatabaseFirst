using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab18_brian.Models
{
    public class PackingList
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        ICollection<Item> Items { get; set; }
    }
}
