using Plukliste.Classes.FileHandling.Read;
using Plukliste.Classes.FileTypeHandlers;

namespace Plukliste.Classes.FileHandling.Write
{
    internal class PrintFiles
    {
        public void PrintFilesToWeb(int index, List<string> files)
        {
            FilesToWeb Webber = new FilesToWeb();
            Pluklist? pluklistFiles = Webber.Deserializer(files, index);
            HandleFileTypes HTMLFileHandler = new HandleFileTypes(pluklistFiles, files[index]);
            foreach (var item in pluklistFiles.Lines)
            {
                if (item.ProductID.Contains("PRINT"))
                {
                    HTMLFileHandler.PrintFile(item.ProductID);
                }
            }
        }
    }
}
