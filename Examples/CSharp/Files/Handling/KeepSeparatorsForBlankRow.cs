using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class KeepSeparatorsForBlankRow
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string filePath = dataDir + "Book1.xlsx";

            // Create a Workbook object and opening the file from its path
            Workbook wb = new Workbook(filePath);

            // Instantiate Text File's Save Options
            TxtSaveOptions options = new TxtSaveOptions();

            // Set KeepSeparatorsForBlankRow to true show separators in blank rows
            options.KeepSeparatorsForBlankRow = true;

            // Save the file with the options
            wb.Save(dataDir + "output.csv", options);
            // ExEnd:1

            Console.WriteLine("KeepSeparatorsForBlankRow executed successfully.\r\n");
        }
    }
}