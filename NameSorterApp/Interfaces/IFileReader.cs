using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorterApp.Interfaces
{
    public interface IFileReader
    {
        List<string>? ReadFile(string filePath);
    }
}
