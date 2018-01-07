using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class InsertDeleteRows
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Load a template file.
            Workbook workbook = new Workbook(sourceDir + "sampleInsertDeleteRows.xlsx");

            // Get the first worksheet in the book.
            Worksheet sheet = workbook.Worksheets[0];

            // Insert 10 rows at row index 2 (insertion starts at 3rd row)
            sheet.Cells.InsertRows(2, 10);

            // Delete 5 rows now. (18th row - 22th row)
            sheet.Cells.DeleteRows(17, 5);

            // Save the excel file.
            workbook.Save(outputDir + "outputInsertDeleteRows.xlsx");

            Console.WriteLine("InsertDeleteRows executed successfully.");
        }
    }
}
