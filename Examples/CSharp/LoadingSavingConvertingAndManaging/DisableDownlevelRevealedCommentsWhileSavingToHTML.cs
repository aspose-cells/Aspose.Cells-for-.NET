using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.LoadingSavingConvertingAndManaging
{
    public class DisableDownlevelRevealedCommentsWhileSavingToHTML 
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Load sample workbook
            Workbook wb = new Workbook(sourceDir + "sampleDisableDownlevelRevealedComments.xlsx");

            //Disable DisableDownlevelRevealedComments
            HtmlSaveOptions opts = new HtmlSaveOptions();
            opts.DisableDownlevelRevealedComments = true;

            //Save the workbook in html
            wb.Save(outputDir + "outputDisableDownlevelRevealedComments_true.html", opts);
            
            Console.WriteLine("DisableDownlevelRevealedCommentsWhileSavingToHTML executed successfully.\r\n");
        }
    }
}
