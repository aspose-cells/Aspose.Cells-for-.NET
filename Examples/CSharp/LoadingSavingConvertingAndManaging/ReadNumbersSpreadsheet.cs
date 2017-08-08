using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.LoadingSavingConvertingAndManaging
{
    public class ReadNumbersSpreadsheet
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Specify load options, we want to load Numbers spreadsheet
            LoadOptions opts = new LoadOptions(LoadFormat.Numbers);

            //Load the Numbers spreadsheet in workbook with above load options
            Workbook wb = new Workbook(sourceDir + "sampleNumbersByAppleInc.numbers", opts);

            //Save the workbook to pdf format
            wb.Save(outputDir + "outputNumbersByAppleInc.pdf", SaveFormat.Pdf);

            Console.WriteLine("ReadNumbersSpreadsheet executed successfully.\r\n");
        }
    }
}
