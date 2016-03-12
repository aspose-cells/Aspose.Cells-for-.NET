using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.Files.Handling
{
    public class OpeningSpreadsheetMLFiles
    {
        public static void Main(string[] args)
        {
            //Exstart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
             // Opening SpreadsheetML Files
            //Instantiate LoadOptions specified by the LoadFormat.
            LoadOptions loadOptions3 = new LoadOptions(LoadFormat.SpreadsheetML);

            //Create a Workbook object and opening the file from its path
            Workbook wbSpreadSheetML = new Workbook(dataDir + "Book3.xml", loadOptions3);
            Console.WriteLine("SpreadSheetML file opened successfully!");
            //ExEnd:1
            }
          }
        }
