using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.DeleteBlankRowsColumns
{
    public class DeletingBlankColumns
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open an existing excel file.
            Workbook wb = new Workbook(sourceDir + "sampleDeletingBlankColumns.xlsx");

            // Create a Worksheets object with reference to
            // The sheets of the Workbook.
            WorksheetCollection sheets = wb.Worksheets;

            // Get first Worksheet from WorksheetCollection
            Worksheet sheet = sheets[0];

            // Delete the Blank Columns from the worksheet
            sheet.Cells.DeleteBlankColumns();

            // Save the excel file.
            wb.Save(outputDir + "outputDeletingBlankColumns.xlsx");

            Console.WriteLine("DeletingBlankColumns executed successfully.");
        }
    }
}
