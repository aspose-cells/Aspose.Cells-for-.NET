using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.LoadingSavingConvertingAndManaging 
{
    public class ExportCommentsWhileSavingExcelFileToHtml 
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Load sample Excel file
            Workbook wb = new Workbook(sourceDir + "sampleExportCommentsHTML.xlsx");

            //Export comments - set IsExportComments property to true
            HtmlSaveOptions opts = new HtmlSaveOptions();
            opts.IsExportComments = true;

            //Save the Excel file to HTML
            wb.Save(outputDir + "outputExportCommentsHTML.html", opts);
           
            Console.WriteLine("ExportCommentsWhileSavingExcelFileToHtml executed successfully.\r\n");
        }
    }
}
