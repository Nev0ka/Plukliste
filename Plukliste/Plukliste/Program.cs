//Eksempel på funktionel kodning hvor der kun bliver brugt et model lag
using Plukliste.Classes;

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
                Pluklist? plukliste = ReadFiles(filesList, currentFile);
                PrintPlukliste(plukliste);
            }
            //Print options
            PrintPluklisteOptions(filesList, currentFile);
            readKey = Console.ReadKey().KeyChar;
            if (char.IsLower(readKey)) readKey = char.ToUpper(readKey);
            Console.Clear();
            SelectedKeyChar(readKey, ref filesList, ref currentFile);
        }
    }

    private static Pluklist? ReadFiles(List<string> files, int index)
    {
        FileStream file;
        file = File.OpenRead(files[index]);
        System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Pluklist));
        Pluklist? plukliste = (Pluklist?)xmlSerializer.Deserialize(file);
        file.Close();
        return plukliste;
    }

    private static void PrintPlukliste(Pluklist? plukliste)
    {
        if (plukliste != null && plukliste.Lines != null)
        {
            Console.WriteLine("\n{0, -13}{1}", "Name:", plukliste.Name);
            Console.WriteLine("{0, -13}{1}", "Forsendelse:", plukliste.Forsendelse);
            Console.WriteLine("{0, -13}{1}", "Adresse:", plukliste.Adresse);

            Console.WriteLine("\n{0,-7}{1,-9}{2,-20}{3}", "Antal", "Type", "Produktnr.", "Navn");
            foreach (var item in plukliste.Lines)
            {
                Console.WriteLine("{0,-7}{1,-9}{2,-20}{3}", item.Amount, item.Type, item.ProductID, item.Title);
            }
        }
    }

    private static void PrintDisplayOptions(ConsoleColor standardColor, string options)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(options[0]);
        Console.ForegroundColor = standardColor;
        Console.WriteLine(options.Remove(0, 1));
    }

    private static void PrintPluklisteOptions(List<string> files, int index)
    {
        var standardColor = Console.ForegroundColor;
        Console.WriteLine("\n\nOptions:");
        PrintDisplayOptions(standardColor, "Quit");
        if (index >= 0)
        {
            PrintDisplayOptions(standardColor, "Afslut plukeseddel");
        }
        if (index > 0)
        {
            PrintDisplayOptions(standardColor, "Forrige plukeseddel");
        }
        if (index < files.Count - 1)
        {
            PrintDisplayOptions(standardColor, "Næste plukeseddel");
        }
        PrintDisplayOptions(standardColor, "Genindlæs plukeseddel");
        PrintDisplayOptions(standardColor, "Print vejledninger");
    }

    private static void MoveFiles(List<string> files, int index)
    {
        var filewithoutPath = files[index].Substring(files[index].LastIndexOf('\\'));
        File.Move(files[index], string.Format(@"import\\{0}", filewithoutPath));
    }

    private static void SelectedKeyChar(char readKey, ref List<string> files, ref int index)
    {
        var standardColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        switch (readKey)
        {
            case 'G':
                files = Directory.EnumerateFiles("export").ToList();
                index = -1;
                Console.WriteLine("Pluklister genindlæst");
                break;
            case 'F':
                if (index > 0) index--;
                break;
            case 'N':
                if (index < files.Count - 1) index++;
                break;
            case 'A':
                //Move files to import directory
                MoveFiles(files, index);
                Console.WriteLine($"Plukseddel {files[index]} afsluttet.");
                files.Remove(files[index]);
                if (index == files.Count) index--;
                break;
            case 'P':
                PrintFiles(index, files);
                break;
        }
        Console.ForegroundColor = standardColor;
    }

    private static void PrintFiles(int index, List<string> files)
    {
        Pluklist? pluklist = ReadFiles(files, index);
        HandleHTML HTMLFileHandler = new HandleHTML(pluklist, files[index]);
        foreach (var item in pluklist.Lines) 
        {
            if (item.ProductID.Contains("PRINT"))
            {
                HTMLFileHandler.PrintHTMLFile(item.ProductID);
            }
        }
    }
}