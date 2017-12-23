using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class AddXmlMapInsideWorkbook
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create workbook object
            Workbook wb = new Workbook();

            // Add xml map found inside the sample.xml inside the workbook
            wb.Worksheets.XmlMaps.Add(sourceDir + "sampleAddXmlMapInsideWorkbook.xml");

            // Save the workbook in xlsx format
            wb.Save(outputDir + "outputAddXmlMapInsideWorkbook.xlsx");

            Console.WriteLine("AddXmlMapInsideWorkbook executed successfully.\r\n");
        }
    }
}
