using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;
using System.Drawing;

namespace Aspose.Cells.Examples.DrawingObjects.Controls
{
    public class AddingSpinnerControl
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

            //Get the first worksheet.
            Worksheet worksheet = excelbook.Worksheets[0];

            //Get the worksheet cells.
            Cells cells = worksheet.Cells;

            //Input a string value into A1 cell.
            cells["A1"].PutValue("Select Value:");

            //Set the font color of the cell.
            cells["A1"].GetStyle().Font.Color = Color.Red;

            //Set the font text bold.
            cells["A1"].GetStyle().Font.IsBold = true;

            //Input value into A2 cell.
            cells["A2"].PutValue(0);

            //Set the shading color to black with solid background.
            cells["A2"].GetStyle().ForegroundColor = Color.Black;
            cells["A2"].GetStyle().Pattern = BackgroundType.Solid;

            //Set the font color of the cell.
            cells["A2"].GetStyle().Font.Color = Color.White;

            //set the font text bold.
            cells["A2"].GetStyle().Font.IsBold = true;

            //Add a spinner control.
            Aspose.Cells.Drawing.Spinner spinner = excelbook.Worksheets[0].Shapes.AddSpinner(1, 0, 1, 0, 20, 18);

            //Set the placement type of the spinner.
            spinner.Placement = PlacementType.FreeFloating;

            //Set the linked cell for the control.
            spinner.LinkedCell = "A2";

            //Set the maximum value.
            spinner.Max = 10;

            //Set the minimum value.
            spinner.Min = 0;

            //Set the incr. change for the control.
            spinner.IncrementalChange = 2;

            //Set it 3-D shading.
            spinner.Shadow = true;

            //Save the excel file.
            excelbook.Save(dataDir + "book1.xls");

        }
    }
}