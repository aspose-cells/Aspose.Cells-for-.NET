using System;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Charts
{
    public class GetChartSubTitleForODSFile
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();
            // Load excel file containing charts
            Workbook workbook = new Workbook(sourceDir + "SampleChart.ods");

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access first chart inside the worksheet
            Chart chart = worksheet.Charts[0];

            Console.WriteLine("Chart Subtitle: " + chart.SubTitle.Text);
            // ExEnd:1

            Console.WriteLine("GetChartSubTitleForODSFile executed successfully.");
        }
    }
}
