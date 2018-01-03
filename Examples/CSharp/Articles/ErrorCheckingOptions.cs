using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ErrorCheckingOptions
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create a workbook and opening a template spreadsheet
            Workbook workbook = new Workbook(sourceDir + "sampleErrorCheckingOptions.xlsx");

            // Get the first worksheet
            Worksheet sheet = workbook.Worksheets[0];

            // Instantiate the error checking options
            ErrorCheckOptionCollection opts = sheet.ErrorCheckOptions;

            int index = opts.Add();
            ErrorCheckOption opt = opts[index];
            
            // Disable the numbers stored as text option
            opt.SetErrorCheck(ErrorCheckType.TextNumber, false);
            
            // Set the range
            CellArea ca = CellArea.CreateCellArea("A1", "E20");
            opt.AddRange(ca);

            // Save the Excel file
            workbook.Save(outputDir + "outputErrorCheckingOptions.xlsx");

            Console.WriteLine("ErrorCheckingOptions executed successfully.\r\n");           
        }
    }
}
