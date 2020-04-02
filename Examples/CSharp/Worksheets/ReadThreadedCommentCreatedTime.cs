using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Worksheets
{
    class ReadThreadedCommentCreatedTime
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            Workbook workbook = new Workbook(sourceDir + "ThreadedCommentsSample.xlsx");

            //Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Get Threaded Comments
            ThreadedCommentCollection threadedComments = worksheet.Comments.GetThreadedComments("A1");

            foreach (ThreadedComment comment in threadedComments)
            {
                Console.WriteLine("Comment: " + comment.Notes);
                Console.WriteLine("Author: " + comment.Author.Name);
                Console.WriteLine("Created Time: " + comment.CreatedTime);
            }
            // ExEnd:1

            Console.WriteLine("ReadThreadedCommentCreatedTime executed successfully.");
        }
    }
}
