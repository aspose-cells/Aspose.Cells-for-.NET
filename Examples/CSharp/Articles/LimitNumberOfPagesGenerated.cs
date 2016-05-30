using System.IO;

using Aspose.Cells;

namespace CSharp.Articles
{
    public class LimitNumberOfPagesGenerated
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Open an Excel file
            Workbook wb = new Workbook(dataDir+ "TestBook.xlsx");
            // Instantiate the PdfSaveOption
            PdfSaveOptions options = new PdfSaveOptions();

            // Print only Page 3 and Page 4 in the output PDF
            // Starting page index (0-based index)
            options.PageIndex = 3;
            // Number of pages to be printed
            options.PageCount = 2;

            // Save the PDF file
            wb.Save(dataDir+ "outPDF1.out.pdf", options);
            // ExEnd:1
            
            
        }
    }
}
