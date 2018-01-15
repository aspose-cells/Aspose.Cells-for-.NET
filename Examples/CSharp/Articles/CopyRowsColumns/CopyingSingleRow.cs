using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.CopyRowsColumns
{
    public class CopyingSingleRow
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiate a new workbook
            // Open an existing excel file
            Workbook workbook = new Workbook(sourceDir + "sampleCopyingSingleRow.xlsx");

            // Get the first worksheet cells
            Cells cells = workbook.Worksheets[0].Cells;

            //Copy the first row to next 10 rows
            for (int i = 1; i <= 10; i++)
            {
                cells.CopyRow(cells, 0, i);
            }

            // Save the excel file
            workbook.Save(outputDir + "outputCopyingSingleRow.xlsx");

            Console.WriteLine("CopyingSingleRow executed successfully.");
        }
    }
}
