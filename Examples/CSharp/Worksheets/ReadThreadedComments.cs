using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Worksheets
{
    class ReadThreadedComments
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            Workbook workbook = new Workbook(sourceDir + "ThreadedCommentsSample.xlsx");

            //Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            ThreadedCommentCollection threadedComments = worksheet.Comments.GetThreadedComments("I4");

            foreach (ThreadedComment comment in threadedComments)
            {
                Console.WriteLine("Comment: " + comment.Notes);
                Console.WriteLine("Author: " + comment.Author.Name);
            }
            // ExEnd:1

            Console.WriteLine("ReadThreadedComments executed successfully.");
        }
    }
}
