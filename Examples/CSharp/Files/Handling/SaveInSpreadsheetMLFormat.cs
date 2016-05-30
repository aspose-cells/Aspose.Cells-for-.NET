using System.IO;

using Aspose.Cells;

namespace CSharp.Files.Handling
{
    public class SaveInSpreadsheetMLFormat
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Creating a Workbook object
            Workbook workbook = new Workbook();
            // Save in SpreadsheetML format
            workbook.Save(dataDir + "output.xml", SaveFormat.SpreadsheetML); 
            // ExEnd:1
        }
    }
}
