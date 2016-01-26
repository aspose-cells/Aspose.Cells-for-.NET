using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.Charts.InsertingControlsintoCharts
{
    public class AddingLabelControl
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Create a new Workbook.
            //Open the existing file.
            Workbook workbook = new Workbook(dataDir + "chart.xls");

            //Get the designer chart in the second sheet.
            Worksheet sheet = workbook.Worksheets[1];
            Aspose.Cells.Charts.Chart chart = sheet.Charts[0];

            //Add a new label to the chart.
            Aspose.Cells.Drawing.Label label = chart.Shapes.AddLabelInChart(100, 100, 350, 900);

            //Set the caption of the label.
            label.Text = "A Label In Chart";

            //Set the Placement Type, the way the
            //label is attached to the cells.
            label.Placement = Aspose.Cells.Drawing.PlacementType.FreeFloating;

            //Set the fill color of the label.
            label.FillFormat.ForeColor = Color.Azure;

            //Save the excel file.
            workbook.Save(dataDir + "chart_out.xls");
 
            
        }
    }
}