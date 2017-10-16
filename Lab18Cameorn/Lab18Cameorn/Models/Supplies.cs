using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab18Cameorn.Models
{
    public class Supplies
    {
        [Key]
        public int SuppliesID { get; set; }
        public string Name { get; set; }
        public string Qty { get; set; }
    }
}
