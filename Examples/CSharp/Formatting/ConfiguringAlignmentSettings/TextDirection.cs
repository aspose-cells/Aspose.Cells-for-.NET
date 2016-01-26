using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Formatting.ConfiguringAlignmentSettings
{
    public class TextDirection
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

            //Obtaining the reference of the worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Accessing the "A1" cell from the worksheet
            Aspose.Cells.Cell cell = worksheet.Cells["A1"];

            //Adding some value to the "A1" cell
            cell.PutValue("Visit Aspose!");

            //Setting the horizontal alignment of the text in the "A1" cell
            Style style = cell.GetStyle();

            //Setting the text direction from right to left
            style.TextDirection = TextDirectionType.RightToLeft;

            cell.SetStyle(style);

            //Saving the Excel file
            workbook.Save(dataDir + "book1.xls", SaveFormat.Excel97To2003);
        }
    }
}