using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Pivot;

namespace Aspose.Cells.Examples.CSharp.Articles.PivotTablesAndPivotCharts
{
    public class RemovePivotTable
    {
        public static void Run()
        {
            // ExStart:RemovePivotTableFromWorksheet
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object from source Excel file
            Workbook workbook = new Workbook(dataDir + "source.xlsx");

            // Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access the first pivot table object
            PivotTable pivotTable = worksheet.PivotTables[0];

            // Remove pivot table using pivot table object
            worksheet.PivotTables.Remove(pivotTable);

            // OR you can remove pivot table using pivot table position by uncommenting below line
            //worksheet.PivotTables.RemoveAt(0);

            // Save the workbook
            workbook.Save(dataDir + "output_out_.xlsx");
            // ExEnd:RemovePivotTableFromWorksheet
        }
    }
}
