using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class FitAllWorksheetColumns
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Create and initialize an instance of Workbook
            Workbook book = new Workbook(dataDir + "TestBook.xlsx");
            //Create and initialize an instance of PdfSaveOptions
            PdfSaveOptions saveOptions = new PdfSaveOptions(SaveFormat.Pdf);
            //Set AllColumnsInOnePagePerSheet to true
            saveOptions.AllColumnsInOnePagePerSheet = true;
            //Save Workbook to PDF fromart by passing the object of PdfSaveOptions
            book.Save(dataDir+ "output.out.pdf", saveOptions);
            
            
        }
    }
}