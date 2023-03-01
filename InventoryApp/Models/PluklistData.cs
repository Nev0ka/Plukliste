using InventoryApp.Pages.Pluklist;

namespace InventoryApp.Models
{
    public class PluklistData
    {
        public IEnumerable<Pluklist> Pluklists { get; set; }
        public IEnumerable<Item> Item { get; set; }
    }
}
