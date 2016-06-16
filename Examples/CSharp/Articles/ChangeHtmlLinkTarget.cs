using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    class ChangeHtmlLinkTarget
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string inputPath = dataDir + "Sample1.xlsx";
            string outputPath = dataDir + "Output.out.html";

            Workbook workbook = new Workbook(dataDir + "Sample1.xlsx");

            HtmlSaveOptions opts = new HtmlSaveOptions();
            opts.LinkTargetType = HtmlLinkTargetType.Self;

            workbook.Save(outputPath, opts);
            Console.WriteLine("File saved: {0}", outputPath);
            // ExEnd:1
        }
    }
}
