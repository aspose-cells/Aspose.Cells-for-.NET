using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Files.Utility
{
    public class ConvertingToHTMLFiles
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Specify the file path
            string filePath = dataDir + "sample.xlsx";

            // Load your sample excel file in a workbook object
            Workbook wb = new Workbook(filePath);

            // Save it in HTML format
            wb.Save(dataDir + "ConvertingToHTMLFiles_out.html", SaveFormat.Html);
            // ExEnd:1
        }
    }
}