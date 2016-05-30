using System;
using System.IO;
using Aspose.Cells;

namespace CSharp.Data.AddOn.NamedRanges
{
    public class IdentifyCellsinNamedRange
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiate a new Workbook.
            Workbook workbook = new Workbook(dataDir + "book1.xls");

            // Getting the specified named range
            Range range = workbook.Worksheets.GetRangeByName("TestRange");

            // Identify range cells.
            Console.WriteLine( "First Row : " + range.FirstRow);
            Console.WriteLine( "First Column : " + range.FirstColumn);
            Console.WriteLine( "Row Count : " + range.RowCount);
            Console.WriteLine( "Column Count : " + range.ColumnCount);
            // ExEnd:1

        }
    }
}
