using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.HTML
{
    class RecognizeSelfClosingTags
    {
        public static void Main()
        {
            // Input directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Output directory
            string outputDir = RunExamples.Get_OutputDirectory();
            // ExStart:1
            // Set Html load options and keep precision true
            HtmlLoadOptions loadOptions = new HtmlLoadOptions(LoadFormat.Html);

            // Load sample source file
            Workbook wb = new Workbook(sourceDir + "sampleSelfClosingTags.html", loadOptions);

            // Save the workbook
            wb.Save(outputDir + "outsampleSelfClosingTags.xlsx");
            // ExEnd:1
            Console.WriteLine("RecognizeSelfClosingTags executed successfully.\r\n");
        }
    }
}
