using System;
using Aspose.Cells;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    class ChartLegendEntry
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Open the template file.
            Workbook workbook = new Workbook(dataDir + "Sample.xlsx");

            // Access the first worksheet
            Worksheet sheet = workbook.Worksheets[0];

            // Access the first chart inside the sheet
            Chart chart = sheet.Charts[0];

            // Set text of second legend entry fill to none
            chart.Legend.LegendEntries[1].IsTextNoFill = true;

            // Save the workbook in xlsx format
            workbook.Save(dataDir + "ChartLegendEntry_out.xlsx", SaveFormat.Xlsx);
            // ExEnd:1
        }
    }
}
