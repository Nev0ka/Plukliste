using Plukliste.Classes.Database;
using Plukliste.Classes.FileHandling;

namespace Plukliste.Classes.ConsoleHandling.UserInput
{
    internal class End
    {
        public void endInterface(ref List<string> files, ref int index, Pluklist pluklist)
        {
            DBHandler handleDB = new();
            handleDB.ReadFromDb();
            foreach (var item in pluklist.Lines)
            {
                foreach (var products in handleDB.GetContent.FindAll(x => x.ProductId == item.ProductID))
                {
                    if (products.Stock >= item.Amount)
                    {
                        products.Stock -= item.Amount;
                        handleDB.updateDB(products.ID ,products.Stock, products.ProductName, products.ProductId);
                        handleDB.UpdateToDB();
                    }
                }
            }

            //Move files to import directory
            MoveFiles moveFiles = new MoveFiles();
            moveFiles.MoveFilesToWeb(files, index);
            Console.WriteLine($"Plukseddel {files[index]} afsluttet.");
            files.Remove(files[index]);
            if (index == files.Count) index--;
        }
    }
}
