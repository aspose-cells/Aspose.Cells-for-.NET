using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Pivot;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles.PivotTablesAndPivotCharts
{
    public class GetCellByDisplayName
    {
        public static void Run()
        {
            // ExStart:GetCellObjectByDisplayName
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object from source excel file
            Workbook workbook = new Workbook(dataDir + "source.xlsx");

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access first pivot table inside the worksheet
            PivotTable pivotTable = worksheet.PivotTables[0];

            // Access cell by display name of 2nd data field of the pivot table
            Cell cell = pivotTable.GetCellByDisplayName(pivotTable.DataFields[0].DisplayName);

            // Access cell style and set its fill color and font color
            Style style = cell.GetStyle();
            style.ForegroundColor = Color.LightBlue;
            style.Font.Color = Color.Black;

            // Set the style of the cell
            pivotTable.Format(cell.Row, cell.Column, style);

            // Save workbook
            workbook.Save(dataDir + "output_out_.xlsx");
            // ExEnd:GetCellObjectByDisplayName
        }
    }
}
