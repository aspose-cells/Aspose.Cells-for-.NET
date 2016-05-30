using System.IO;

using Aspose.Cells;
using Aspose.Cells.Drawing;
using System.Drawing;

namespace CSharp.Formatting.ApproachesToFormatData
{
    public class ApplyingGradientFillEffects
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiate a new Workbook
            Workbook workbook = new Workbook();
            // Get the first worksheet (default) in the workbook
            Worksheet worksheet = workbook.Worksheets[0];
            // Input a value into B3 cell
            worksheet.Cells[2, 1].PutValue("test");

            // Get the Style of the cell
            Style style = worksheet.Cells["B3"].GetStyle();
            // Set Gradient pattern on
            style.IsGradient = true;
            // Specify two color gradient fill effects
            style.SetTwoColorGradient(Color.FromArgb(255, 255, 255), Color.FromArgb(79, 129, 189), GradientStyleType.Horizontal, 1);
            // Set the color of the text in the cell
            style.Font.Color = Color.Red;
            // Specify horizontal and vertical alignment settings
            style.HorizontalAlignment = TextAlignmentType.Center;
            style.VerticalAlignment = TextAlignmentType.Center;

            // Apply the style to the cell
            worksheet.Cells["B3"].SetStyle(style);

            // Set the third row height in pixels
            worksheet.Cells.SetRowHeightPixel(2, 53);

            // Merge the range of cells (B3:C3)
            worksheet.Cells.Merge(2, 1, 1, 2);

            // Save the Excel file
            workbook.Save(dataDir + "output.xlsx");
            // ExEnd:1
 
        }
    }
}
