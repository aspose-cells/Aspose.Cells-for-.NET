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
            // ExStart:ImportXmlDataIntoWorkbook
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create a workbook
            Workbook workbook = new Workbook();

            // URL that contains your XML data for mapping
            string XML = "http://www.aspose.com/docs/download/attachments/434475650/sampleXML.txt";

            // Import your XML Map data starting from cell A1
            workbook.ImportXml(XML, "Sheet1", 0, 0);

            // Save workbook
            workbook.Save(dataDir + "output_out_.xlsx");
            // ExEnd:ImportXmlDataIntoWorkbook
        }
    }
}
