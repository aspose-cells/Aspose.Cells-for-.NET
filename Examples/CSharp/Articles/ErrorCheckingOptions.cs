using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ErrorCheckingOptions
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create a workbook and opening a template spreadsheet
            Workbook workbook = new Workbook(dataDir+ "Book1.xlsx");

            // Get the first worksheet
            Worksheet sheet = workbook.Worksheets[0];
            // Instantiate the error checking options
            ErrorCheckOptionCollection opts = sheet.ErrorCheckOptions;

            int index = opts.Add();
            ErrorCheckOption opt = opts[index];
            // Disable the numbers stored as text option
            opt.SetErrorCheck(ErrorCheckType.TextNumber, false);
            // Set the range
            opt.AddRange(CellArea.CreateCellArea(0, 0, 1000, 50));

            dataDir = dataDir + "out_test.out.xlsx";
            // Save the Excel file
            workbook.Save(dataDir);
            // ExEnd:1
            Console.WriteLine("\nProcess completed successfully.\nFile saved at " + dataDir); 
            
        }
    }
}
