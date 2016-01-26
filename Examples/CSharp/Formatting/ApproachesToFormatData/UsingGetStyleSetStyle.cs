using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.Formatting.ApproachesToFormatData
{
    public class UsingGetStyleSetStyle
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Obtaining the reference of the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Accessing the "A1" cell from the worksheet
            Cell cell = worksheet.Cells["A1"];

            //Adding some value to the "A1" cell
            cell.PutValue("Hello Aspose!");

            //Defining a Style object
            Aspose.Cells.Style style;

            //Get the style from A1 cell
            style = cell.GetStyle();

            //Setting the vertical alignment
            style.VerticalAlignment = TextAlignmentType.Center;

            //Setting the horizontal alignment
            style.HorizontalAlignment = TextAlignmentType.Center;

            //Setting the font color of the text
            style.Font.Color = Color.Green;

            //Setting to shrink according to the text contained in it
            style.ShrinkToFit = true;

            //Setting the bottom border color to red
            style.Borders[BorderType.BottomBorder].Color = Color.Red;

            //Setting the bottom border type to medium
            style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Medium;

            //Applying the style to A1 cell
            cell.SetStyle(style);

            //Saving the Excel file
            workbook.Save(dataDir + "book1.xls");
 
        }
    }
}