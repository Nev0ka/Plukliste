namespace InventoryApp.Models
{
    public class PluklistData
    {
        public IEnumerable<PluklistContent> Pluklists { get; set; }
        public IEnumerable<Items> Items { get; set; }
    }
}
