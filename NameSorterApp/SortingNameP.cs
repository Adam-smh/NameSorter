using NameSorter;
using NameSorter.NameSorterApp;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace NameSorterApp
{
    public class SortingNameP
    {

        //fun used to check if file exists and if true returns list of names
        public static List<string>? readFile(string filePath)
        {
            //Checking if file exists
            if (File.Exists(filePath))
            {
                //if file exists, add all names to a list
                return File.ReadAllLines(filePath).ToList();
            }
            else
            {
                //file does not exist, end
                Console.WriteLine("file does not exist");
                return null;
            }
        }

        //fun uses list of names to create new list sorting names in order of last name, first name then middle names
        public static List<string> SortNames(List<string> names)
        {
            return names
                .Select(name => new Name(name))
                .OrderBy(n => n.LastName)
                .ThenBy(n => n.FirstName)
                .ThenBy(n => n.MidName1)
                .ThenBy(n => n.MidName2)
                .Select(n => n.FullName)
                .ToList();
        }

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

             List<string>? names;
             List<string>? sortedNames;

             //Checking file extension
             string fileExt = Path.GetExtension(inputFilePath);
             if (fileExt == ".txt")
             {
                 // Push all names from file into list of names
                 names = readFile(inputFilePath);

            }
            else
            {
                //if file ext is not .txt, display msg
                Console.WriteLine("file is invalid, please only insert .txt files");
                return;
            }


             if (names != null) {

                if (names.Count != 0)
                {
                    //using new list, a new list is made sorting names in order of last name, first name then middle names
                    sortedNames = SortNames(names);

                    //printing name in order in console
                    foreach (var name in sortedNames)
                    {
                        Console.WriteLine(name);
                    }
                }
                else
                {
                    Console.WriteLine("empty list cannot be processed");
                    return;
                }

            }
            else
            {
                return;
            }

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