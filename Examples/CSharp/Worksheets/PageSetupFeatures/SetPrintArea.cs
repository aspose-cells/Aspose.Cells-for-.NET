using System.IO;
using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Worksheets.PageSetupFeatures
{
    public class SetPrintArea
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

            // Specifying the cells range (from A1 cell to T35 cell) of the print area
            pageSetup.PrintArea = "A1:T35";

            // Save the workbook.
            workbook.Save(dataDir + "SetPrintArea_out.xls");
            // ExEnd:1
        }
    }
}
