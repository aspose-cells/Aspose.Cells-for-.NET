using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithHTMLFormat
{
    class RenderGradientFillToHTML
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Read the source excel file having text with gradient fill
            Workbook book = new Workbook(sourceDir + "sampleRenderGradientFillToHTML.xlsx");

            // Save workbook to html format
            book.Save(outputDir + "outputRenderGradientFillToHTML.html");

            Console.WriteLine("RenderGradientFillToHTML executed successfully.\r\n");
        }
    }
}
