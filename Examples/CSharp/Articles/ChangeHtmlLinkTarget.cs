using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    class ChangeHtmlLinkTarget
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            Workbook workbook = new Workbook(sourceDir + "sampleChangeHtmlLinkTarget.xlsx");

            HtmlSaveOptions opts = new HtmlSaveOptions();
            opts.LinkTargetType = HtmlLinkTargetType.Self;

            workbook.Save(outputDir + "outputChangeHtmlLinkTarget.html", opts);

            Console.WriteLine("ChangeHtmlLinkTarget executed successfully.\r\n");
        }
    }
}
