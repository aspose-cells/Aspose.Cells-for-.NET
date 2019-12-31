using System;

namespace Aspose.Cells.Examples.CSharp.LoadingSavingConvertingAndManaging
{
    public class ConvertExcelFileToHtmlWithTooltip
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // ExStart:1
            // Open the template file
            Workbook workbook = new Workbook(sourceDir + "AddTooltipToHtmlSample.xlsx");

            HtmlSaveOptions options = new HtmlSaveOptions();
            options.AddTooltipText = true;

            // Save as Markdown
            workbook.Save(outputDir + "AddTooltipToHtmlSample_out.html", options);
            // ExEnd:1

            Console.WriteLine("ConvertExcelFileToHtmlWithTooltip executed successfully.");
        }
    }
}
