using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Files.Utility
{
    public class ConvertingToMHTMLFiles
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Specify the file path
            string filePath = dataDir + "Book1.xlsx";

            // Specify the HTML Saving Options
            HtmlSaveOptions sv = new HtmlSaveOptions(SaveFormat.MHtml);

            // Instantiate a workbook and open the template XLSX file
            Workbook wb = new Workbook(filePath);

            // Save the MHT file
            wb.Save(filePath + ".out.mht", sv);
            // ExEnd:1
        }
    }
}
