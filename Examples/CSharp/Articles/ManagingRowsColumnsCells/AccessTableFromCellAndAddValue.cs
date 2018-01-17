using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Tables;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingRowsColumnsCells
{
    public class AccessTableFromCellAndAddValue
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();
            
            // Create workbook from source Excel file
            Workbook workbook = new Workbook(sourceDir + "sampleAccessTableFromCellAndAddValue.xlsx");

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access cell D5 which lies inside the table
            Cell cell = worksheet.Cells["D5"];

            // Put value inside the cell D5
            cell.PutValue("D5 Data");

            // Access the Table from this cell
            ListObject table = cell.GetTable();

            // Add some value using Row and Column Offset
            table.PutCellValue(2, 2, "Offset [2,2]");

            // Save the workbook
            workbook.Save(outputDir + "outputAccessTableFromCellAndAddValue.xlsx");

            Console.WriteLine("AccessTableFromCellAndAddValue executed successfully.");
        }
    }
}
