using Plukliste.Classes.ConsoleHandling.Print;
using Plukliste.Classes.ConsoleHandling.UserInput;
using Plukliste.Classes.FileHandling.Read;

namespace Plukliste;

class PluklisteProgram
{
    static void Main()
    {
        //Arrange
        char readKey = ' ';
        List<string> filesList;
        Directory.CreateDirectory("import");
        if (!Directory.Exists("export"))
        {
            Console.WriteLine("Directory \"export\" not found");
            Console.ReadLine();
            return;
        }
        //ACT
        var currentFile = -1;
        while (readKey != 'Q')
        {
            filesList = Directory.EnumerateFiles("export").ToList();
            if (filesList.Count == 0)
            {
                Console.WriteLine("No files found.");
            }
            else
            {
                if (currentFile == -1) currentFile = 0;
                Console.WriteLine($"Plukliste {currentFile + 1} af {filesList.Count}");
                Console.WriteLine($"\nfile: {filesList[currentFile]}");
                FilesToWeb FTW = new FilesToWeb();
                Pluklist? plukliste = FTW.Deserializer(filesList, currentFile);
                PrintPluklist printPluklist = new PrintPluklist();
                printPluklist.PrintPlukliste(plukliste);
            }
            //Print options
            PluklistOptions pluklistOptions = new PluklistOptions();
            pluklistOptions.PrintPluklisteOptions(filesList, currentFile);
            readKey = Console.ReadKey().KeyChar;
            if (char.IsLower(readKey)) readKey = char.ToUpper(readKey);
            Console.Clear();
            InputChar inputChar = new InputChar();
            inputChar.SelectedKeyChar(readKey, ref filesList, ref currentFile);
        }
    }
}