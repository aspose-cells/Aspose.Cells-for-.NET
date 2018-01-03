using System;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    class ExportXmlMapFromWorkbook
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiating a Workbook object
            Workbook workbook = new Workbook(sourceDir + "sampleExportXmlMapFromWorkbook.xlsx");

            // Export all XML data from all XML Maps from the Workbook
            for (int i = 0; i < workbook.Worksheets.XmlMaps.Count; i++)
            {
                // Access the XML Map
                XmlMap map = workbook.Worksheets.XmlMaps[i];

                // Exports its XML Data to file
                workbook.ExportXml(map.Name, outputDir + map.Name + ".xml");
            }

            Console.WriteLine("ExportXmlMapFromWorkbook executed successfully.\r\n");
        }
    }
}
