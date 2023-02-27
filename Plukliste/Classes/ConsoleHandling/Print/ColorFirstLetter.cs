namespace Plukliste.Classes.ConsoleHandling.Print
{
    internal class ColorFirstLetter
    {
        public void PrintDisplayOptions(ConsoleColor standardColor, string options)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(options[0]);
            Console.ForegroundColor = standardColor;
            Console.WriteLine(options.Remove(0, 1));
        }
    }
}
