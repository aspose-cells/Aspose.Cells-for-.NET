using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;
using System.Drawing;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Charts.ManipulateChart
{
    public class ModifyLineChart
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Open the existing file.
            Workbook workbook = new Workbook(dataDir + "Book1.xlsx");

            // Get the designer chart in the first worksheet.
            Aspose.Cells.Charts.Chart chart = workbook.Worksheets[0].Charts[0];

            // Add the third data series to it.
            chart.NSeries.Add("{60, 80, 10}", true);

            // Add another data series (fourth) to it.
            chart.NSeries.Add("{0.3, 0.7, 1.2}", true);

            // Plot the fourth data series on the second axis.
            chart.NSeries[3].PlotOnSecondAxis = true;

            // Change the Border color of the second data series.
            chart.NSeries[1].Border.Color = Color.Green;

            // Change the Border color of the third data series.
            chart.NSeries[2].Border.Color = Color.Red;

            // Make the second value axis visible.
            chart.SecondValueAxis.IsVisible = true;

            // Save the excel file.
            workbook.Save(dataDir + "output.xls");
            // ExEnd:1

        }
    }
}
