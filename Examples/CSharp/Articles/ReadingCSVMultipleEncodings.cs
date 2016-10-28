using System.IO;
using Aspose.Cells;
namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ReadingCSVMultipleEncodings
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            string filePath = dataDir + "MultiEncoded.csv";

            // Set Multi Encoded Property to True
            TxtLoadOptions options = new TxtLoadOptions();
            options.IsMultiEncoded = true;

            // Load the CSV file into Workbook
            Workbook workbook = new Workbook(filePath, options);

            // Save it in XLSX format
            workbook.Save( filePath + ".out.xlsx", SaveFormat.Xlsx);
            // ExEnd:1
        }
    }
}