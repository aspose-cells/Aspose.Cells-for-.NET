using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.CopyRowsColumns
{
    public class CopyingMultipleRows
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create an instance of Workbook class by loading the existing spreadsheet
            Workbook workbook = new Workbook(sourceDir + "sampleCopyingMultipleRows.xlsx");

            // Get the cells collection of worksheet by name Rows
            Cells cells = workbook.Worksheets[0].Cells;

            // Copy the first 3 rows to 7th row
            cells.CopyRows(cells, 0, 6, 3);

            // Save the result on disc
            workbook.Save(outputDir + "outputCopyingMultipleRows.xlsx");

            Console.WriteLine("CopyingMultipleRows executed successfully.");
        }
    }
}
