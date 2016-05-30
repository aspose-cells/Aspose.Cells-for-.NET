using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace CSharp.Charts.InsertingControlsintoCharts
{
    public class AddingPictureToChart
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create a new Workbook.
            // Open the existing file.
            Workbook workbook = new Workbook(dataDir + "chart.xls");

            // Get an image file to the stream.
            FileStream stream = new FileStream(dataDir + "logo.jpg", FileMode.Open, FileAccess.Read);

            // Get the designer chart in the second sheet.
            Worksheet sheet = workbook.Worksheets[0];
            Aspose.Cells.Charts.Chart chart = sheet.Charts[0];

            // Add a new picture to the chart.
            Aspose.Cells.Drawing.Picture pic0 = chart.Shapes.AddPictureInChart(50, 50, stream, 40, 40);

            // Get the lineformat type of the picture.
            Aspose.Cells.Drawing.MsoLineFormat lineformat = pic0.LineFormat;

            // Set the line color.
            lineformat.ForeColor = Color.Red;

            // Set the dash style.
            lineformat.DashStyle = Aspose.Cells.Drawing.MsoLineDashStyle.Solid;

            // Set the line weight.
            lineformat.Weight = 4;

            // Set the line style.
            lineformat.Style = Aspose.Cells.Drawing.MsoLineStyle.ThickThin;

            // Save the excel file.
            workbook.Save(dataDir + "chart.out.xls");
            // ExEnd:1
        
        }
    }
}
