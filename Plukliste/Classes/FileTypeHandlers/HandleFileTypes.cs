using System.Security;
using Plukliste.Classes.Interface;

namespace Plukliste.Classes.FileTypeHandlers
{
    internal class HandleFileTypes : IFileHandler
    {
        public Pluklist? pluklist;
        static string fileIdName = string.Empty;

        public HandleFileTypes(Pluklist plukliste, string fileName)
        {
            pluklist = plukliste;
            fileIdName = fileName;
        }

        public string ReadFileType(string fileName)
        {
            fileName += ".html";
            string filePath = Path.Combine("templates", fileName);
            return File.ReadAllText(filePath);
        }

        public void WriteFileType(string fileContent, string fileType)
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

        internal void PrintFile(string fileName)
        {
            WriteFileType(ReplaceSqaureBrackets(ReadFileType(fileName)), fileName);
        }
    }
}
