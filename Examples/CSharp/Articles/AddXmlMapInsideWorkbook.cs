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
            // ExStart:AddXmlMapInsideWorkbook
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object
            Workbook wb = new Workbook();

            // Add xml map found inside the sample.xml inside the workbook
            wb.Worksheets.XmlMaps.Add(dataDir + "sample.xml");

            // Save the workbook in xlsx format
            wb.Save(dataDir + "output_out_.xlsx");
            // ExEnd:AddXmlMapInsideWorkbook
        }
    }
}
