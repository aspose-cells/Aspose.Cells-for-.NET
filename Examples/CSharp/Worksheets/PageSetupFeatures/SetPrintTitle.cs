using System.IO;
using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Worksheets.PageSetupFeatures
{
    public class SetPrintTitle
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Obtaining the reference of the PageSetup of the worksheet
            Aspose.Cells.PageSetup pageSetup = workbook.Worksheets[0].PageSetup;

            // Defining column numbers A & B as title columns
            pageSetup.PrintTitleColumns = "$A:$B";

            // Defining row numbers 1 & 2 as title rows
            pageSetup.PrintTitleRows = "$1:$2";

            // Save the workbook.
            workbook.Save(dataDir + "SetPrintTitle_out.xls");
            // ExEnd:1
        }
    }
}
