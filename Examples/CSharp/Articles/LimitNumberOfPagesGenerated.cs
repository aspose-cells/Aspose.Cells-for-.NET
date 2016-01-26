using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class LimitNumberOfPagesGenerated
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Open an Excel file
            Workbook wb = new Workbook(dataDir+ "TestBook.xlsx");
            //Instantiate the PdfSaveOption
            PdfSaveOptions options = new PdfSaveOptions();

            //Print only Page 3 and Page 4 in the output PDF
            //Starting page index (0-based index)
            options.PageIndex = 3;
            //Number of pages to be printed
            options.PageCount = 2;

            //Save the PDF file
            wb.Save(dataDir+ "outPDF1.pdf", options);
            
            
        }
    }
}