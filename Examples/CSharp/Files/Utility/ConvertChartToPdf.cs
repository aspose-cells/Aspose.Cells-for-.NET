using System;
using System.IO;
using Aspose.Cells;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Files.Utility
{
    class ConvertChartToPdf
    {        
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);        
            // Load excel file containing charts
            Workbook workbook = new Workbook( dataDir + "Sample1.xls");

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access first chart inside the worksheet
            Chart chart = worksheet.Charts[0];

            // Save the chart into pdf format
            chart.ToPdf( dataDir + "Output-Chart_out_.pdf");

            // Save the chart into pdf format in stream
            MemoryStream ms = new MemoryStream();
            chart.ToPdf(ms);
            // ExEnd:1
        }
    }
}
