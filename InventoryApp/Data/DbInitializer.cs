using InventoryApp.Models;

namespace InventoryApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(InventoryAppContext context)
        {
            if (context.InventoryContent.Any())
            {
                return;   // DB has been seeded
            }

            var inventoryContents = new InventoryContent[]
            {
                new InventoryContent{ProductId="NETGEAR-CM1000",ProductName="NETGEAR DOCSIS 3.1 (CM1000)",Stock=200},
                new InventoryContent{ProductId="TX-302587",ProductName = "Triax TD 241E stikdås",Stock=300}
            };

            context.InventoryContent.AddRange(inventoryContents);
            context.SaveChanges();
        }
    }
}   
