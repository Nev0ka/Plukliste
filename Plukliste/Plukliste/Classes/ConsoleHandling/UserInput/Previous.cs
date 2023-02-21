using System;

namespace Plukliste.Classes.ConsoleHandling.UserInput
{
    internal class Previous
    {
        public void previousInterface(ref int index)
        {
            if (index > 0) index--;
        }
    }
}
