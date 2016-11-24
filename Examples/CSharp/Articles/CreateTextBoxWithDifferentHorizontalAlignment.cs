using System.IO;
using System;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Drawing.Texts;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class CreateTextBoxWithDifferentHorizontalAlignment
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create a workbook.
            Workbook wb = new Workbook();

            // Access first worksheet.
            Worksheet ws = wb.Worksheets[0];

            // Add text box inside the sheet.
            ws.Shapes.AddTextBox(2, 0, 2, 0, 80, 400);

            // Access first shape which is a text box and set is text.
            Shape shape = ws.Shapes[0];
            shape.Text = "Sign up for your free phone number.\nCall and text online for free.\nCall your friends and family.";

            // Acccess the first paragraph and set its horizontal alignment to left.
            TextParagraph p = shape.TextBody.TextParagraphs[0];
            p.AlignmentType = TextAlignmentType.Left;

            // Acccess the second paragraph and set its horizontal alignment to center.
            p = shape.TextBody.TextParagraphs[1];
            p.AlignmentType = TextAlignmentType.Center;

            // Acccess the third paragraph and set its horizontal alignment to right.
            p = shape.TextBody.TextParagraphs[2];
            p.AlignmentType = TextAlignmentType.Right;

            // Save the workbook in xlsx format.
            wb.Save(dataDir + "output_out.xlsx", SaveFormat.Xlsx);            
            // ExEnd:1            
        }
    }
}
