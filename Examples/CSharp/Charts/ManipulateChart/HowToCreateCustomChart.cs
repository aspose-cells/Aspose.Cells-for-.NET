using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;
using System.Drawing;
using Aspose.Cells.Charts;

namespace CSharp.Charts.ManipulateChart
{
    public class HowToCreateCustomChart
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Adding a new worksheet to the Workbook object
            int sheetIndex = workbook.Worksheets.Add();

            // Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[sheetIndex];

            // Adding a sample value to "A1" cell
            worksheet.Cells["A1"].PutValue(50);

            // Adding a sample value to "A2" cell
            worksheet.Cells["A2"].PutValue(100);

            // Adding a sample value to "A3" cell
            worksheet.Cells["A3"].PutValue(150);

            // Adding a sample value to "A4" cell
            worksheet.Cells["A4"].PutValue(110);

            // Adding a sample value to "B1" cell
            worksheet.Cells["B1"].PutValue(260);

            // Adding a sample value to "B2" cell
            worksheet.Cells["B2"].PutValue(12);

            // Adding a sample value to "B3" cell
            worksheet.Cells["B3"].PutValue(50);

            // Adding a sample value to "B4" cell
            worksheet.Cells["B4"].PutValue(100);

            // Adding a chart to the worksheet
            int chartIndex = worksheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 5, 0, 15, 5);

            // Accessing the instance of the newly added chart
            Aspose.Cells.Charts.Chart chart = worksheet.Charts[chartIndex];

            // Adding NSeries (chart data source) to the chart ranging from "A1" cell to "B4"
            chart.NSeries.Add("A1:B4", true);

            // Setting the chart type of 2nd NSeries to display as line chart
            chart.NSeries[1].Type = Aspose.Cells.Charts.ChartType.Line;
                       
            // Saving the Excel file
            workbook.Save(dataDir + "output.xls");
            // ExEnd:1

        }
    }
}
