using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;
using System.Drawing;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Examples.CSharp.Charts.ManipulateChart
{
    public class ModifyPieChart
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
           
            // Open the existing file.
            Workbook workbook = new Workbook(dataDir + "piechart.xls");

            // Get the designer chart in the second sheet.
            Worksheet sheet = workbook.Worksheets[1];
            Aspose.Cells.Charts.Chart chart = sheet.Charts[0];

            // Get the data labels in the data series of the third data point.
            Aspose.Cells.Charts.DataLabels datalabels = chart.NSeries[0].Points[2].DataLabels;

            // Change the text of the label.
            datalabels.Text = "Unided Kingdom, 400K ";

            // Save the excel file.
            workbook.Save(dataDir + "output.xls");
            // ExEnd:1

        }
    }
}
