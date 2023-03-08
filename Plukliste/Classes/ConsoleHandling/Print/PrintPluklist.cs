using Plukliste.Classes.Database;

namespace Plukliste.Classes.ConsoleHandling.Print
{
    internal class PrintPluklist
    {
        public void PrintPlukliste(Pluklist? plukliste)
        {
            DBHandler handleDB = new();
            if (plukliste != null && plukliste.Lines != null)
            {
                Console.WriteLine("\n{0, -13}{1}", "Name:", plukliste.Name);
                Console.WriteLine("{0, -13}{1}", "Forsendelse:", plukliste.Forsendelse);
                Console.WriteLine("{0, -13}{1}", "Adresse:", plukliste.Adresse);

                Console.WriteLine("\n{0,-7}{1,-9}{2,-20}{3}", "Antal", "Type", "Produktnr.", "Navn");
                handleDB.ReadFromDb();

                foreach (var item in plukliste.Lines)
                {
                    var color = Console.ForegroundColor;
                    string productString = $"{item.Amount,-7}{item.Type,-9}{item.ProductID,-20}{item.Title}";
                    if(handleDB.GetContent == null)
                    {
                        Console.WriteLine("Failed: Databse is empty");
                    }

                    foreach(var products in handleDB.GetContent.Where(x => x.ProductId == item.ProductID))
                    {
                        if(products.Stock == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            productString += $" The stock is: {products.Stock}";
                        }
                        else if (products.Stock < item.Amount)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            productString += $" There aren't enough in stock. The stock is: {products.Stock}";
                        }
                    }
                    Console.WriteLine(productString);
                    Console.ForegroundColor = color;
                }
            }
        }
    }
}
