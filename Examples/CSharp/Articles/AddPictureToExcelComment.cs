using System.IO;
using System;
using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class AddPictureToExcelComment
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiate a Workbook
            Workbook workbook = new Workbook();

            //Add some text in cell A1
            workbook.Worksheets[0].Cells["A1"].PutValue("Here");

            // Get a reference of comments collection with the first sheet
            CommentCollection comments = workbook.Worksheets[0].Comments;

            // Add a comment to cell A1
            int commentIndex = comments.Add(0, 0);
            Comment comment = comments[commentIndex];
            comment.Note = "First note.";
            comment.Font.Name = "Times New Roman";

            // Load an image into stream
            Bitmap bmp = new Bitmap(sourceDir + "sampleAddPictureToExcelComment.jpg");
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            // Set image data to the shape associated with the comment
            comment.CommentShape.Fill.ImageData = ms.ToArray();
            
            // Save the workbook
            workbook.Save(outputDir + "outputAddPictureToExcelComment.xlsx", Aspose.Cells.SaveFormat.Xlsx);

            Console.WriteLine("AddPictureToExcelComment executed successfully.\r\n");
        }
    }
}
