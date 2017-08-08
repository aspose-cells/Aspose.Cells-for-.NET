using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class DetermineIfPaperSizeOfWorksheetIsAutomatic
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();
            
            //Load the first workbook having automatic paper size false
            Workbook wb1 = new Workbook(sourceDir + "samplePageSetupIsAutomaticPaperSize-False.xlsx");

            //Load the second workbook having automatic paper size true
            Workbook wb2 = new Workbook(sourceDir + "samplePageSetupIsAutomaticPaperSize-True.xlsx");

            //Access first worksheet of both workbooks
            Worksheet ws11 = wb1.Worksheets[0];
            Worksheet ws12 = wb2.Worksheets[0];

            //Print the PageSetup.IsAutomaticPaperSize property of both worksheets
            Console.WriteLine("First Worksheet of First Workbook - IsAutomaticPaperSize: " + ws11.PageSetup.IsAutomaticPaperSize);
            Console.WriteLine("First Worksheet of Second Workbook - IsAutomaticPaperSize: " + ws12.PageSetup.IsAutomaticPaperSize);

            Console.WriteLine();
            Console.WriteLine("DetermineIfPaperSizeOfWorksheetIsAutomatic executed successfully.\r\n");
        }
    }
}