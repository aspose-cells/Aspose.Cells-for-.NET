using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.HTML
{
    class HidingOverlaidContentWithCrossHideRightWhileSavingToHtml
    { 
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            //Load sample Excel file 
            Workbook wb = new Workbook(sourceDir + "sampleHidingOverlaidContentWithCrossHideRightWhileSavingToHtml.xlsx");

            //Specify HtmlSaveOptions - Hide Overlaid Content with CrossHideRight while saving to Html
            HtmlSaveOptions opts = new HtmlSaveOptions();
            opts.HtmlCrossStringType = HtmlCrossType.CrossHideRight;

            //Save to HTML with HtmlSaveOptions
            wb.Save(outputDir + "outputHidingOverlaidContentWithCrossHideRightWhileSavingToHtml.html", opts);

            Console.WriteLine("HidingOverlaidContentWithCrossHideRightWhileSavingToHtml executed successfully.");
        }
    }
}
