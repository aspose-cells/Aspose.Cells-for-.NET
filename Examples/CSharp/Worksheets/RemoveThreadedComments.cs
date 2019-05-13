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
            ThreadedCommentCollection threadedComments = worksheet.Comments.GetThreadedComments("I4");
            ThreadedCommentAuthor author = threadedComments[0].Author;

            comments.RemoveAt("I4");

            ThreadedCommentAuthorCollection authors = workbook.Worksheets.ThreadedCommentAuthors;
            authors.RemoveAt(authors.IndexOf(author));

            workbook.Save(outDir + "ThreadedCommentsSample_Out.xlsx");
            // ExEnd:1

            Console.WriteLine("RemoveThreadedComments executed successfully.");
        }
    }
}
