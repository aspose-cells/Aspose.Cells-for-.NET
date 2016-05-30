using System.IO;

using Aspose.Cells;

namespace CSharp.Articles
{
    public class SecurePDFDocuments
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Open an Excel file
            Workbook workbook = new Workbook(dataDir+ "input.xlsx");

            // Instantiate PDFSaveOptions to manage security attributes
            PdfSaveOptions saveOption = new PdfSaveOptions();

            saveOption.SecurityOptions = new Aspose.Cells.Rendering.PdfSecurity.PdfSecurityOptions();
            // Set the user password
            saveOption.SecurityOptions.UserPassword = "user";

            // Set the owner password
            saveOption.SecurityOptions.OwnerPassword = "owner";

            // Disable extracting content permission
            saveOption.SecurityOptions.ExtractContentPermission = false;

            // Disable print permission
            saveOption.SecurityOptions.PrintPermission = false;

            // Save the PDF document with encrypted settings
            workbook.Save(dataDir+ "securepdf_test.out.pdf", saveOption);
            
        }
    }
}