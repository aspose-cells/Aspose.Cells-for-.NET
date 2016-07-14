using System.IO;
using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Worksheets.PageSetupFeatures
{
    public class SetPageOrder
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Obtaining the reference of the PageSetup of the worksheet
            PageSetup pageSetup = workbook.Worksheets[0].PageSetup;

            // Setting the printing order of the pages to over then down
            pageSetup.Order = PrintOrderType.OverThenDown;

            // Save the workbook.
            workbook.Save(dataDir + "SetPageOrder_out.xls");
            // ExEnd:1
        }
    }
}
