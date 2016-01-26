using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.Formatting
{
    public class FormattingSelectedCharacters
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

            //Obtaining the reference of the first(default) worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[0];

            //Accessing the "A1" cell from the worksheet
            Cell cell = worksheet.Cells["A1"];

            //Adding some value to the "A1" cell
            cell.PutValue("Visit Aspose!");

            //Setting the font of selected characters to bold
            cell.Characters(6, 7).Font.IsBold = true;

            //Setting the font color of selected characters to blue
            cell.Characters(6, 7).Font.Color = Color.Blue;

            //Saving the Excel file
            workbook.Save(dataDir + "book1.xls");

        }
    }
}