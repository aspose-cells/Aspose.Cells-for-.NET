using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class ImportXmlData
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create a workbook
            Workbook workbook = new Workbook();

            // Import your XML Map data starting from cell A1
            workbook.ImportXml(sourceDir + "sampleImportXmlData.xml", "Sheet1", 0, 0);

            // Save workbook
            workbook.Save(outputDir + "outputImportXmlData.xlsx");

            Console.WriteLine("ImportXmlData executed successfully.");
        }
    }
}
