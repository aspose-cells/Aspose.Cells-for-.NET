using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class ConvertXLSBToXLSM
    {
        public static void Run()
        {
            // ExStart:ConvertXLSBRevisionToXLSM
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Open workbook
            Workbook workbook = new Workbook(dataDir + "sample.xlsb");

            // Save Workbook to XLSM format
            workbook.Save(dataDir + "output_out.xlsm", SaveFormat.Xlsm);
            // ExEnd:ConvertXLSBRevisionToXLSM
        }
    }
}
