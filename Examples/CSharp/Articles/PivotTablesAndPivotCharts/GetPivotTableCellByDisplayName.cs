using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Pivot;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles.PivotTablesAndPivotCharts
{
    public class GetPivotTableCellByDisplayName
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create workbook object from source excel file
            Workbook workbook = new Workbook(sourceDir + "sampleGetPivotTableCellByDisplayName.xlsx");

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access first pivot table inside the worksheet
            PivotTable pivotTable = worksheet.PivotTables[0];

            // Access cell by display name of 2nd data field of the pivot table
            Cell cell = pivotTable.GetCellByDisplayName(pivotTable.DataFields[0].DisplayName);

            // Access cell style and set its fill color and font color
            Style style = cell.GetStyle();
            style.BackgroundColor = Color.LightGreen;
            style.Font.Color = Color.Black;

            // Set the style of the cell
            pivotTable.Format(cell.Row, cell.Column, style);

            // Save workbook
            workbook.Save(outputDir + "outputGetPivotTableCellByDisplayName.xlsx");

            Console.WriteLine("GetPivotTableCellByDisplayName executed successfully.");
        }
    }
}
