using System.IO;

using Aspose.Cells;

namespace CSharp.Articles
{
    public class GetIconSetsDataBars
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Open a template Excel file
            Workbook workbook = new Workbook(dataDir+ "book1.xlsx");

            // Get the first worksheet in the workbook
            Worksheet sheet = workbook.Worksheets[0];

            // Get the A1 cell
            Cell cell = sheet.Cells["A1"];

            // Get the conditional formatting result object
            ConditionalFormattingResult cfr = cell.GetConditionalFormattingResult();

            // Get the icon set
            ConditionalFormattingIcon icon = cfr.ConditionalFormattingIcon;

            // Create the image file based on the icon's image data
            File.WriteAllBytes(dataDir+ "imgIcon.out.jpg", icon.ImageData);
            // ExEnd:1
            
        }
    }
}
