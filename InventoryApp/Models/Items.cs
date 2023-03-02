namespace InventoryApp.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public string ProductId { get; set; }
        public int PluklistId { get; set; }
        public PluklistContent? PluklistContent { get; set; }
    }
}
