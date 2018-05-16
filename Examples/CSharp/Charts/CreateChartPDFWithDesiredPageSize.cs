using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Charts
{
    class CreateChartPDFWithDesiredPageSize
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            //Load sample Excel file containing the chart.
            Workbook wb = new Workbook(sourceDir + "sampleCreateChartPDFWithDesiredPageSize.xlsx");

            //Access first worksheet.
            Worksheet ws = wb.Worksheets[0];

            //Access first chart inside the worksheet.
            Chart ch = ws.Charts[0];

            //Create chart pdf with desired page size.
            ch.ToPdf(outputDir + "outputCreateChartPDFWithDesiredPageSize.pdf", 7, 7, PageLayoutAlignmentType.Center, PageLayoutAlignmentType.Center);

            Console.WriteLine("CreateChartPDFWithDesiredPageSize executed successfully.");
        }
    }
}
