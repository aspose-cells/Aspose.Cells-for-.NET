using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    public class GetEquationTextOfChartTrendLine
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Create workbook object from source Excel file
            Workbook workbook = new Workbook(sourceDir + "sampleGetEquationTextOfChartTrendLine.xlsx");

            // Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access the first chart inside the worksheet
            Chart chart = worksheet.Charts[0];

            // Calculate the Chart first to get the Equation Text of Trendline
            chart.Calculate();

            // Access the Trendline
            Trendline trendLine = chart.NSeries[0].TrendLines[0];

            // Read the Equation Text of Trendline
            Console.WriteLine("Equation Text: " + trendLine.DataLabels.Text);

            Console.WriteLine("GetEquationTextOfChartTrendLine executed successfully.");
        }
    }
}
