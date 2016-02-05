using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Formatting.ConfiguringAlignmentSettings
{
    public class TextAlignmentVertical
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

            //Clearing all the worksheets
            workbook.Worksheets.Clear();

            //Adding a new worksheet to the Excel object
            int i = workbook.Worksheets.Add();

            //Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[i];

            //Accessing the "A1" cell from the worksheet
            Aspose.Cells.Cell cell = worksheet.Cells["A1"];

            //Adding some value to the "A1" cell
            cell.PutValue("Visit Aspose!");

            //Setting the horizontal alignment of the text in the "A1" cell
            Style style = cell.GetStyle();

            //Setting the vertical alignment of the text in a cell
            style.VerticalAlignment = TextAlignmentType.Center;

            cell.SetStyle(style);

            //Saving the Excel file
            workbook.Save(dataDir + "book1.out.xls", SaveFormat.Excel97To2003);
 
        }
    }
}