using Plukliste.Classes.FileHandling;
using System;

namespace Plukliste.Classes.ConsoleHandling.UserInput
{
    internal class End
    {
        public void endInterface(ref List<string> files,ref int index)
        {
            //Move files to import directory
            MoveFiles moveFiles = new MoveFiles();
            moveFiles.MoveFilesToWeb(files, index);
            Console.WriteLine($"Plukseddel {files[index]} afsluttet.");
            files.Remove(files[index]);
            if (index == files.Count) index--;
        }
    }
}
