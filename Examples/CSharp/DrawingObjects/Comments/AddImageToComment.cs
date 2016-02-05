using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.DrawingObjects.Comments
{
    public class AddImageToComment
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiate a Workbook
            Workbook workbook = new Workbook();

            //Get a reference of comments collection with the first sheet
            CommentCollection comments = workbook.Worksheets[0].Comments;

            //Add a comment to cell A1
            int commentIndex = comments.Add(0, 0);
            Comment comment = comments[commentIndex];
            comment.Note = "First note.";
            comment.Font.Name = "Times New Roman";

            //Load an image into stream
            Bitmap bmp = new Bitmap(dataDir + "logo.jpg");
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            //Set image data to the shape associated with the comment
            comment.CommentShape.FillFormat.ImageData = ms.ToArray();

            //Save the workbook
            workbook.Save(dataDir + "book1.out.xlsx", Aspose.Cells.SaveFormat.Xlsx);

            
        }
    }
}