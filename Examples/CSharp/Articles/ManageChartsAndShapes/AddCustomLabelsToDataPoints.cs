using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    public class AddCustomLabelsToDataPoints
    {
        public static void Run()
        {
            // ExStart:AddCustomLabelsToDataPointsInTheSeriesOfChart
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Workbook workbook = new Workbook(FileFormatType.Xlsx);
            Worksheet sheet = workbook.Worksheets[0];

            // Put data
            sheet.Cells[0, 0].PutValue(1);
            sheet.Cells[0, 1].PutValue(2);
            sheet.Cells[0, 2].PutValue(3);

            sheet.Cells[1, 0].PutValue(4);
            sheet.Cells[1, 1].PutValue(5);
            sheet.Cells[1, 2].PutValue(6);

            sheet.Cells[2, 0].PutValue(7);
            sheet.Cells[2, 1].PutValue(8);
            sheet.Cells[2, 2].PutValue(9);

            // Generate the chart
            int chartIndex = sheet.Charts.Add(Aspose.Cells.Charts.ChartType.ScatterConnectedByLinesWithDataMarker, 5, 1, 24, 10);
            Chart chart = sheet.Charts[chartIndex];

            chart.Title.Text = "Test";
            chart.CategoryAxis.Title.Text = "X-Axis";
            chart.ValueAxis.Title.Text = "Y-Axis";

            chart.NSeries.CategoryData = "A1:C1";

            // Insert series
            chart.NSeries.Add("A2:C2", false);

            Series series = chart.NSeries[0];

            int pointCount = series.Points.Count;
            for (int i = 0; i < pointCount; i++)
            {
                ChartPoint pointIndex = series.Points[i];

                pointIndex.DataLabels.Text = "Series 1" + "\n" + "Point " + i;
            }

            // Insert series
            chart.NSeries.Add("A3:C3", false);

            series = chart.NSeries[1];

            pointCount = series.Points.Count;
            for (int i = 0; i < pointCount; i++)
            {
                ChartPoint pointIndex = series.Points[i];

                pointIndex.DataLabels.Text = "Series 2" + "\n" + "Point " + i;
            }

            workbook.Save(dataDir + "output_out_.xlsx", Aspose.Cells.SaveFormat.Xlsx);
            // ExEnd:AddCustomLabelsToDataPointsInTheSeriesOfChart
        }
    }
}
