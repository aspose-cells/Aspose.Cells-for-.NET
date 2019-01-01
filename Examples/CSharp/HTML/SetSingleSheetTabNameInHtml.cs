using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.HTML
{
    class SetSingleSheetTabNameInHtml
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            // Load the sample Excel file containing single sheet only
            Workbook wb = new Workbook(sourceDir + "sampleSingleSheet.xlsx");

            // Specify HTML save options
            Aspose.Cells.HtmlSaveOptions options = new Aspose.Cells.HtmlSaveOptions();

            // Set optional settings if required
            options.Encoding = System.Text.Encoding.UTF8;
            options.ExportImagesAsBase64 = true;
            options.ExportGridLines = true;
            options.ExportSimilarBorderStyle = true;
            options.ExportBogusRowData = true;
            options.ExcludeUnusedStyles = true;
            options.ExportHiddenWorksheet = true;

            //Save the workbook in Html format with specified Html Save Options
            wb.Save(outputDir + "outputSampleSingleSheet.htm", options);
            Console.WriteLine("SetSingleSheetTabNameInHtml executed successfully.");
        }
    }

}
