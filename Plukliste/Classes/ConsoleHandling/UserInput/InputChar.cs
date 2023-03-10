using Plukliste.Classes.FileHandling;
using Plukliste.Classes.FileHandling.Read;
using Plukliste.Classes.FileHandling.Write;
using static System.Net.WebRequestMethods;

namespace Plukliste.Classes.ConsoleHandling.UserInput
{
    internal class InputChar
    {
        public void SelectedKeyChar(char readKey, ref List<string> files, ref int index)
        {
            FilesToWeb FTW = new FilesToWeb();
            Pluklist pluklist = FTW.Deserializer(files, index);
            Refresh refresh = new Refresh();
            Previous previous = new Previous();
            Next next = new Next();
            End end = new End();
            PrintFiles printFiles = new PrintFiles();
            var standardColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            switch (readKey)
            {
                case 'G':
                    refresh.refreshInterface(ref files,ref index);
                    break;
                case 'F':
                    previous.previousInterface(ref index);
                    break;
                case 'N':
                    next.nextInterface(files,ref index);
                    break;
                case 'A':
                    end.endInterface(ref files, ref index, pluklist);
                    break;
                case 'P':
                    printFiles.PrintFilesToWeb(index, files);
                    break;
            }
            Console.ForegroundColor = standardColor;
        }
    }
}
