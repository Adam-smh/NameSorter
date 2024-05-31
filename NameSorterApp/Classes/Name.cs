using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorterApp.Classes
{
    public class Name
    {
        public string FirstName { get; }
        public string MidName1 { get; }
        public string MidName2 { get; }
        public string LastName { get; }
        public string FullName { get; }

        public Name(string fullName)
        {
            FullName = fullName;
            var parts = fullName.Split(' ');

            if (parts.Length < 2 || parts.Length > 4)
            {
                throw new ArgumentException("Each name must have both a first and last name with room for middle names.");
            }

            LastName = parts[^1];
            FirstName = parts.Length > 1 ? parts[0] : string.Empty;
            MidName1 = parts.Length > 2 ? parts[1] : string.Empty;
            MidName2 = parts.Length > 3 ? parts[2] : string.Empty;
        }
    }
}
