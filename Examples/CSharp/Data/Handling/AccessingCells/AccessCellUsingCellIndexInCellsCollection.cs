using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class AccessCellUsingCellIndexInCellsCollection
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        public static void Run()
        {
            // Open an existing worksheet
            Workbook workbook = new Workbook(sourceDir + "sampleAccessCellUsingCellIndexInCellsCollection.xlsx");

            // Using the Sheet 1 in Workbook
            Worksheet worksheet = workbook.Worksheets[0];

            // Accessing a cell using its row and column.
            Cell cell = worksheet.Cells.GetCell(5, 2);

            Console.WriteLine("Cell Name: " + cell.Name + " Value: " + cell.StringValue);

            Console.WriteLine("AccessCellUsingCellIndexInCellsCollection executed successfully.");
        }
    }
}
