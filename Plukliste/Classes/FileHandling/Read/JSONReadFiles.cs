using Plukliste.Classes.Interface;
using System.Text.Json;

namespace Plukliste.Classes.FileHandling.Read
{
    internal class JSONReadFiles : IReader
    {
        public Pluklist? ReadFilesToWeb(List<string> files, int index)
        {
            //FileStream file;
            //file = File.OpenRead(files[index]);
            //Pluklist? plukliste = JsonSerializer.Deserialize<Pluklist?>(file);
            //file.Close();
            //return plukliste;
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var file = File.ReadAllText(files[index]);
            Pluklist? plukliste = JsonSerializer.Deserialize<Pluklist?>(file, options);
            return plukliste;
        }
    }
}
