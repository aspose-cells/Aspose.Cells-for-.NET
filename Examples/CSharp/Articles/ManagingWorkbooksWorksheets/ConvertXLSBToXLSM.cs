using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class ConvertXLSBToXLSM
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open workbook
            Workbook workbook = new Workbook(sourceDir + "sampleConvertXLSBToXLSM.xlsb");

            // Save Workbook to XLSM format
            workbook.Save(outputDir + "outputConvertXLSBToXLSM.xlsm", SaveFormat.Xlsm);

            Console.WriteLine("ConvertXLSBToXLSM executed successfully.");
        }
    }
}
