using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Worksheets.Display
{
    public class RemovePanes
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiate a new workbook and Open a template file
            Workbook book = new Workbook(dataDir + "Book1.xls");

            // Set the active cell
            book.Worksheets[0].ActiveCell = "A20";

            // Split the worksheet window
            book.Worksheets[0].RemoveSplit();

            // Save the excel file
            book.Save(dataDir + "output.xls");
            // ExEnd:1
        }
    }
}
