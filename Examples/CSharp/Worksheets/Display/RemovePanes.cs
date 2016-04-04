using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Worksheets.Display
{
    public class RemovePanes
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Instantiate a new workbook and Open a template file
            Workbook book = new Workbook(dataDir + "Book1.xls");

            //Set the active cell
            book.Worksheets[0].ActiveCell = "A20";

            //Split the worksheet window
            book.Worksheets[0].RemoveSplit();

            //Save the excel file
            book.Save(dataDir + "output.xls");
            //ExEnd:1
        }
    }
}
