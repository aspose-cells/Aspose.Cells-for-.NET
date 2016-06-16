using System;
using Aspose.Cells;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Files.Utility
{
    class ConvertChartToPdf
    {
        // ExStart:1
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string inputPath = dataDir + "Sample1.xls";
            string outputPath = dataDir + "Output-Chart.out.pdf";


            // Load excel file containing charts
            Workbook workbook = new Workbook(inputPath);

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access first chart inside the worksheet
            Chart chart = worksheet.Charts[0];

            // Save the chart into pdf format
            chart.ToPdf(outputPath);

            Console.WriteLine("File saved {0}", outputPath);
            // ExEnd:1
        }
    }
}
