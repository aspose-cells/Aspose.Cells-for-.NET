using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;
using System.Drawing;

namespace Aspose.Cells.Examples.DrawingObjects.Controls
{
    public class AddingArcControl
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

            //Add an arc shape.
            Aspose.Cells.Drawing.ArcShape arc1 = excelbook.Worksheets[0].Shapes.AddArc(2, 0, 2, 0, 130, 130);

            //Set the placement of the arc.
            arc1.Placement = PlacementType.FreeFloating;

            //Set the fill format.
            arc1.FillFormat.ForeColor = Color.Blue;

            //Set the line style.
            arc1.LineFormat.Style = MsoLineStyle.Single;

            //Set the line weight.
            arc1.LineFormat.Weight = 1;

            //Set the color of the arc line.
            arc1.LineFormat.ForeColor = Color.Blue;

            //Set the dash style of the arc.
            arc1.LineFormat.DashStyle = MsoLineDashStyle.Solid;

            //Add another arc shape.
            Aspose.Cells.Drawing.ArcShape arc2 = excelbook.Worksheets[0].Shapes.AddArc(9, 0, 2, 0, 130, 130);

            //Set the placement of the arc.
            arc2.Placement = PlacementType.FreeFloating;

            //Set the line style.
            arc2.LineFormat.Style = MsoLineStyle.Single;

            //Set the line weight.
            arc2.LineFormat.Weight = 1;

            //Set the color of the arc line.
            arc2.LineFormat.ForeColor = Color.Blue;

            //Set the dash style of the arc.
            arc2.LineFormat.DashStyle = MsoLineDashStyle.Solid;

            //Save the excel file.
            excelbook.Save(dataDir + "book1.xls");

        }
    }
}