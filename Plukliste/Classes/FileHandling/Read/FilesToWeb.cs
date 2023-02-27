using Plukliste.Classes.Interface;
using System;

namespace Plukliste.Classes.FileHandling.Read
{
    internal class FilesToWeb
    {
        public Pluklist? Deserializer(List<string> files, int index)
        {
            var fileExtension = Path.GetExtension(files[index]);
            var className = $"Plukliste.Classes.FileHandling.Read{fileExtension.ToUpper()}ReadFiles";
            var readerType = Type.GetType(className);
            var ReaderFiles = (IReader)Activator.CreateInstance(readerType);
            return ReaderFiles.ReadFilesToWeb(files, index);
        }
    }
}
