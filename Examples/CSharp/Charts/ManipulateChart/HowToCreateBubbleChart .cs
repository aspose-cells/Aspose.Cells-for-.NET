using System;
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;
using System.Drawing;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Charts
{
    public class HowToCreateBubbleChart
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {        
            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Obtaining the reference of the first worksheet by passing its index
            Worksheet worksheet = workbook.Worksheets[0];

            // Fill in data for chart's series
            worksheet.Cells[0, 0].PutValue("Y Values");
            worksheet.Cells[0, 1].PutValue(2);
            worksheet.Cells[0, 2].PutValue(4);
            worksheet.Cells[0, 3].PutValue(6);
            worksheet.Cells[1, 0].PutValue("Bubble Size");
            worksheet.Cells[1, 1].PutValue(2);
            worksheet.Cells[1, 2].PutValue(3);
            worksheet.Cells[1, 3].PutValue(1);
            worksheet.Cells[2, 0].PutValue("X Values");
            worksheet.Cells[2, 1].PutValue(1);
            worksheet.Cells[2, 2].PutValue(2);
            worksheet.Cells[2, 3].PutValue(3);

            // Adding a chart to the worksheet
            int chartIndex = worksheet.Charts.Add(Aspose.Cells.Charts.ChartType.Bubble, 5, 0, 25, 10);

            // Accessing the instance of the newly added chart
            Aspose.Cells.Charts.Chart chart = worksheet.Charts[chartIndex];

            // Adding SeriesCollection (chart data source) to the chart ranging
            chart.NSeries.Add("B1:D1", true);

            // Set bubble sizes
            chart.NSeries[0].BubbleSizes = "B2:D2";

            // Set X axis values
            chart.NSeries[0].XValues = "B3:D3";

            // Set Y axis values
            chart.NSeries[0].Values = "B1:D1";

            // Saving the Excel file
            workbook.Save(outputDir + "outputHowToCreateBubbleChart.xlsx");

            Console.WriteLine("HowToCreateBubbleChart executed successfully.");
        }
    }
}
