using System;
using Aspose.Cells;

namespace CSharp.Articles
{
    class ChangeHtmlLinkTarget
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string inputPath = dataDir + "Sample1.xlsx";
            string outputPath = dataDir + "Output.html";

            Workbook workbook = new Workbook(dataDir + "Sample1.xlsx");

            HtmlSaveOptions opts = new HtmlSaveOptions();
            opts.LinkTargetType = HtmlLinkTargetType.Self;

            workbook.Save(outputPath, opts);
            Console.WriteLine("File saved: {0}", outputPath);
        }
    }
}
