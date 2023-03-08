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
            public List<ItemsJson> Lines { get; set; }
        }

        public class ItemsJson
        {
            public string? ProductID { get; set; }
            public string? Title { get; set; }
            public int Amount { get; set; }
            public ItemType Type { get; set; }
        }

        public void JsonConverter(PluklistContent content)
        {
            PluklistJson pluklistJson = new();
            List<ItemsJson> itemList = new();
            pluklistJson.Name = content.Name;
            pluklistJson.Forsendelse = content.Forsendelse;
            pluklistJson.Adresse = content.Adresse;
            foreach (var product in content.Items)
            {
                ItemsJson itemsJson = new();
                itemsJson.ProductID = product.ProductID;
                itemsJson.Title = product.ProductName;
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
               itemList.Add(itemsJson);
            }
            pluklistJson.Lines = itemList;

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
