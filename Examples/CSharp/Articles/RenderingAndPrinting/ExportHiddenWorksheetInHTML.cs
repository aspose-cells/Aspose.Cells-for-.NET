using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.RenderingAndPrinting
{
    public class ExportHiddenWorksheetInHTML
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create workbook object
            Workbook workbook = new Workbook(sourceDir + "sampleExportHiddenWorksheetInHTML.xlsx");

            // Do not export hidden worksheet contents
            HtmlSaveOptions options = new HtmlSaveOptions();
            options.ExportHiddenWorksheet = true;

            // Save the workbook
            workbook.Save(outputDir + "outputExportHiddenWorksheetInHTML.html", options);

            Console.WriteLine("ExportHiddenWorksheetInHTML executed successfully.");
        }
    }
}
