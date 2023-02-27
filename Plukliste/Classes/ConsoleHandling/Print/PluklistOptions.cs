namespace Plukliste.Classes.ConsoleHandling.Print
{
    internal class PluklistOptions
    {
        public void PrintPluklisteOptions(List<string> files, int index)
        {
            ColorFirstLetter displayOptions = new ColorFirstLetter();
            var standardColor = Console.ForegroundColor;
            Console.WriteLine("\n\nOptions:");
            displayOptions.PrintDisplayOptions(standardColor, "Quit");
            if (index >= 0)
            {
                displayOptions.PrintDisplayOptions(standardColor, "Afslut plukeseddel");
            }
            if (index > 0)
            {
                displayOptions.PrintDisplayOptions(standardColor, "Forrige plukeseddel");
            }
            if (index < files.Count - 1)
            {
                displayOptions.PrintDisplayOptions(standardColor, "Næste plukeseddel");
            }
            displayOptions.PrintDisplayOptions(standardColor, "Genindlæs plukeseddel");
            displayOptions.PrintDisplayOptions(standardColor, "Print vejledninger");
        }


    }
}
