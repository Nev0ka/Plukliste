namespace InventoryApp.Pages.Pluklist;
public class Pluklist
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Forsendelse { get; set; }
    public string? Adresse { get; set; }
    public List<Item> Lines = new List<Item>();
    public void AddItem(Item item) { Lines.Add(item); }
}

public class Item
{
    public int Id { get; set; }
    public string ProductID { get; set; }
    public string Title { get; set; }
    public ItemType Type { get; set; }
    public int Amount { get; set; }
    public int PluklistId { get; set; }
    public Pluklist Pluklist { get; set; }
}

public enum ItemType
{
    Fysisk, Print
}



