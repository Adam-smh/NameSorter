using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorterApp.Interfaces
{
    public interface INameSorter
    {
        List<string> SortNames(List<string> names);
    }
}
