using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    class RemoveUnusedStyles
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load template excel file containing unused styles
            Workbook workbook = new Workbook(dataDir + "Template-With-Unused-Custom-Style.xlsx");

            // Remove all unused styles inside the template this will also remove AsposeStyle which is an unused style inside the template
            workbook.RemoveUnusedStyles();

            // Save the file
            workbook.Save(dataDir + "output_out_.xlsx");
            // ExEnd:1
        }
    }
}
