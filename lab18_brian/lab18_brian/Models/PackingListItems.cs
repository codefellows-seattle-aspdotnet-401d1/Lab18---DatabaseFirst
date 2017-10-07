using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lab18_brian.Models
{
    public class PackingListItems
    {
        [Key]
        [DisplayName("Destiantion")]
        public int packinglistID { get; set; }
        [Key]
        [DisplayName("Chose which items you need")]
        public int itemID { get; set; }

        public PackingList PackingList { get; set; }
        public Item Item { get; set; }
    }
}
