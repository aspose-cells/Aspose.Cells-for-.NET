using System;
using System.IO;
using Aspose.Cells;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Charts
{
    public class ChangeTickLabelDirection
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // ExStart:1
            Workbook workbook = new Workbook(sourceDir + "SampleChangeTickLabelDirection.xlsx");

            Worksheet worksheet = workbook.Worksheets[0];

            // Load the chart from source worksheet
            Chart chart = worksheet.Charts[0];

            chart.CategoryAxis.TickLabels.DirectionType = ChartTextDirectionType.Horizontal;

            // Output the file
            workbook.Save(outputDir + "outputChangeChartDataLableDirection.xlsx");
            // ExEnd:1

            Console.WriteLine("ChangeTickLabelDirection executed successfully.");
        }
    }
}
