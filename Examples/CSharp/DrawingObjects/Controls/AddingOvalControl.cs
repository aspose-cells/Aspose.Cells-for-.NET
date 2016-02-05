using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;
using System.Drawing;

namespace Aspose.Cells.Examples.DrawingObjects.Controls
{
    public class AddingOvalControl
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiate a new Workbook.
            Workbook excelbook = new Workbook();

            //Add an oval shape.
            Aspose.Cells.Drawing.Oval oval1 = excelbook.Worksheets[0].Shapes.AddOval(2, 0, 2, 0, 130, 160);

            //Set the placement of the oval.
            oval1.Placement = PlacementType.FreeFloating;

            //Set the fill format.
            oval1.FillFormat.ForeColor = Color.PaleGreen;

            //Set the line style.
            oval1.LineFormat.Style = MsoLineStyle.Single;

            //Set the line weight.
            oval1.LineFormat.Weight = 1;

            //Set the color of the oval line.
            oval1.LineFormat.ForeColor = Color.Green;

            //Set the dash style of the oval.
            oval1.LineFormat.DashStyle = MsoLineDashStyle.Solid;

            //Add another oval (circle) shape.
            Aspose.Cells.Drawing.Oval oval2 = excelbook.Worksheets[0].Shapes.AddOval(9, 0, 2, 15, 130, 130);

            //Set the placement of the oval.
            oval2.Placement = PlacementType.FreeFloating;

            //Set the line style.
            oval2.LineFormat.Style = MsoLineStyle.Single;

            //Set the line weight.
            oval2.LineFormat.Weight = 1;

            //Set the color of the oval line.
            oval2.LineFormat.ForeColor = Color.Blue;

            //Set the dash style of the oval.
            oval2.LineFormat.DashStyle = MsoLineDashStyle.Solid;

            //Save the excel file.
            excelbook.Save(dataDir + "book1.out.xls");

        }
    }
}