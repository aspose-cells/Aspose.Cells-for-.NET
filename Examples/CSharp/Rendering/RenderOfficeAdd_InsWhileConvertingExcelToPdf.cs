using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Rendering
{
    class RenderOfficeAdd_InsWhileConvertingExcelToPdf 
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Load the sample Excel file containing Office Add-Ins
            Workbook wb = new Workbook(sourceDir + "sampleRenderOfficeAdd-Ins.xlsx");

            //Save it to Pdf format
            wb.Save(outputDir + "output-" + CellsHelper.GetVersion() + ".pdf");

            Console.WriteLine("RenderOfficeAdd_InsWhileConvertingExcelToPdf executed successfully.");
        }
    }
}
