using NameSorter;
using NameSorter.NameSorterApp;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace NameSorterApp
{
    public class SortingNameP
    {
        public static void Main(string[] args)
        {
            //ensuring file is provided
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the input file path as a command-line argument.");
                return;
            }
            //file of unsorted names that must be sorted
            string inputFilePath = args[0];
            //file of sorted names produced
            string? outputFilePath = "";
            // Push all names from file into list of names
            List<string> names = new List<string>();


            //Checking if file exists
            if (File.Exists(inputFilePath))
            {
                //if file exists, add all names to a list
                names = File.ReadAllLines(inputFilePath).ToList();
            }
            else
            {
                Console.WriteLine($"The file {inputFilePath} does not exist.");
                return;
            }

            //using new list, a new list is made sorting names in order of last name, first name then middle names
            var sortedNames = names
                    .Select(name => new Name(name))
                    .OrderBy(n => n.LastName)
                    .ThenBy(n => n.FirstName)
                    .ThenBy(n => n.MidName1)
                    .ThenBy(n => n.MidName2)
                    .Select(n => n.FullName)
                    .ToList();

            //ensuring that the output file has a valid name that the user provides
            while (string.IsNullOrEmpty(outputFilePath))
            {
                //User provides file name
                Console.WriteLine("Please enter a name for the list of sorted names file");
                outputFilePath = Console.ReadLine()?.Trim();

                //ensuring name is not null without spaces
                if (string.IsNullOrWhiteSpace(outputFilePath))
                {
                    Console.WriteLine("Please enter valid file name");
                    outputFilePath = null;
                }
                else
                {
                    //ensuring the file type is specified as .txt
                    if (!outputFilePath.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        outputFilePath += ".txt";
                    }
                }
            }


            // Write sorted names to output file
            File.WriteAllLines(outputFilePath, sortedNames);
            Console.WriteLine($"Sorted names have been written to {outputFilePath}");
        }
    }
}