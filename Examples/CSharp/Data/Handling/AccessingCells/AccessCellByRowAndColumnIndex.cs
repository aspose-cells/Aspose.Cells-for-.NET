using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Data.Handling.AccessingCells
{
    public class AccessCellByRowAndColumnIndex
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        public static void Run()
        {
            // Instantiating a Workbook object
            Workbook workbook = new Workbook(sourceDir + "sampleAccessCellByRowAndColumnIndex.xlsx");

            // Using the Sheet 1 in Workbook
            Worksheet worksheet = workbook.Worksheets[0];

            // Accessing a cell using row and column indices
            Cell cell = worksheet.Cells[5, 2];

            Console.WriteLine("Cell Name: " + cell.Name + " Value: " + cell.StringValue);

            Console.WriteLine("AccessCellByRowAndColumnIndex executed successfully.");
        }
    }
}
