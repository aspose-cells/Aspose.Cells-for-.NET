using System.IO;
using Aspose.Cells;
using System;
namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ChangeTextDirection
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();
            
            // Instantiate a new Workbook
            var wb = new Workbook();
            
            // Get the first worksheet
            var sheet = wb.Worksheets[0];

            //Add some text in cell A1
            sheet.Cells["A1"].PutValue("Here");

            // Add a comment to A1 cell
            var comment = sheet.Comments[sheet.Comments.Add("A1")];
            
            // Set its vertical alignment setting            
            comment.CommentShape.TextVerticalAlignment = TextAlignmentType.Center;
            
            // Set its horizontal alignment setting
            comment.CommentShape.TextHorizontalAlignment = TextAlignmentType.Right;
            
            // Set the Text Direction - Right-to-Left
            comment.CommentShape.TextDirection = TextDirectionType.RightToLeft;
            
            // Set the Comment note
            comment.Note = "This is my Comment Text. This is Test.";
           
            // Save the Excel file
            wb.Save(outputDir + "outputChangeTextDirection.xlsx");

            Console.WriteLine("ChangeTextDirection executed successfully.\r\n");
        }
    }
}
