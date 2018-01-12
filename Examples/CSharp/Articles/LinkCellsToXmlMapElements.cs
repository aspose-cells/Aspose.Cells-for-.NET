using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class LinkCellsToXmlMapElements
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Load sample workbook
            Workbook wb = new Workbook(sourceDir + "sampleLinkCellsToXmlMapElements.xlsx");

            // Access the Xml Map inside it
            XmlMap map = wb.Worksheets.XmlMaps[0];

            // Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            // Map FIELD1 and FIELD2 to cell A1 and B2
            ws.Cells.LinkToXmlMap(map.Name, 0, 0, "/root/row/FIELD1");
            ws.Cells.LinkToXmlMap(map.Name, 1, 1, "/root/row/FIELD2");

            // Map FIELD4 and FIELD5 to cell C3 and D4
            ws.Cells.LinkToXmlMap(map.Name, 2, 2, "/root/row/FIELD4");
            ws.Cells.LinkToXmlMap(map.Name, 3, 3, "/root/row/FIELD5");

            // Map FIELD7 and FIELD8 to cell E5 and F6
            ws.Cells.LinkToXmlMap(map.Name, 4, 4, "/root/row/FIELD7");
            ws.Cells.LinkToXmlMap(map.Name, 5, 5, "/root/row/FIELD8");

            // Save the workbook in xlsx format
            wb.Save(outputDir + "outputLinkCellsToXmlMapElements.xlsx");

            Console.WriteLine("LinkCellsToXmlMapElements executed successfully.");
        }
    }
}
