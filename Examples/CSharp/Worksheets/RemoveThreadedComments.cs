using System;

namespace Aspose.Cells.Examples.CSharp.Worksheets
{
    class RemoveThreadedComments
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

            CommentCollection comments = worksheet.Comments;

            // Get Author of first comment in A1
            ThreadedCommentAuthor author = worksheet.Comments.GetThreadedComments("A1")[0].Author;

            // Remove Comments in A1
            comments.RemoveAt("A1");

            ThreadedCommentAuthorCollection authors = workbook.Worksheets.ThreadedCommentAuthors;

            // Remove Author of first comment in A1
            //authors.RemoveAt(authors.IndexOf(author));

            workbook.Save(outDir + "ThreadedCommentsSample_Out.xlsx");
            // ExEnd:1

            Console.WriteLine("RemoveThreadedComments executed successfully.");
        }
    }
}
