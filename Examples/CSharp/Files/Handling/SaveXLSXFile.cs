using System.IO;
using System.Web;
using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Files.Handling
{
    public class SaveXLSXFile
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            HttpResponse Respose = null;
            // Load your source workbook
            Workbook workbook = new Workbook();
            if (Respose != null)
            {
                // Save in Excel2007 xlsx format
                workbook.Save(Respose, dataDir + "output.xlsx", ContentDisposition.Attachment, new OoxmlSaveOptions());
                Respose.End();
            }
            // ExEnd:1
        }
    }
}
