using System.IO;
using Aspose.Cells.Drawing;
using Aspose.Cells.Drawing.Texts;
using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class SetTextboxOrShapeParagraphLineSpacing
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create a workbook
            Workbook wb = new Workbook();

            // Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            // Add text box inside the sheet
            ws.Shapes.AddTextBox(2, 0, 2, 0, 100, 200);

            // Access first shape which is a text box and set is text
            Shape shape = ws.Shapes[0];
            shape.Text = "Sign up for your free phone number.\nCall and text online for free.";

            // Acccess the first paragraph
            TextParagraph p = shape.TextBody.TextParagraphs[1];

            // Set the line space
            p.LineSpaceSizeType = LineSpaceSizeType.Points;
            p.LineSpace = 20;

            // Set the space after
            p.SpaceAfterSizeType = LineSpaceSizeType.Points;
            p.SpaceAfter = 10;

            // Set the space before
            p.SpaceBeforeSizeType = LineSpaceSizeType.Points;
            p.SpaceBefore = 10;

            // Save the workbook in xlsx format
            wb.Save(dataDir + "output_out.xlsx", SaveFormat.Xlsx);
            // ExEnd:1
        }
    }
}