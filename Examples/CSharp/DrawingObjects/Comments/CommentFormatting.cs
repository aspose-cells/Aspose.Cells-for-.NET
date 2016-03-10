using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.DrawingObjects.Comments
{
    public class CommentFormatting
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Adding a new worksheet to the Workbook object
            int sheetIndex = workbook.Worksheets.Add();

            //Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[sheetIndex];

            //Adding a comment to "F5" cell
            int commentIndex = worksheet.Comments.Add("F5");

            //Accessing the newly added comment
            Comment comment = worksheet.Comments[commentIndex];

            //Setting the comment note
            comment.Note = "Hello Aspose!";

            //Setting the font size of a comment to 14
            comment.Font.Size = 14;

            //Setting the font of a comment to bold
            comment.Font.IsBold = true;

            //Setting the height of the font to 10
            comment.HeightCM = 10;

            //Setting the width of the font to 2
            comment.WidthCM = 2;

            //Saving the Excel file
            workbook.Save(dataDir + "book1.out.xls");
            //ExEnd:1

        }
    }
}
