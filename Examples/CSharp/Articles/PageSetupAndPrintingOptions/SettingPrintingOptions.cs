using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.PageSetupAndPrintingOptions
{
    public class SettingPrintingOptions
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Open the template workbook
            Workbook workbook = new Workbook(dataDir + "PageSetup.xlsx");

            // Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            PageSetup pageSetup = worksheet.PageSetup;

            // Specifying the cells range (from A1 cell to E30 cell) of the print area
            pageSetup.PrintArea = "A1:E30";

            // Defining column numbers A & E as title columns
            pageSetup.PrintTitleColumns = "$A:$E";

            // Defining row numbers 1 as title rows
            pageSetup.PrintTitleRows = "$1:$2";

            // Allowing to print gridlines
            pageSetup.PrintGridlines = true;

            // Allowing to print row/column headings
            pageSetup.PrintHeadings = true;

            // Allowing to print worksheet in black & white mode
            pageSetup.BlackAndWhite = true;

            // Allowing to print comments as displayed on worksheet
            pageSetup.PrintComments = PrintCommentsType.PrintInPlace;

            // Allowing to print worksheet with draft quality
            pageSetup.PrintDraft = true;

            // Allowing to print cell errors as N/A
            pageSetup.PrintErrors = PrintErrorsType.PrintErrorsNA;

            // Setting the printing order of the pages to over then down
            pageSetup.Order = PrintOrderType.OverThenDown;

            // Save the workbook
            workbook.Save(dataDir + "PageSetup_Print_out.xlsx");
            // ExEnd:1
        }
    }
}
