using NameSorterApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorterApp.Implementations
{
    public class FileWriter : IFileWriter
    {
        public void WriteFile(string filePath, List<string> content)
        {
            File.WriteAllLines(filePath, content);
            Console.WriteLine($"Sorted names have been written to {filePath}");
        }
    }
}
