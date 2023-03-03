namespace InventoryApp.Models
{
    public class Items
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public string ProductID { get; set; }
        public int PluklistContentID { get; set; }
        public PluklistContent? pluklistContent { get; set; }
    }
}
