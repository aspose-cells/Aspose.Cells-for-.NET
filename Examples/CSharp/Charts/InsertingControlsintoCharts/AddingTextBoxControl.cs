using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.Charts.InsertingControlsintoCharts
{
    public class AddingTextBoxControl
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Create a new Workbook.
            //Open the existing file.
            Workbook workbook = new Workbook(dataDir + "chart.xls");
             
            //Get the designer chart in the second sheet.
            Worksheet sheet = workbook.Worksheets[1];
            Aspose.Cells.Charts.Chart chart = sheet.Charts[0];

            //Add a new textbox to the chart.
            Aspose.Cells.Drawing.TextBox textbox0 = chart.Shapes.AddTextBoxInChart(100, 1100, 350, 2550);

            //Fill the text.
            textbox0.Text = "Sales By Region";

            //Get the textbox text frame.
            Aspose.Cells.Drawing.MsoTextFrame textframe0 = textbox0.TextFrame;

            //Set the textbox to adjust it according to its contents.
            textframe0.AutoSize = true;

            //Set the font color.
            textbox0.Font.Color = Color.Maroon;

            //Set the font to bold.
            textbox0.Font.IsBold = true;

            //Set the font size.
            textbox0.Font.Size = 14;

            //Set font attribute to italic.
            textbox0.Font.IsItalic = true;

            //Get the filformat of the textbox.
            Aspose.Cells.Drawing.MsoFillFormat fillformat = textbox0.FillFormat;

            //Set the fillcolor.
            fillformat.ForeColor = Color.Silver;

            //Get the lineformat type of the textbox.
            Aspose.Cells.Drawing.MsoLineFormat lineformat = textbox0.LineFormat;

            //Set the line style.
            lineformat.Style = Aspose.Cells.Drawing.MsoLineStyle.ThinThick;

            //Set the line weight.
            lineformat.Weight = 2;

            //Set the dash style to solid.
            lineformat.DashStyle = Aspose.Cells.Drawing.MsoLineDashStyle.Solid;

            //Save the excel file.
            workbook.Save(dataDir + "chart.out.xls");
            //ExEnd:1

        }
    }
}
