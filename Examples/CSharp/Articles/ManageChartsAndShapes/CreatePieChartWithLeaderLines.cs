using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Charts;
using Aspose.Cells.Rendering;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    public class CreatePieChartWithLeaderLines
    {
        public static void Run()
        {
            // ExStart:CreateWorkbook
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create an instance of Workbook in XLSX format
            Workbook workbook = new Workbook(FileFormatType.Xlsx);

            // Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Add two columns of data
            worksheet.Cells["A1"].PutValue("Retail");
            worksheet.Cells["A2"].PutValue("Services");
            worksheet.Cells["A3"].PutValue("Info & Communication");
            worksheet.Cells["A4"].PutValue("Transport Equip");
            worksheet.Cells["A5"].PutValue("Construction");
            worksheet.Cells["A6"].PutValue("Other Products");
            worksheet.Cells["A7"].PutValue("Wholesale");
            worksheet.Cells["A8"].PutValue("Land Transport");
            worksheet.Cells["A9"].PutValue("Air Transport");
            worksheet.Cells["A10"].PutValue("Electric Appliances");
            worksheet.Cells["A11"].PutValue("Securities");
            worksheet.Cells["A12"].PutValue("Textiles & Apparel");
            worksheet.Cells["A13"].PutValue("Machinery");
            worksheet.Cells["A14"].PutValue("Metal Products");
            worksheet.Cells["A15"].PutValue("Cash");
            worksheet.Cells["A16"].PutValue("Banks");

            worksheet.Cells["B1"].PutValue(10.4);
            worksheet.Cells["B2"].PutValue(5.2);
            worksheet.Cells["B3"].PutValue(6.4);
            worksheet.Cells["B4"].PutValue(10.4);
            worksheet.Cells["B5"].PutValue(7.9);
            worksheet.Cells["B6"].PutValue(4.1);
            worksheet.Cells["B7"].PutValue(3.5);
            worksheet.Cells["B8"].PutValue(5.7);
            worksheet.Cells["B9"].PutValue(3);
            worksheet.Cells["B10"].PutValue(14.7);
            worksheet.Cells["B11"].PutValue(3.6);
            worksheet.Cells["B12"].PutValue(2.8);
            worksheet.Cells["B13"].PutValue(7.8);
            worksheet.Cells["B14"].PutValue(2.4);
            worksheet.Cells["B15"].PutValue(1.8);
            worksheet.Cells["B16"].PutValue(10.1);

            // Create a pie chart and add it to the collection of charts
            int id = worksheet.Charts.Add(ChartType.Pie, 3, 3, 23, 13);

            // Access newly created Chart instance
            Chart chart = worksheet.Charts[id];

            // Set series data range
            chart.NSeries.Add("B1:B16", true);

            // Set category data range
            chart.NSeries.CategoryData = "A1:A16";

            // Turn off legend
            chart.ShowLegend = false;

            // Access data labels
            DataLabels dataLabels = chart.NSeries[0].DataLabels;

            // Turn on category names
            dataLabels.ShowCategoryName = true;

            // Turn on percentage format
            dataLabels.ShowPercentage = true;

            // Set position
            dataLabels.Position = LabelPositionType.OutsideEnd;

            // Set separator
            dataLabels.Separator = DataLablesSeparatorType.Comma;
            // ExEnd:CreateWorkbook

            // ExStart:TurnOnLeaderLines
            // Turn on leader lines
            chart.NSeries[0].HasLeaderLines = true;

            // Calculete chart
            chart.Calculate();

            // You need to move DataLabels a little leftward or rightward depending on their position to show leader lines
            int DELTA = 100;
            for (int i = 0; i < chart.NSeries[0].Points.Count; i++)
            {
                int X = chart.NSeries[0].Points[i].DataLabels.X;
                // If it is greater than 2000, then move the X position a little right otherwise move the X position a little left
                if (X > 2000)
                    chart.NSeries[0].Points[i].DataLabels.X = X + DELTA;
                else
                    chart.NSeries[0].Points[i].DataLabels.X = X - DELTA;
            }
            // ExEnd:TurnOnLeaderLines

            // ExStart:SaveChartInImageAndWorkbookInXLSX
            // In order to save the chart image, create an instance of ImageOrPrintOptions
            ImageOrPrintOptions anOption = new ImageOrPrintOptions();

            // Set image format
            anOption.ImageType = Drawing.ImageType.Png;

            // Set resolution
            anOption.HorizontalResolution = 200;
            anOption.VerticalResolution = 200;

            // Render chart to image
            chart.ToImage(dataDir + "output_out.png", anOption);

            // Save the workbook to see chart inside the Excel
            workbook.Save(dataDir + "output_out.xlsx");
            // ExEnd:SaveChartInImageAndWorkbookInXLSX
        }
    }
}
