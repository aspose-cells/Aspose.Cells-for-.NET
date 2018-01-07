using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class CustomizingRibbonXML
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            Workbook wb = new Workbook(sourceDir + "sampleCustomizingRibbonXML.xlsx");

            FileInfo fi = new FileInfo(sourceDir + "customUI_CustomizingRibbonXML.xml");
            StreamReader sr = fi.OpenText();
            wb.RibbonXml = sr.ReadToEnd();
            sr.Close();

            wb.Save(outputDir + "outputCustomizingRibbonXML.xlsx");

            Console.WriteLine("CustomizingRibbonXML executed successfully.");
        }
    }
}
