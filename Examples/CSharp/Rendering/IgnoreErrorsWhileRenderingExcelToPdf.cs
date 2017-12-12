using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Rendering
{
    class IgnoreErrorsWhileRenderingExcelToPdf 
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Load the Sample Workbook that throws Error on Excel2Pdf conversion
            Workbook wb = new Workbook(sourceDir + "sampleErrorExcel2Pdf.xlsx");

            //Specify Pdf Save Options - Ignore Error
            PdfSaveOptions opts = new PdfSaveOptions();
            opts.IgnoreError = true;

            //Save the Workbook in Pdf with Pdf Save Options
            wb.Save(outputDir + "outputErrorExcel2Pdf.pdf", opts);

            Console.WriteLine("IgnoreErrorsWhileRenderingExcelToPdf executed successfully.\r\n");
        }
    }
}
