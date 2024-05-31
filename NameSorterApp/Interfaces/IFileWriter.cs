using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorterApp.Interfaces
{
    public interface IFileWriter
    {
        void WriteFile(string filePath, List<string> content);
    }
}
