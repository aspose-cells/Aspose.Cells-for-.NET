using System;

namespace Aspose.Cells.Examples.CSharp.HTML
{
    class PrintHeadings
    {
        public static void Run()
        {
            // ExStart:1
            // Input directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Output directory
            string outputDir = RunExamples.Get_OutputDirectory();
            // ExStart:1

            //Load sample source file
            Workbook workbook = new Workbook(sourceDir + "Book1.xlsx");

            HtmlSaveOptions options = new HtmlSaveOptions();
            options.ExportHeadings = true;

            // Save the workbook
            workbook.Save(outputDir + "PrintHeadings_out.html", options);
            // ExEnd:1

            Console.WriteLine("PrintHeadings executed successfully.\r\n");
        }
    }
}
