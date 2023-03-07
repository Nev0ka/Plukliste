using InventoryApp.Models;
using System.Text.Json;

namespace InventoryApp.DbReader
{
    public class ReadToJson
    {
        public ReadToJson()
        { 
        }

        public enum ItemType
        {
            Fysisk, Print
        }

        public class PluklistJson
        {
            public string? Name { get; set; }
            public string? Forsendelse { get; set; }
            public string? Adresse { get; set; }
            public List<ItemsJson>? Items { get; set; }
        }

        public class ItemsJson
        {
            public string? ProductId { get; set; }
            public string? ProductName { get; set; }
            public int Amount { get; set; }
            public ItemType Type { get; set; }
        }

        public void JsonConverter(PluklistContent content)
        {
            PluklistJson pluklistJson = new();
            pluklistJson.Items = new(); 
            pluklistJson.Name = content.Name;
            pluklistJson.Forsendelse = content.Forsendelse;
            pluklistJson.Adresse = content.Adresse;
            foreach (var product in content.Items)
            {
                ItemsJson itemsJson = new();
                itemsJson.ProductId = product.ProductID;
                itemsJson.ProductName = product.ProductName;
                itemsJson.Amount = product.Amount;
                //itemsJson.Type = product.Type;
                ItemType type;
                switch (product.Type)
                {
                    case "Fysisk":
                        type = ItemType.Fysisk;
                        break;
                    case "Print":
                        type = ItemType.Print;
                        break;
                    default:
                        type = ItemType.Fysisk;
                        break;
                }
                itemsJson.Type = type;
                pluklistJson.Items.Add(itemsJson);
            }

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            string serialzePluklist = JsonSerializer.Serialize(pluklistJson, options);
            string filepath = Path.Combine("C:\\Users\\HFGF\\Desktop\\Plukliste\\Plukliste\\bin\\Debug\\net7.0\\export", $"{content.ID}{content.Name}.json");
            File.WriteAllText(filepath, serialzePluklist);
        }
    }
}
