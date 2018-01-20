using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.RenderingAndPrinting
{
    public class PrintCommentWhileSavingToPdf
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create a workbook from source Excel file
            Workbook workbook = new Workbook(sourceDir + "samplePrintCommentWhileSavingToPdf.xlsx");

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            /*
             * For print no comments use "PrintCommentsType.PrintNoComments"
             * and for print the comments as displayed on sheet use "PrintCommentsType.PrintInPlace"
             * For Print the comments at the end of sheet we use "PrintCommentsType.PrintSheetEnd"
            */
            worksheet.PageSetup.PrintComments = PrintCommentsType.PrintSheetEnd;

            // Save workbook in pdf format
            workbook.Save(outputDir + "outputPrintCommentWhileSavingToPdf.pdf");

            Console.WriteLine("PrintCommentWhileSavingToPdf executed successfully.");
        }
    }
}
