using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class RenameNamedRange
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // Open an existing Excel file 
            Workbook workbook = new Workbook(sourceDir + "sampleRenameNamedRange.xlsx");

            // Get the first worksheet
            Worksheet sheet = workbook.Worksheets[0];

            // Get the Cells of the sheet
            Cells cells = sheet.Cells;

            // Get the named range "MyRange"
            Name name = workbook.Worksheets.Names["MyTestRange"];

            // Rename it
            name.Text = "MyNewRange";

            // Save the Excel file
            workbook.Save(outputDir + "outputRenameNamedRange.xlsx");

            Console.WriteLine("RenameNamedRange executed successfully.");
        }
    }
}
