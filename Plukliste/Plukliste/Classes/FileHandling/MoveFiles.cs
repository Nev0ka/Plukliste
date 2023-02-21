namespace Plukliste.Classes.FileHandling
{
    internal class MoveFiles
    {
        public void MoveFilesToWeb(List<string> files, int index)
        {
            var filewithoutPath = files[index].Substring(files[index].LastIndexOf('\\'));
            File.Move(files[index], string.Format(@"import\\{0}", filewithoutPath));
        }
    }
}
