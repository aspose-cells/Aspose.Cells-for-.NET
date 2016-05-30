using System.IO;

using Aspose.Cells;

namespace CSharp.Files.Handling
{
    public class SaveInPdfFormat
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Creating a Workbook object
            Workbook workbook = new Workbook();
              // Save in Pdf format
            workbook.Save(dataDir + "output.pdf", SaveFormat.Pdf);

            // ExEnd:1
        }
    }
}
