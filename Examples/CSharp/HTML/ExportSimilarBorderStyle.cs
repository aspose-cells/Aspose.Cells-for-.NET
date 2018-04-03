using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.HTML
{
    class ExportSimilarBorderStyle 
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            //Load the sample Excel file
            Workbook wb = new Workbook(sourceDir + "sampleExportSimilarBorderStyle.xlsx");

            //Specify Html Save Options - Export Similar Border Style
            HtmlSaveOptions opts = new HtmlSaveOptions();
            opts.ExportSimilarBorderStyle = true;

            //Save the workbook in Html format with specified Html Save Options
            wb.Save(outputDir + "outputExportSimilarBorderStyle.html", opts);

            Console.WriteLine("ExportSimilarBorderStyle executed successfully.");
        }
    }

}
