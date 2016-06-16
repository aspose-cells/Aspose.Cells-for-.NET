using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Formatting.ApproachesToFormatData
{
    public class UsingExcelPredefinedStyles
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

            // Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            // Create a style object .
            Style style = workbook.CreateStyle();

            // Input a value to A1 cell.
            workbook.Worksheets[0].Cells["A1"].PutValue("Test");

            // Apply the style to the cell.
            workbook.Worksheets[0].Cells["A1"].SetStyle(style);

            // Save the Excel 2007 file.
            workbook.Save(dataDir + "book1.out.xlsx");
            // ExEnd:1
 
        }
    }
}
