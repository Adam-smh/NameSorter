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
        //fun used to check if file exists and if true returns list of names
        public List<string>? ReadFile(string filePath)
        {
            //if file extention is invalid return null
            if (string.IsNullOrWhiteSpace(filePath) || !Path.GetExtension(filePath).Equals(".txt", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Invalid file. Please provide a valid .txt file.");
                return null;
            }
            //Checking if file exists
            if (File.Exists(filePath))
            {
                //if file exists, add all names to a list
                return File.ReadAllLines(filePath).ToList();
            }
            else
            {
                return new List<string>();
            }
        }
    }
}
