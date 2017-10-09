using System.ComponentModel.DataAnnotations;

namespace Lab18George.Models
{
    public class Supply
    {
        [Key]
        public int SupplyID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
