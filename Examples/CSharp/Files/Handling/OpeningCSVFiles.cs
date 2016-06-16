using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class OpeningCSVFiles
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

 // Instantiate LoadOptions specified by the LoadFormat.
            LoadOptions loadOptions4 = new LoadOptions(LoadFormat.CSV);

            // Create a Workbook object and opening the file from its path
            Workbook wbCSV = new Workbook(dataDir + "Book_CSV.csv", loadOptions4);
            Console.WriteLine("CSV file opened successfully!");
            // ExEnd:1
            }
          }
        }
            
