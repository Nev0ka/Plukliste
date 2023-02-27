using System;

namespace Plukliste.Classes.ConsoleHandling.UserInput
{
    internal class Refresh
    {
        public void refreshInterface(ref List<string> files,ref int index)
        {
            files = Directory.EnumerateFiles("export").ToList();
            index = -1;
            Console.WriteLine("Pluklister genindlæst");
        }
    }
}
