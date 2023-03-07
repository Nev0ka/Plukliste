using Plukliste.Classes.Interface;

namespace Plukliste.Classes.FileHandling.Read
{
    internal class CSVReadFiles : IReader
    {
        public Pluklist? ReadFilesToWeb(List<string> files, int index)
        {
            string[] file = File.ReadAllLines(files[index]);
            Pluklist? plukliste = new();

            string firstName = Path.GetFileName(files[index]).Split('_')[1];
            string lastName = Path.GetFileName(files[index]).Split('_')[2];
            lastName = lastName.Split('.')[0];


            plukliste.Name = firstName + ' ' + lastName;
            plukliste.Forsendelse = "Pickup";
            plukliste.Adresse = "Pickup";
            foreach (var line in file)
            {
                Item item = new();
                var splittedLine = line.Split(';');
                if (splittedLine[0].Equals("Productid", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                item.ProductID = splittedLine[0];
                if (splittedLine[1].Equals("print", StringComparison.OrdinalIgnoreCase))
                {
                    item.Type = ItemType.Print;
                }
                else if (splittedLine[1].Equals("fysisk", StringComparison.OrdinalIgnoreCase))
                {
                    item.Type = ItemType.Fysisk;
                }
                item.Name = splittedLine[2];
                item.Amount = Convert.ToInt32(splittedLine[3]);
                plukliste.AddItem(item);
            }
            return plukliste;
        }
    }
}