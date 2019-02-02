using System;
using System.IO;
using Aspose.Cells;
using Aspose.Cells.Charts;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Charts
{
    public class CreateLineWithDataMarkerChart
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            // ExStart:1
            // Instantiate a workbook
            Workbook workbook = new Workbook();

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Set columns title 
            worksheet.Cells[0, 0].Value = "X";
            worksheet.Cells[0, 1].Value = "Y";

            // Random data shall be used for generating the chart
            Random R = new Random();

            // Create random data and save in the cells
            for (int i = 1; i < 21; i++)
            {
                worksheet.Cells[i, 0].Value = i;
                worksheet.Cells[i, 1].Value = 0.8;
            }

            for (int i = 21; i < 41; i++)
            {
                worksheet.Cells[i, 0].Value = i - 20;
                worksheet.Cells[i, 1].Value = 0.9;
            }
            // Add a chart to the worksheet
            int idx = worksheet.Charts.Add(ChartType.LineWithDataMarkers, 1, 3, 20, 20);

            // Access the newly created chart
            Chart chart = worksheet.Charts[idx];

            // Set chart style
            chart.Style = 3;

            // Set autoscaling value to true
            chart.AutoScaling = true;

            // Set foreground color white
            chart.PlotArea.Area.ForegroundColor = Color.White;

            // Set Properties of chart title
            chart.Title.Text = "Sample Chart";

            // Set chart type
            chart.Type = ChartType.LineWithDataMarkers;

            // Set Properties of categoryaxis title
            chart.CategoryAxis.Title.Text = "Units";

            //Set Properties of nseries
            int s2_idx = chart.NSeries.Add("A2: A2", true);
            int s3_idx = chart.NSeries.Add("A22: A22", true);

            // Set IsColorVaried to true for varied points color
            chart.NSeries.IsColorVaried = true;

            // Set properties of background area and series markers
            chart.NSeries[s2_idx].Area.Formatting = FormattingType.Custom;
            chart.NSeries[s2_idx].Marker.Area.ForegroundColor = Color.Yellow;
            chart.NSeries[s2_idx].Marker.Border.IsVisible = false;

            // Set X and Y values of series chart
            chart.NSeries[s2_idx].XValues = "A2: A21";
            chart.NSeries[s2_idx].Values = "B2: B21";

            // Set properties of background area and series markers
            chart.NSeries[s3_idx].Area.Formatting = FormattingType.Custom;
            chart.NSeries[s3_idx].Marker.Area.ForegroundColor = Color.Green;
            chart.NSeries[s3_idx].Marker.Border.IsVisible = false;

            // Set X and Y values of series chart
            chart.NSeries[s3_idx].XValues = "A22: A41";
            chart.NSeries[s3_idx].Values = "B22: B41";

            // Save the workbook
            workbook.Save(outputDir + @"LineWithDataMarkerChart.xlsx", Aspose.Cells.SaveFormat.Xlsx);
            // ExEnd:1
            Console.WriteLine("CreateLineWithDataMarkerChart executed successfully.");
        }
    }
}
