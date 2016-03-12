using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.Files.Handling
{
    public class OpeningFiles
    {
        public static void Main(string[] args)
        {
            //Exstart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            
             // Opening Tab Delimited Files
            //Instantiate LoadOptions specified by the LoadFormat.
            LoadOptions loadOptions5 = new LoadOptions(LoadFormat.TabDelimited);

            //Create a Workbook object and opening the file from its path
            Workbook wbTabDelimited = new Workbook(dataDir + "Book1TabDelimited.txt", loadOptions5);
            Console.WriteLine("Tab delimited file opened successfully!");
            //ExEnd:1
            }
          }
        }
            
