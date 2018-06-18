using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Fonts
{
    class SpecifyIndividualOrPrivateSetOfFontsForWorkbookRendering 
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            // Path of your custom font directory.
            string customFontsDir = sourceDir + "CustomFonts";

            // Specify individual font configs custom font directory.
            IndividualFontConfigs fontConfigs = new IndividualFontConfigs();

            // If you comment this line or if custom font directory is wrong or 
            // if it does not contain required font then output pdf will not be rendered correctly.
            fontConfigs.SetFontFolder(customFontsDir, false);

            // Specify load options with font configs.
            LoadOptions opts = new LoadOptions(LoadFormat.Xlsx);
            opts.FontConfigs = fontConfigs;

            // Load the sample Excel file with individual font configs. 
            Workbook wb = new Workbook(sourceDir + "sampleSpecifyIndividualOrPrivateSetOfFontsForWorkbookRendering.xlsx", opts);

            // Save to pdf format.
            wb.Save(outputDir + "outputSpecifyIndividualOrPrivateSetOfFontsForWorkbookRendering.pdf", SaveFormat.Pdf);

            Console.WriteLine("SpecifyIndividualOrPrivateSetOfFontsForWorkbookRendering executed successfully.");
        }
    }
}
