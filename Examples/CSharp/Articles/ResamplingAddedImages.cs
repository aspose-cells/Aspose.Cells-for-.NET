using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class ResamplingAddedImages
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Initialize a new Workbook
            //Open an Excel file
            Workbook workbook = new Workbook(dataDir+ "input.xlsx");

            //Instantiate the PdfSaveOptions
            PdfSaveOptions pdfSaveOptions = new PdfSaveOptions();
            //Set Image Resample properties
            pdfSaveOptions.SetImageResample(300, 70);

            //Save the PDF file
            workbook.Save(dataDir+ "OutputFile.pdf", pdfSaveOptions);
            
        }
    }
}