using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Pivot;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles.PivotTablesAndPivotCharts
{
    public class GetPivotTableRefreshDate
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        public static void Main()
        {
            // ExStart:1
            // Create workbook object from source excel file
            Workbook workbook = new Workbook(sourceDir + "sourcePivotTable.xlsx");

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access first pivot table inside the worksheet
            PivotTable pivotTable = worksheet.PivotTables[0];

            // Access pivot table refresh by who
            Console.WriteLine("Pivot table refresh by who = " + pivotTable.RefreshedByWho);

            // Access pivot table refresh date
            Console.WriteLine("Pivot table refresh date = " + pivotTable.RefreshDate);
            // ExEnd:1

            Console.WriteLine("GetPivotTableRefreshDate executed successfully.\r\n");
        }
    }
}
