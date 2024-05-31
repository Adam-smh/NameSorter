using NameSorterApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorterApp.Implementations
{
    public class FileReader : IFileReader
    {
        public List<string>? ReadFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllLines(filePath).ToList();
            }
            else
            {
                Console.WriteLine("File does not exist.");
                return null;
            }
        }
    }
}
