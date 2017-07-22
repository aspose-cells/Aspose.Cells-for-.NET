using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GridDesktop.Examples
{
    public class Utils
    {
        public static string GetDataDir(Type t)
        {
            string c = t.FullName;
            c = c.Replace("GridDesktop.Examples.", "");
            c = c.Replace('.', Path.DirectorySeparatorChar);

            string retDir = null;
            var parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            string startDirectory = null;
            if (parent != null)
            {
                var directoryInfo = parent.Parent;
                if (directoryInfo != null)
                {
                    startDirectory = directoryInfo.FullName;
                }

                retDir = Path.Combine(Path.GetFullPath(Path.Combine(startDirectory, @"..\")), "Data\\") + c;

                if (!Directory.Exists(retDir))
                {
                    Directory.CreateDirectory(retDir);
                }
            }
            else
            {
                retDir = parent.FullName;
            }
            return retDir + "\\";
        }

        public static string Get_SourceDirectory()
        {
            return Path.GetFullPath("..\\..\\..\\..\\Data\\01_SourceDirectory\\");
        }
    }
}
