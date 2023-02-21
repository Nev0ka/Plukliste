using Plukliste.Classes.Interface;
using ServiceStack.Text;

namespace Plukliste.Classes.FileHandling.Read
{
    internal class XMLReadFiles : IReader
    {
        public Pluklist? ReadFilesToWeb(List<string> files, int index)
        {
            FileStream file;
            file = File.OpenRead(files[index]);
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Pluklist));
            Pluklist? plukliste = (Pluklist?)xmlSerializer.Deserialize(file);
            file.Close();
            return plukliste;
        }
    }
}
