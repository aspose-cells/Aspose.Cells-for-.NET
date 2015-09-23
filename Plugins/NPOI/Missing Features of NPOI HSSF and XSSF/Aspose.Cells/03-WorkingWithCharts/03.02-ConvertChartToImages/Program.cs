using System;
using System.Collections.Generic;
using System.Text; using Aspose.Cells;
using Aspose.Cells.Rendering;
using System.Drawing.Imaging;
using Aspose.Cells.Charts;

namespace _03._02_ConvertChartToImages
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Obtaining the reference of the first worksheet
            WorksheetCollection worksheets = workbook.Worksheets;
            Worksheet sheet = worksheets[0];

            // Adding some sample value to cells
            Cells cells = sheet.Cells;
            Cell cell = cells["A1"];
            cell.Value = 50;
            cell = cells["A2"];
            cell.Value = 100;
            cell = cells["A3"];
            cell.Value = 150;
            cell = cells["B1"];
            cell.Value = 4;
            cell = cells["B2"];
            cell.Value = 20;
            cell = cells["B3"];
            cell.Value = 50;

            ChartCollection charts = sheet.Charts;

            // Adding a chart to the worksheet
            int chartIndex = charts.Add(ChartType.Pyramid, 5, 0, 15, 5);
            Chart chart = charts[chartIndex];

            //Save the chart image file.
            chart.ToImage("AsposeChartImage.png", ImageFormat.Png);
        }
    }
}
