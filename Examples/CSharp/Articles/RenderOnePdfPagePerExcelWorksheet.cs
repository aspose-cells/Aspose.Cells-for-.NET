using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class RenderOnePdfPagePerExcelWorksheet
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Initialize a new Workbook
            // Open an Excel file
            Workbook workbook = new Workbook(dataDir+ "input.xlsx");

            // Implement one page per worksheet option
            PdfSaveOptions pdfSaveOptions = new PdfSaveOptions();
            pdfSaveOptions.OnePagePerSheet = true;

            // Save the PDF file
            workbook.Save(dataDir+ "OutputFile.out.pdf", pdfSaveOptions);
            
        }
    }
}