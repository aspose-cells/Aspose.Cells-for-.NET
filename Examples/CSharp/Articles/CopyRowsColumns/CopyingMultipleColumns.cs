using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.CopyRowsColumns
{
    public class CopyingMultipleColumns
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create an instance of Workbook class by loading the existing spreadsheet
            Workbook workbook = new Workbook(sourceDir + "sampleCopyingMultipleColumns.xlsx");

            // Get the cells collection of worksheet by name Columns
            Cells cells = workbook.Worksheets[0].Cells;

            // Copy the first 3 columns 7th column
            cells.CopyColumns(cells, 0, 6, 3);

            // Save the result on disc
            workbook.Save(outputDir + "outputCopyingMultipleColumns.xlsx");

            Console.WriteLine("CopyingMultipleColumns executed successfully.");
        }
    }
}
