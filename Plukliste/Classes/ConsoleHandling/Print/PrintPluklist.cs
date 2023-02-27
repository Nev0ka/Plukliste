namespace Plukliste.Classes.ConsoleHandling.Print
{
    internal class PrintPluklist
    {
        public void PrintPlukliste(Pluklist? plukliste)
        {
            if (plukliste != null && plukliste.Lines != null)
            {
                Console.WriteLine("\n{0, -13}{1}", "Name:", plukliste.Name);
                Console.WriteLine("{0, -13}{1}", "Forsendelse:", plukliste.Forsendelse);
                Console.WriteLine("{0, -13}{1}", "Adresse:", plukliste.Adresse);

                Console.WriteLine("\n{0,-7}{1,-9}{2,-20}{3}", "Antal", "Type", "Produktnr.", "Navn");
                foreach (var item in plukliste.Lines)
                {
                    Console.WriteLine("{0,-7}{1,-9}{2,-20}{3}", item.Amount, item.Type, item.ProductID, item.Title);
                }
            }
        }
    }
}
