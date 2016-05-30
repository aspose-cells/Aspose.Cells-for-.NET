using System.IO;

using Aspose.Cells;

namespace CSharp.Formatting.ConfiguringAlignmentSettings
{
    public class Orientation
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            
            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Obtaining the reference of the worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Accessing the "A1" cell from the worksheet
            Aspose.Cells.Cell cell = worksheet.Cells["A1"];

            // Adding some value to the "A1" cell
            cell.PutValue("Visit Aspose!");

            // Setting the horizontal alignment of the text in the "A1" cell
            Style style = cell.GetStyle();
            
            // Setting the rotation of the text (inside the cell) to 25
            style.RotationAngle = 25;

            cell.SetStyle(style);

            // Saving the Excel file
            workbook.Save(dataDir + "book1.out.xls", SaveFormat.Excel97To2003);
            // ExEnd:1
            
        }
    }
}
