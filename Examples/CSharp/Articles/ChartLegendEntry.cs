using System;
using Aspose.Cells;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    class ChartLegendEntry
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open the template file.
            Workbook workbook = new Workbook(sourceDir + "sampleChartLegendEntry.xlsx");

            // Access the first worksheet
            Worksheet sheet = workbook.Worksheets[0];

            // Access the first chart inside the sheet
            Chart chart = sheet.Charts[0];

            // Set text of second legend entry fill to none
            chart.Legend.LegendEntries[1].IsTextNoFill = true;

            // Save the workbook in xlsx format
            workbook.Save(outputDir + "outputChartLegendEntry.xlsx", SaveFormat.Xlsx);

            Console.WriteLine("ChartLegendEntry executed successfully.");
        }
    }
}
