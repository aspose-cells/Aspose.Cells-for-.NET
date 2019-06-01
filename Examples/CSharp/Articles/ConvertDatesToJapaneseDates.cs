using System;
using System.Globalization;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    class ConvertDatesToJapaneseDates
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            LoadOptions options = new LoadOptions(LoadFormat.Xlsx);
            options.CultureInfo = new CultureInfo("ja-JP");

            Workbook workbook = new Workbook(sourceDir + "JapaneseDates.xlsx", options);

            workbook.Save(outputDir + "JapaneseDates.pdf", SaveFormat.Pdf);
            // ExEnd:1

            Console.WriteLine("ConvertDatesToJapaneseDates executed successfully.\r\n");
        }
    }
}
