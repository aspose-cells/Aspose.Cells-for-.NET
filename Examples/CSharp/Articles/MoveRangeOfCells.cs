using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class MoveRangeOfCells
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();
            
            // Open the Excel file
            Workbook workbook = new Workbook(sourceDir + "sampleMoveRangeOfCells.xlsx");

            Cells cells = workbook.Worksheets[0].Cells;

            // Create Cell's area
            CellArea ca = CellArea.CreateCellArea("A1", "C5");
            
            // Move Range
            cells.MoveRange(ca, 7, 5);

            // Save the resultant file
            workbook.Save(outputDir + "outputMoveRangeOfCells.xlsx");

            Console.WriteLine("MoveRangeOfCells executed successfully.");
        }
    }
}