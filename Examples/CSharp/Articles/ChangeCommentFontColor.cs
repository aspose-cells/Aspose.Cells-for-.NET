using System;
using Aspose.Cells.Drawing;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ChangeCommentFontColor
    {
        public static void Run()
        {
            // ExStart:1
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiate a new Workbook
            Workbook workbook = new Workbook();
            
            // Get the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Add some text in cell A1
            worksheet.Cells["A1"].PutValue("Here");

            // Add a comment to A1 cell
            var comment = worksheet.Comments[worksheet.Comments.Add("A1")];
            
            // Set its vertical alignment setting            
            comment.CommentShape.TextVerticalAlignment = TextAlignmentType.Center;
            
            // Set the Comment note
            comment.Note = "This is my Comment Text. This is Test.";

            Shape shape = worksheet.Comments["A1"].CommentShape;

            shape.Fill.SolidFill.Color = Color.Black;
            Font font = shape.Font;
            font.Color = Color.White;
            StyleFlag styleFlag = new StyleFlag();
            styleFlag.FontColor = true;
            shape.TextBody.Format(0, shape.Text.Length, font, styleFlag);

            // Save the Excel file
            workbook.Save(outputDir + "outputChangeCommentFontColor.xlsx");
            // ExEnd:1

            Console.WriteLine("ChangeCommentFontColor executed successfully.\r\n");
        }
    }
}
