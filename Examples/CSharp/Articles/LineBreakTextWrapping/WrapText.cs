using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.LineBreakTextWrapping
{
    public class WrapText
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Create Workbook Object
            Workbook wb = new Workbook();

            // Open first Worksheet in the workbook
            Worksheet ws = wb.Worksheets[0];

            // Get Worksheet Cells Collection
            Aspose.Cells.Cells cell = ws.Cells;

            // Increase the width of First Column Width
            cell.SetColumnWidth(0, 35);

            // Increase the height of first row
            cell.SetRowHeight(0, 36);

            // Add Text to the Firts Cell
            cell[0, 0].PutValue("I am using the latest version of Aspose.Cells to test this functionality");

            // Make Cell's Text wrap
            Style style = cell[0, 0].GetStyle();
            style.IsTextWrapped = true;
            cell[0, 0].SetStyle(style);

            // Save Excel File
            wb.Save(dataDir+ "WrappingText.out.xlsx");
            // ExEnd:1
            
            
        }
    }
}
