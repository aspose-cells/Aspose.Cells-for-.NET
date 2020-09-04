using System;

namespace Aspose.Cells.Examples.CSharp.LoadingSavingConvertingAndManaging
{
    public class ConvertExcelFileToPptx
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // ExStart:1
            // Open the template file
            Workbook workbook = new Workbook(sourceDir + "Book1.xlsx");

            // Save as Markdown
            workbook.Save(outputDir + "Book1.pptx", SaveFormat.Pptx);
            // ExEnd:1

            Console.WriteLine("ConvertExcelFileToPptx executed successfully.");
        }
    }
}
