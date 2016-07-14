using System.IO;
using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Worksheets.PageSetupFeatures
{
    public class SetMargins
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create a workbook object
            Workbook workbook = new Workbook();

            // Get the worksheets in the workbook
            WorksheetCollection worksheets = workbook.Worksheets;

            // Get the first (default) worksheet
            Worksheet worksheet = worksheets[0];

            // Get the pagesetup object
            PageSetup pageSetup = worksheet.PageSetup;

            // Set bottom,left,right and top page margins
            pageSetup.BottomMargin = 2;
            pageSetup.LeftMargin = 1;
            pageSetup.RightMargin = 1;
            pageSetup.TopMargin = 3;

            // Save the Workbook.
            workbook.Save(dataDir + "SetMargins_out.xls");
            // ExEnd:1
        }
        public static void CenterOnPage()
        {
            // ExStart:CenterOnPage
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create a workbook object
            Workbook workbook = new Workbook();

            // Get the worksheets in the workbook
            WorksheetCollection worksheets = workbook.Worksheets;

            // Get the first (default) worksheet
            Worksheet worksheet = worksheets[0];

            // Get the pagesetup object
            PageSetup pageSetup = worksheet.PageSetup;

            // Specify Center on page Horizontally and Vertically
            pageSetup.CenterHorizontally = true;
            pageSetup.CenterVertically = true;

            // Save the Workbook.
            workbook.Save(dataDir + "CenterOnPage_out.xls");
            // ExEnd:CenterOnPage
        }
        public static void HeaderAndFooterMargins()
        {
            // ExStart:HeaderAndFooterMargins
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create a workbook object
            Workbook workbook = new Workbook();

            // Get the worksheets in the workbook
            WorksheetCollection worksheets = workbook.Worksheets;

            // Get the first (default) worksheet
            Worksheet worksheet = worksheets[0];

            // Get the pagesetup object
            PageSetup pageSetup = worksheet.PageSetup;

            // Specify Header / Footer margins
            pageSetup.HeaderMargin = 2;
            pageSetup.FooterMargin = 2;

            // Save the Workbook.
            workbook.Save(dataDir + "CenterOnPage_out.xls");
            // ExEnd:HeaderAndFooterMargins
        }
    }
}
