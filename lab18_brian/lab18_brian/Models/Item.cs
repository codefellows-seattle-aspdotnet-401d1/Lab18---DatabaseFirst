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
        //Going to set quantity attribute during packing list creation
        [HiddenInput(DisplayValue = false)]
        public int Quantity { get; set; }
    }
}
