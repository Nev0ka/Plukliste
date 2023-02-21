namespace Plukliste.Classes.Interface
{
    interface IReader
    {
        public Pluklist? ReadFilesToWeb(List<string> files, int index);
    }
}
