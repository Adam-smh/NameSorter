using NameSorterApp.Classes;
using NameSorterApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorterApp.Implementations
{
    public class NameSorter : INameSorter
    {
        //fun uses list of names to create new list sorting names in order of last name, first name then middle names
        public List<string> SortNames(List<string> names)
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
    }
}
