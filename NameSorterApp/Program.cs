using NameSorterApp.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorterApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the input file path as a command-line argument.");
                return;
            }

            var fileReader = new FileReader();
            var nameSorter = new NameSorter();
            var fileWriter = new FileWriter();

            var sortingNameP = new SortingNameP(fileReader, nameSorter, fileWriter);
            sortingNameP.Run(args[0]);
        }
    }
}
