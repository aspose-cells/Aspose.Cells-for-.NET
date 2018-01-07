using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    class HtmlExportFrameScripts
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open the required workbook to convert
            Workbook wb = new Workbook(sourceDir + "sampleHtmlExportFrameScripts.xlsx");

            // Disable exporting frame scripts and document properties
            HtmlSaveOptions options = new HtmlSaveOptions();
            options.ExportFrameScriptsAndProperties = false;

            // Save workbook as HTML
            wb.Save(outputDir + "outputHtmlExportFrameScripts.html", options);

            Console.WriteLine("HtmlExportFrameScripts executed successfully.");
        }
    }
}
