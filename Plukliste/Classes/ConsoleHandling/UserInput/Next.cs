using System;

namespace Plukliste.Classes.ConsoleHandling.UserInput
{
    internal class Next
    {
        public void nextInterface(List<string> files,ref int index)
        {
            if (index < files.Count - 1) index++;
        }
    }
}
