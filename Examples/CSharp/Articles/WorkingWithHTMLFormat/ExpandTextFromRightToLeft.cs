using System;
using System.IO;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithHTMLFormat
{
    public class ExpandTextFromRightToLeft
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();
           
            // Load source excel file inside the workbook object
            Workbook wb = new Workbook(sourceDir + "sampleExpandTextFromRightToLeft.xlsx");

            // Save workbook in html format
            wb.Save(outputDir + "outputExpandTextFromRightToLeft_" + CellsHelper.GetVersion() + ".html", SaveFormat.Html);

            Console.WriteLine("ExpandTextFromRightToLeft executed successfully.");
        }
    }
}
