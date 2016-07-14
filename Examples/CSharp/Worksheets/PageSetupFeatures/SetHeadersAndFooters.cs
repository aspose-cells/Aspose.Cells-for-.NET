using System.IO;
using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Worksheets.PageSetupFeatures
{
    public class SetHeadersAndFooters
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiating a Workbook object
            Workbook excel = new Workbook();

            // Obtaining the reference of the PageSetup of the worksheet
            PageSetup pageSetup = excel.Worksheets[0].PageSetup;

            // Setting worksheet name at the left section of the header
            pageSetup.SetHeader(0, "&A");

            // Setting current date and current time at the centeral section of the header
            // and changing the font of the header
            pageSetup.SetHeader(1, "&\"Times New Roman,Bold\"&D-&T");

            // Setting current file name at the right section of the header and changing the
            // font of the header
            pageSetup.SetHeader(2, "&\"Times New Roman,Bold\"&12&F");

            // Setting a string at the left section of the footer and changing the font
            // of the footer
            pageSetup.SetFooter(0, "Hello World! &\"Courier New\"&14 123");

            // Setting the current page number at the central section of the footer
            pageSetup.SetFooter(1, "&P");

            // Setting page count at the right section of footer
            pageSetup.SetFooter(2, "&N");

            // Save the Workbook.
            excel.Save(dataDir + "SetHeadersAndFooters_out.xls");
            // ExEnd:1
        }
    }
}
