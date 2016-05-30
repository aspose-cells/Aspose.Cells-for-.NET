using System.IO;

using Aspose.Cells;

namespace CSharp.DrawingObjects.Comments
{
    public class AddingComment
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Adding a new worksheet to the Workbook object
            int sheetIndex = workbook.Worksheets.Add();

            // Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[sheetIndex];

            // Adding a comment to "F5" cell
            int commentIndex = worksheet.Comments.Add("F5");

            // Accessing the newly added comment
            Comment comment = worksheet.Comments[commentIndex];

            // Setting the comment note
            comment.Note = "Hello Aspose!";

            // Saving the Excel file
            workbook.Save(dataDir + "book1.out.xls");
            // ExEnd:1

        }
    }
}
