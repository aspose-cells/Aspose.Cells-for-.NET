using System;
using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;
using System.Drawing;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Charts
{
    public class HowToCreateLineChart
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[0];

            // Adding sample values to cells
            worksheet.Cells["A1"].PutValue(50);
            worksheet.Cells["A2"].PutValue(100);
            worksheet.Cells["A3"].PutValue(150);
            worksheet.Cells["B1"].PutValue(4);
            worksheet.Cells["B2"].PutValue(20);
            worksheet.Cells["B3"].PutValue(50);

            // Adding a chart to the worksheet
            int chartIndex = worksheet.Charts.Add(Aspose.Cells.Charts.ChartType.Line, 5, 0, 25, 10);

            // Accessing the instance of the newly added chart
            Aspose.Cells.Charts.Chart chart = worksheet.Charts[chartIndex];

            // Adding SeriesCollection (chart data source) to the chart ranging from "A1" cell to "B3"
            chart.NSeries.Add("A1:B3", true);

            // Saving the Excel file
            workbook.Save(outputDir + "outputHowToCreateLineChart.xlsx");

            Console.WriteLine("HowToCreateLineChart executed successfully.");
        }
    }
}
