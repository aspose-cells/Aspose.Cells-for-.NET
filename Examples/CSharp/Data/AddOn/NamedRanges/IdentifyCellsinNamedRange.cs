using System;
using System.IO;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class IdentifyCellsinNamedRange
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        public static void Run()
        {
            // Instantiate a new Workbook.
            Workbook workbook = new Workbook(sourceDir + "sampleIdentifyCellsinNamedRange.xlsx");

            // Getting the specified named range
            Range range = workbook.Worksheets.GetRangeByName("MyRangeThree");

            // Identify range cells.
            Console.WriteLine( "First Row : " + range.FirstRow);
            Console.WriteLine( "First Column : " + range.FirstColumn);
            Console.WriteLine( "Row Count : " + range.RowCount);
            Console.WriteLine( "Column Count : " + range.ColumnCount);

            Console.WriteLine("IdentifyCellsinNamedRange executed successfully.");
        }
    }
}
