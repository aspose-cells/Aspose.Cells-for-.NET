using System.IO;
using System.Web;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class SaveInPdfFormat
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            HttpResponse Respose = null;
            // Creating a Workbook object
            Workbook workbook = new Workbook();
              // Save in Pdf format
            workbook.Save(Respose, dataDir + "output.pdf", ContentDisposition.Attachment, new PdfSaveOptions());
            Respose.End();
            // ExEnd:1
        }
    }
}
