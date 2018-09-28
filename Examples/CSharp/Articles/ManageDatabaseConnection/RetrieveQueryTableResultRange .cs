using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageDatabaseConnection
{
    public class RetrieveQueryTableResultRange
    {
        public static void Main()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Create workbook from source excel file
            Workbook wb = new Workbook(sourceDir + "sampleQueryTXT.xlsx");

            // Display the address(range) of result range of query table
            Console.WriteLine(wb.Worksheets[0].QueryTables[0].ResultRange.Address);

            Console.WriteLine("RetrieveQueryTableResultRange executed successfully.");
        }
    }
}
