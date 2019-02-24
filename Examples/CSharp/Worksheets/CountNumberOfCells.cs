using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Worksheets
{
    class CountNumberOfCells
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Load source Excel file
            Workbook workbook = new Workbook(sourceDir + "BookWithSomeData.xlsx");

            //Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Print number of cell in the Worksheet
            Console.WriteLine("Number of Cells: " + worksheet.Cells.Count);

            // In the number of cells is greater than 2147483647, use CountLarge
            Console.WriteLine("Number of Cells (CountLarge): " + worksheet.Cells.CountLarge);
        }
    }
}
