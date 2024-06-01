using NameSorterApp;
using NameSorterApp.Interfaces;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace NameSorterApp
{
    public class SortingNameP
    {

        private readonly IFileReader? _fileReader;
        private readonly INameSorter? _nameSorter;
        private readonly IFileWriter? _fileWriter;

        public SortingNameP(IFileReader? fileReader, INameSorter? nameSorter, IFileWriter? fileWriter)
        {
            _fileReader = fileReader;
            _nameSorter = nameSorter;
            _fileWriter = fileWriter;
        }

        public List<string>? Run(string inputFilePath, string? outputFilePath = null)
        {
            if (string.IsNullOrWhiteSpace(inputFilePath) || !Path.GetExtension(inputFilePath).Equals(".txt", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Invalid file. Please provide a valid .txt file.");
                return null;
            }

            var names = _fileReader?.ReadFile(inputFilePath);

            if (names == null || names.Count == 0)
            {
                //file does not exist, end
                Console.WriteLine("File does not exist.");
                return null;
            }

            var sortedNames = _nameSorter?.SortNames(names);

            if(sortedNames != null)
            {

                foreach (var name in sortedNames)
                {
                    Console.WriteLine(name);
                }

                while (string.IsNullOrWhiteSpace(outputFilePath))
                {
                    Console.WriteLine("Please enter a name for the sorted names file:");
                    outputFilePath = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(outputFilePath))
                    {
                        Console.WriteLine("Invalid file name. Please try again.");
                        outputFilePath = null;
                    }
                    else if (!outputFilePath.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        outputFilePath += ".txt";
                    }
                }

                _fileWriter?.WriteFile(outputFilePath, sortedNames);
            }
            else
            {
                return names;
            }
            return sortedNames;
        }
    }
}