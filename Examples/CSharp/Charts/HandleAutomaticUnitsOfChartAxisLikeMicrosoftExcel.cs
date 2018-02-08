using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aspose.Cells;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Charts
{
    class HandleAutomaticUnitsOfChartAxisLikeMicrosoftExcel
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Load the sample Excel file
            Workbook wb = new Workbook(sourceDir + "sampleHandleAutomaticUnitsOfChartAxisLikeMicrosoftExcel.xlsx");

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Access first chart
            Chart ch = ws.Charts[0];

            //Render chart to pdf
            ch.ToPdf(outputDir + "outputHandleAutomaticUnitsOfChartAxisLikeMicrosoftExcel.pdf");

            Console.WriteLine("HandleAutomaticUnitsOfChartAxisLikeMicrosoftExcel executed successfully.");
        }
    }
}
