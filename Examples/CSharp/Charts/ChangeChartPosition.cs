using System.IO;
using Aspose.Cells;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Charts
{
    public class ChangeChartPosition
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Workbook workbook = new Workbook(dataDir + "chart.xls");

            Worksheet worksheet = workbook.Worksheets[1];

            // Load the chart from source worksheet
            Chart chart = worksheet.Charts[0];

            // Resize the chart
            chart.ChartObject.Width = 400;
            chart.ChartObject.Height = 300;

            // Reposition the chart
            chart.ChartObject.X = 250;
            chart.ChartObject.Y = 150;

            // Output the file
            workbook.Save(dataDir + "chart.out.xls");
            // ExEnd:1

        }
    }
}
