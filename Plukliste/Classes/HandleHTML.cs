using System.Security;

namespace Plukliste.Classes
{
    internal class HandleHTML
    {
        public Pluklist? pluklist;
        static string fileIdName = string.Empty;

        public HandleHTML(Pluklist plukliste, string fileName)
        {
            pluklist = plukliste;
            fileIdName = fileName;
        }

        internal string ReadHTMLFile(string fileName)
        {
            fileName += ".html";
            string filePath = Path.Combine("templates", fileName);
            return File.ReadAllText(filePath);
        }

        internal void WriteHTMLFile(string fileContent, string fileType)
        {
            string folderName = "Udskriftsmappen";
            Directory.CreateDirectory(folderName);
            string fileName = Path.GetFileName(fileIdName).Split('.')[0] + "-" + fileType + ".html";
            string path = Path.Combine(folderName, fileName);
            File.WriteAllText(path, fileContent);
        }

        internal string ReplaceSqaureBrackets(string fileContent)
        {
            string plukliste = string.Empty;
            fileContent = fileContent.Replace("[Adresse]", pluklist.Adresse);
            fileContent = fileContent.Replace("[Name]", pluklist.Name);
            foreach (var item in pluklist.Lines)
            {
                plukliste += $"{item.Amount} {item.Name} <br>";
            }
            fileContent = fileContent.Replace("[Plukliste]", plukliste);
            return fileContent;
        }

        internal void PrintHTMLFile(string fileName)
        {
            WriteHTMLFile(ReplaceSqaureBrackets(ReadHTMLFile(fileName)), fileName);
        }
    }
}
