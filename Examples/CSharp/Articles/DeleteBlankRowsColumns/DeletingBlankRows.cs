using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.DeleteBlankRowsColumns
{
    public class DeletingBlankRows
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open an existing excel file.
            Workbook wb = new Workbook(sourceDir + "sampleDeletingBlankRows.xlsx");

            // Create a Worksheets object with reference to
            // The sheets of the Workbook.
            WorksheetCollection sheets = wb.Worksheets;

            // Get first Worksheet from WorksheetCollection
            Worksheet sheet = sheets[0];

            // Delete the Blank Rows from the worksheet
            sheet.Cells.DeleteBlankRows();

            // Save the excel file.
            wb.Save(outputDir + "outputDeletingBlankRows.xlsx");

            Console.WriteLine("DeletingBlankRows executed successfully.");
        }
    }
}
