using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.CopyRowsColumns
{
    public class CopyingSingleColumn
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiate a new Workbook
            // Open an existing excel file
            Workbook workbook = new Workbook(sourceDir + "sampleCopyingSingleColumn.xlsx");

            // Get the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];
            // Get the Cells collection
            Cells cells = worksheet.Cells;

            //Copy the first column to next 10 columns
            for (int i = 1; i <= 10; i++)
            {
                cells.CopyColumn(cells, 0, i);
            }

            // Save the excel file
            workbook.Save(outputDir + "outputCopyingSingleColumn.xlsx");

            Console.WriteLine("CopyingSingleColumn executed successfully.");
        }
    }
}
