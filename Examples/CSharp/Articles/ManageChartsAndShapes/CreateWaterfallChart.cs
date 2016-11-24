using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Charts;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    public class CreateWaterfallChart
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create an instance of Workbook
            Workbook workbook = new Workbook();

            // Retrieve the first Worksheet in Workbook
            Worksheet worksheet = workbook.Worksheets[0];

            // Retrieve the Cells of the first Worksheet
            var cells = worksheet.Cells;

            // Input some data which chart will use as source
            cells["A1"].PutValue("Previous Year");
            cells["A2"].PutValue("January");
            cells["A3"].PutValue("March");
            cells["A4"].PutValue("August");
            cells["A5"].PutValue("October");
            cells["A6"].PutValue("Current Year");

            cells["B1"].PutValue(8.5);
            cells["B2"].PutValue(1.5);
            cells["B3"].PutValue(7.5);
            cells["B4"].PutValue(7.5);
            cells["B5"].PutValue(8.5);
            cells["B6"].PutValue(3.5);

            cells["C1"].PutValue(1.5);
            cells["C2"].PutValue(4.5);
            cells["C3"].PutValue(3.5);
            cells["C4"].PutValue(9.5);
            cells["C5"].PutValue(7.5);
            cells["C6"].PutValue(9.5);

            // Add a Chart of type Line in same worksheet as of data
            int idx = worksheet.Charts.Add(ChartType.Line, 4, 4, 25, 13);
            // Retrieve the Chart object
            Chart chart = worksheet.Charts[idx];

            // Add Series
            chart.NSeries.Add("$B$1:$C$6", true);

            // Add Category Data
            chart.NSeries.CategoryData = "$A$1:$A$6";

            // Series has Up Down Bars
            chart.NSeries[0].HasUpDownBars = true;

            // Set the colors of Up and Down Bars
            chart.NSeries[0].UpBars.Area.ForegroundColor = Color.Green;
            chart.NSeries[0].DownBars.Area.ForegroundColor = Color.Red;

            // Make both Series Lines invisible
            chart.NSeries[0].Border.IsVisible = false;
            chart.NSeries[1].Border.IsVisible = false;

            // Set the Plot Area Formatting Automatic
            chart.PlotArea.Area.Formatting = FormattingType.Automatic;

            // Delete the Legend
            chart.Legend.LegendEntries[0].IsDeleted = true;
            chart.Legend.LegendEntries[1].IsDeleted = true;

            // Save the workbook
            workbook.Save(dataDir + "output_out.xlsx");
            // ExEnd:1
        }
    }
}
