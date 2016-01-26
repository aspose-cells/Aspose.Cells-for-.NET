using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;
using System.Drawing;

namespace Aspose.Cells.Examples.DrawingObjects.Controls
{
    public class AddingLabelControl__
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Create a new Workbook.
            Workbook workbook = new Workbook();

            //Get the first worksheet in the workbook.
            Worksheet sheet = workbook.Worksheets[0];

            //Add a new label to the worksheet.
            Aspose.Cells.Drawing.Label label = sheet.Shapes.AddLabel(2, 0, 2, 0, 60, 120);

            //Set the caption of the label.
            label.Text = "This is a Label";

            //Set the Placement Type, the way the
            //label is attached to the cells.
            label.Placement = PlacementType.FreeFloating;

            //Set the fill color of the label.
            label.FillFormat.ForeColor = Color.Yellow;

            //Saves the file.
            workbook.Save(dataDir + "book1.xls");

        }
    }
}