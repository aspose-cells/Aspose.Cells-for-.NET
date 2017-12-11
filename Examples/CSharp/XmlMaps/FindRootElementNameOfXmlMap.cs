using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.XmlMaps
{
    public class FindRootElementNameOfXmlMap
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Load sample Excel file having Xml Map
            Workbook wb = new Workbook(sourceDir + "sampleRootElementNameOfXmlMap.xlsx");

            //Access first Xml Map inside the Workbook
            XmlMap xmap = wb.Worksheets.XmlMaps[0];

            //Print Root Element Name of Xml Map on Console
            Console.WriteLine("Root Element Name Of Xml Map: " + xmap.RootElementName);

            Console.WriteLine("FindRootElementNameOfXmlMap executed successfully.\r\n");
        }
    }
}
