using System.IO;

using Aspose.Cells;
using System;

namespace CSharp.Files.Handling
{
    public class OpeningSpreadsheetMLFiles
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
             // Opening SpreadsheetML Files
            // Instantiate LoadOptions specified by the LoadFormat.
            LoadOptions loadOptions3 = new LoadOptions(LoadFormat.SpreadsheetML);

            // Create a Workbook object and opening the file from its path
            Workbook wbSpreadSheetML = new Workbook(dataDir + "Book3.xml", loadOptions3);
            Console.WriteLine("SpreadSheetML file opened successfully!");
            // ExEnd:1
            }
          }
        }
