using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class SetWorksheetTabColor
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiate a new Workbook
            // Open an Excel file
            Workbook workbook = new Workbook(dataDir+ "Book1.xlsx");

            // Get the first worksheet in the book
            Worksheet worksheet = workbook.Worksheets[0];

            // Set the tab color
            worksheet.TabColor = Color.Red;

            // Save the Excel file
            workbook.Save(dataDir+ "worksheettabcolor.out.xls");
            
        }
    }
}