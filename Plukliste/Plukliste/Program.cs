//Eksempel på funktionel kodning hvor der kun bliver brugt et model lag
namespace Plukliste;

class PluklisteProgram
{

    static void Main()
    {
        //Arrange
        char readFirstCharKey = ' ';
        List<string> filesList;
        var index = -1;
        var standardColor = Console.ForegroundColor;
        Directory.CreateDirectory("import");
        if (!Directory.Exists("export"))
        {
            Console.WriteLine("Directory \"export\" not found");
            Console.ReadLine();
            return;
        }
        //ACT
        while (readFirstCharKey != 'Q')
        {
            filesList = Directory.EnumerateFiles("export").ToList();
            if (filesList.Count == 0)
            {
                Console.WriteLine("No files found.");
            }
            else
            {
                if (index == -1) index = 0;
                Console.WriteLine($"Plukliste {index + 1} af {filesList.Count}");
                Console.WriteLine($"\nfile: {filesList[index]}");
                Pluklist? plukliste = ReadFiles(filesList, index);
                PrintPlukliste(plukliste);
            }
            //Print options
            PrintCharOptions(filesList, index, standardColor);
            readFirstCharKey = Console.ReadKey().KeyChar;
            if (char.IsLower(readFirstCharKey)) readFirstCharKey = char.ToUpper(readFirstCharKey);
            Console.Clear();
            InputChar(readFirstCharKey, ref filesList, ref index, standardColor);
        }
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

    private static void InputChar(char readKey, ref List<string> files, ref int index, ConsoleColor standardColor)
    {
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
        }
        Console.ForegroundColor = standardColor;
    }

    private static void PrintCharOptions(List<string> files, int index, ConsoleColor standardColor)
    {
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

    private static void MoveFiles(List<string> files, int index)
    {
        var filewithoutPath = files[index].Substring(files[index].LastIndexOf('\\'));
        File.Move(files[index], string.Format(@"import\\{0}", filewithoutPath));
    }

    private static void PrintDisplayOptions(ConsoleColor standardColor, string options)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(options[0]);
        Console.ForegroundColor = standardColor;
        Console.WriteLine(options.Remove(0, 1));
    }
}