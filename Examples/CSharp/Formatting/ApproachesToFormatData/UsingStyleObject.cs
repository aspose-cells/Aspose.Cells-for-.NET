using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.Formatting.ApproachesToFormatData
{
    public class UsingStyleObject
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

            //Adding a new worksheet to the Excel object
            int i = workbook.Worksheets.Add();

            //Obtaining the reference of the first worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[i];

            //Accessing the "A1" cell from the worksheet
            Cell cell = worksheet.Cells["A1"];

            //Adding some value to the "A1" cell
            cell.PutValue("Hello Aspose!");

            //Adding a new Style to the styles collection of the Excel object
            int index = workbook.Styles.Add();

            //Accessing the newly added Style to the Excel object
            Style style = workbook.Styles[index];

            //Setting the vertical alignment of the text in the "A1" cell
            style.VerticalAlignment = TextAlignmentType.Center;

            //Setting the horizontal alignment of the text in the "A1" cell
            style.HorizontalAlignment = TextAlignmentType.Center;

            //Setting the font color of the text in the "A1" cell
            style.Font.Color = Color.Green;

            //Shrinking the text to fit in the cell
            style.ShrinkToFit = true;

            //Setting the bottom border color of the cell to red
            style.Borders[BorderType.BottomBorder].Color = Color.Red;

            //Setting the bottom border type of the cell to medium
            style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Medium;

            //Assigning the Style object to the "A1" cell
            cell.SetStyle(style);


            //Apply the same style to some other cells
            worksheet.Cells["B1"].SetStyle(style);
            worksheet.Cells["C1"].SetStyle(style);
            worksheet.Cells["D1"].SetStyle(style);


            //Saving the Excel file
            workbook.Save(dataDir + "book1.xls");

        }
    }
}