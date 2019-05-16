using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Worksheets
{
    class AddThreadedComments
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string outDir = RunExamples.Get_OutputDirectory();

            Workbook workbook = new Workbook();

            // Add Author
            int authorIndex = workbook.Worksheets.ThreadedCommentAuthors.Add("Aspose Test", "", "");
            ThreadedCommentAuthor author = workbook.Worksheets.ThreadedCommentAuthors[authorIndex];

            // Add Threaded Comment
            workbook.Worksheets[0].Comments.AddThreadedComment("A1", "Test Threaded Comment", author);

            workbook.Save(outDir + "AddThreadedComments_out.xlsx");
            // ExEnd:1

            Console.WriteLine("AddThreadedComments executed successfully.");
        }
    }
}
