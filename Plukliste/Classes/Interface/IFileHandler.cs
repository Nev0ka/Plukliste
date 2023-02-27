namespace Plukliste.Classes.Interface
{
    interface IFileHandler
    {
        string ReadFileType(string fileName);
        void WriteFileType(string fileContent, string fileType);
    }
}
