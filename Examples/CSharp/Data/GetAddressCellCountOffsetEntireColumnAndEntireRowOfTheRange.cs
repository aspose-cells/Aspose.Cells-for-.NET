using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Data
{
    class GetAddressCellCountOffsetEntireColumnAndEntireRowOfTheRange
    {
        public static void Main()
        {
            // Create empty workbook.
            Workbook wb = new Workbook();

            // Access first worksheet.
            Worksheet ws = wb.Worksheets[0];

            // Create range A1:B3.
            Console.WriteLine("Creating Range A1:B3\n");
            Range rng = ws.Cells.CreateRange("A1:B3");

            // Print range address and cell count.
            Console.WriteLine("Range Address: " + rng.Address);
            Console.WriteLine("Cell Count: " + rng.CellCount);

            // Formatting console output.
            Console.WriteLine("----------------------");
            Console.WriteLine("");

            // Create range A1.
            Console.WriteLine("Creating Range A1\n");
            rng = ws.Cells.CreateRange("A1");

            // Print range offset, entire column and entire row.
            Console.WriteLine("Offset: " + rng.GetOffset(2, 2).Address);
            Console.WriteLine("Entire Column: " + rng.EntireColumn.Address);
            Console.WriteLine("Entire Row: " + rng.EntireRow.Address);

            // Formatting console output.
            Console.WriteLine("----------------------");
            Console.WriteLine("");

            Console.WriteLine("GetAddressCellCountOffsetEntireColumnAndEntireRowOfTheRange executed successfully.");
        }

    }
}
