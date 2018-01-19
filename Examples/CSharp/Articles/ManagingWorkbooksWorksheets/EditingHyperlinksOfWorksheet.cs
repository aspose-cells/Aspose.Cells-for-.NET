using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class EditingHyperlinksOfWorksheet
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            Workbook workbook = new Workbook(sourceDir + "sampleEditingHyperlinksOfWorksheet.xlsx");

            Worksheet worksheet = workbook.Worksheets[0];

            for (int i = 0; i < worksheet.Hyperlinks.Count; i++)
            {
                Hyperlink hl = worksheet.Hyperlinks[i];
                hl.Address = "http://www.aspose.com";

                hl.TextToDisplay += "_Modified";
            }

            workbook.Save(outputDir + "outputEditingHyperlinksOfWorksheet.xlsx");

            Console.WriteLine("EditingHyperlinksOfWorksheet executed successfully.");
        }
    }
}
