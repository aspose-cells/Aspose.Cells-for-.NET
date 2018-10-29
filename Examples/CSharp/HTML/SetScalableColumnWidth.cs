using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.HTML
{
    class SetScalableColumnWidth
    {
        public static void Main()
        {
            // Input directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Output directory
            string outputDir = RunExamples.Get_OutputDirectory();
            // ExStart:1
            // Load sample source file
            Workbook wb = new Workbook(sourceDir + "sampleForScalableColumns.xlsx");

            // Specify Html Save Options
            HtmlSaveOptions options = new HtmlSaveOptions();

            // Set the property for scalable width
            options.WidthScalable = true;

            // Specify image save format
            options.ExportImagesAsBase64 = true;

            // Save the workbook in Html format with specified Html Save Options
            wb.Save(outputDir + "outsampleForScalableColumns.html", options);
            // ExEnd:1
            Console.WriteLine("SetScalableColumnWidth executed successfully.\r\n");
        }
    }
}
