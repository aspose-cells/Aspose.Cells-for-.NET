using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Data
{
    class GetAllHiddenRowsIndicesAfterRefreshingAutoFilter
    { 
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        public static void Main()
        {
            //Load the sample Excel file
            Workbook wb = new Workbook(sourceDir + "sampleGetAllHiddenRowsIndicesAfterRefreshingAutoFilter.xlsx");

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Apply autofilter
            ws.AutoFilter.AddFilter(0, "Orange");

            //True means, it will refresh autofilter and return hidden rows.
            //False means, it will not refresh autofilter but return same hidden rows.
            int[] rowIndices = ws.AutoFilter.Refresh(true);

            Console.WriteLine("Printing Rows Indices, Cell Names and Values Hidden By AutoFilter.");
            Console.WriteLine("--------------------------");

            for (int i = 0; i < rowIndices.Length; i++)
            {
                int r = rowIndices[i];
                Cell cell = ws.Cells[r, 0];
                Console.WriteLine(r + "\t" + cell.Name + "\t" + cell.StringValue);
            }

            Console.WriteLine("GetAllHiddenRowsIndicesAfterRefreshingAutoFilter executed successfully.");
        }
    }
}
