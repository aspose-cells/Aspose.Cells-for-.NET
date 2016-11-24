using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class OdsFileSaveOptions
    {
        public static void Run()
        {
            // ExStart:SaveODSFileinODF11and12Specifications
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook
            Workbook workbook = new Workbook();

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Put some value in cell A1
            Cell cell = worksheet.Cells["A1"];
            cell.PutValue("Welcome to Aspose!");

            // Save ODS in ODF 1.2 version which is default
            OdsSaveOptions options = new OdsSaveOptions();
            workbook.Save(dataDir + "ODF1.2_out.ods", options);

            // Save ODS in ODF 1.1 version
            options.IsStrictSchema11 = true;
            workbook.Save(dataDir + "ODF1.1_out.ods", options);
            // ExEnd:SaveODSFileinODF11and12Specifications
        }
    }
}
