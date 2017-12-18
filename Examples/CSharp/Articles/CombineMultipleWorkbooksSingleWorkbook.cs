using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class CombineMultipleWorkbooksSingleWorkbook
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Define the first source
            // Open the first excel file.
            Workbook SourceBook1 = new Workbook(sourceDir + "sampleCombineMultipleWorkbooksSingleWorkbook_Chart.xlsx");

            // Define the second source book.
            // Open the second excel file.
            Workbook SourceBook2 = new Workbook(sourceDir + "sampleCombineMultipleWorkbooksSingleWorkbook_Image.xlsx");

            // Combining the two workbooks
            SourceBook1.Combine(SourceBook2);

            // Save the target book file.
            SourceBook1.Save(outputDir + "outputCombineMultipleWorkbooksSingleWorkbook.xlsx");

            Console.WriteLine("CombineMultipleWorkbooksSingleWorkbook executed successfully.\r\n");
        }
    }
}
