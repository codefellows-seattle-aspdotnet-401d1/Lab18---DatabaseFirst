using System.ComponentModel.DataAnnotations;

namespace lab18_brian.Models
{
    public class PackingListItems
    {
        [Key]
        public int packinglistID { get; set; }
        [Key]
        public int itemID { get; set; }

        public PackingList PackingList { get; set; }
        public Item Item { get; set; }
    }
}
