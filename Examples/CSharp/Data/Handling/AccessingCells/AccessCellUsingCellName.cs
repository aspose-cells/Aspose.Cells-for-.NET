using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class AccessCellUsingCellName
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        public static void Run()
        {
            Workbook workbook = new Workbook(sourceDir + "sampleAccessCellUsingCellName.xlsx");

            // Using the Sheet 1 in Workbook
            Worksheet worksheet = workbook.Worksheets[0];

            // Accessing a cell using its name
            Cell cell = worksheet.Cells["C6"];

            Console.WriteLine("Cell Name: " + cell.Name + " Value: " + cell.StringValue);

            Console.WriteLine("AccessCellUsingCellName executed successfully.");
        }
    }
}
