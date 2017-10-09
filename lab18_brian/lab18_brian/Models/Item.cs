using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace lab18_brian.Models
{
    public class Item
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
