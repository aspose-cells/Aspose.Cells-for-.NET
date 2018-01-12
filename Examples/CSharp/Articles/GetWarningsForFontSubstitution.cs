using System;
using System.IO;
using Aspose.Cells;
using System.Diagnostics;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class GetWarningsForFontSubstitution : IWarningCallback
    {
        public void Warning(WarningInfo info)
        {
            if (info.WarningType == WarningType.FontSubstitution)
            {
                Console.WriteLine("WARNING INFO: " + info.Description);
                Debug.WriteLine("WARNING INFO: " + info.Description);
            }
        }

        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            Workbook workbook = new Workbook(sourceDir + "sampleGetWarningsForFontSubstitution.xlsx");

            PdfSaveOptions options = new PdfSaveOptions();
            options.WarningCallback = new GetWarningsForFontSubstitution();

            workbook.Save(outputDir + "outputGetWarningsForFontSubstitution.pdf", options);

            Console.WriteLine("GetWarningsForFontSubstitution executed successfully.");
        }
    }    
}



            
      
