using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class UsePresentationPreferenceOption
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Instantiate the Workbook
            // Load an Excel file
            Workbook workbook = new Workbook(dataDir+ "sample.xlsx");

            // Create HtmlSaveOptions object
            HtmlSaveOptions options = new HtmlSaveOptions();
            // Set the Presenation preference option
            options.PresentationPreference = true;

            // Save the Excel file to HTML with specified option
            workbook.Save(dataDir+ "outPresentationlayout1.out.html", options);
            // ExEnd:1
        }
    }
}