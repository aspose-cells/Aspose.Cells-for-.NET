using System;
using System.IO;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ConvertXLSFileToPDF
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open the template excel file
            Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook(sourceDir + "sampleConvertXLSFileToPDF.xlsx");

            // Save the pdf file.
            wb.Save(outputDir + "outputConvertXLSFileToPDF.pdf", SaveFormat.Pdf);

            Console.WriteLine("ConvertXLSFileToPDF executed successfully.\r\n");
        }

    }
}
