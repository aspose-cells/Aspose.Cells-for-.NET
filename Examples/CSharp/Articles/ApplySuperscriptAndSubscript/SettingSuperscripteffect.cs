using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles.ApplySuperscriptAndSubscript
{
    public class SettingSuperscripteffect
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
            workbook.Worksheets.Add();

            //Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[0];

            //Accessing the "A1" cell from the worksheet
            Cell cell = worksheet.Cells["A1"];

            //Adding some value to the "A1" cell
            cell.PutValue("Hello");

            //Setting the font Superscript
            Style style = cell.GetStyle();
            style.Font.IsSuperscript = true;
            cell.SetStyle(style);

            //Saving the Excel file
            workbook.Save(dataDir+ "Superscript.xls", SaveFormat.Auto);
            
            
        }
    }
}