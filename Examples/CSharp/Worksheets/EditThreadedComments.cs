using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Worksheets
{
    class EditThreadedComments
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();
            string outDir = RunExamples.Get_OutputDirectory();

            Workbook workbook = new Workbook(sourceDir + "ThreadedCommentsSample.xlsx");

            //Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Get Threaded Comment
            ThreadedComment comment = worksheet.Comments.GetThreadedComments("A1")[0];
            comment.Notes = "Updated Comment";

            workbook.Save(outDir + "EditThreadedComments.xlsx");
            // ExEnd:1

            Console.WriteLine("EditThreadedComments executed successfully.");
        }
    }
}
