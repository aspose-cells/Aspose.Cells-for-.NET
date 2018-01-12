using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    class RemoveUnusedStyles
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Load template excel file containing unused styles
            Workbook workbook = new Workbook(sourceDir + "sampleRemoveUnusedStyles.xlsx");

            // Remove all unused styles inside the template this will also remove AsposeStyle which is an unused style inside the template
            workbook.RemoveUnusedStyles();

            // Save the file
            workbook.Save(outputDir + "outputRemoveUnusedStyles.xlsx");

            Console.WriteLine("RemoveUnusedStyles executed successfully.");
        }
    }
}
