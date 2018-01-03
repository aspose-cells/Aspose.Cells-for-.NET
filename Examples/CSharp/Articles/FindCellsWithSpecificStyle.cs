using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class FindCellsWithSpecificStyle
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            Workbook workbook = new Workbook(sourceDir + "sampleFindCellsWithSpecificStyle.xlsx");

            Worksheet worksheet = workbook.Worksheets[0];

            // Access the style of cell A1
            Style style = worksheet.Cells["A1"].GetStyle();

            // Specify the style for searching
            FindOptions options = new FindOptions();
            options.Style = style;

            Cell nextCell = null;

            do
            {
                // Find the cell that has a style of cell A1
                nextCell = worksheet.Cells.Find(null, nextCell, options);
                if (nextCell == null)
                    break;
                // Change the text of the cell
                nextCell.PutValue("Found");

            } while (true);

            workbook.Save(outputDir + "outputFindCellsWithSpecificStyle.xlsx");

            Console.WriteLine("FindCellsWithSpecificStyle executed successfully.\r\n");
        }
    }
}
