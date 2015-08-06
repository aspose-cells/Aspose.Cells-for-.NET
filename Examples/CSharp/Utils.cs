using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Aspose.Cells.Examples
{
    class Utils
    {
        public static string GetDataDir(Type t)
        {
            string c = t.FullName;
            c = c.Replace("Aspose.Cells.Examples.", "");
            c = c.Replace('.', Path.DirectorySeparatorChar);
            string p = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Data", c));
            p += Path.DirectorySeparatorChar;
            Console.WriteLine("Using Data Dir {0}", p);
            return p;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("To run an example, Go to 'Project Properties' and set the 'Startup Object'");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
