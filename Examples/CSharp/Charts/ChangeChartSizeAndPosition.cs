using System;
using System.IO;
using Aspose.Cells;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Charts
{
    public class ChangeChartSizeAndPosition
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            Workbook workbook = new Workbook(sourceDir + "sampleChangeChartSizeAndPosition.xlsx");

            Worksheet worksheet = workbook.Worksheets[0];

            // Load the chart from source worksheet
            Chart chart = worksheet.Charts[0];

            // Resize the chart
            chart.ChartObject.Width = 400;
            chart.ChartObject.Height = 300;

            // Reposition the chart
            chart.ChartObject.X = 250;
            chart.ChartObject.Y = 150;

            // Output the file
            workbook.Save(outputDir + "outputChangeChartSizeAndPosition.xlsx");

            Console.WriteLine("ChangeChartSizeAndPosition executed successfully.");
        }
    }
}
