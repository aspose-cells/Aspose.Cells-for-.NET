using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class RenderOnePdfPagePerExcelWorksheet
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Initialize a new Workbook
            //Open an Excel file
            Workbook workbook = new Workbook(dataDir+ "input.xlsx");

            //Implement one page per worksheet option
            PdfSaveOptions pdfSaveOptions = new PdfSaveOptions();
            pdfSaveOptions.OnePagePerSheet = true;

            //Save the PDF file
            workbook.Save(dataDir+ "OutputFile.pdf", pdfSaveOptions);
            
        }
    }
}