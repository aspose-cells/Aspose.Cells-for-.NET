using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.StylingAndDataFormatting
{
    public class DisplayBulletsInCellUsingHtml
    {
        public static void Run()
        {
            // ExStart:DisplayBulletsInCellUsingHtml
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object
            Workbook workbook = new Workbook();

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access cell A1
            Cell cell = worksheet.Cells["A1"];

            // Set the HTML string
            cell.HtmlString = "<font style='font-family:Arial;font-size:10pt;color:#666666;vertical-align:top;text-align:left;'>Text 1 </font><font style='font-family:Wingdings;font-size:8.0pt;color:#009DD9;mso-font-charset:2;'>l</font><font style='font-family:Arial;font-size:10pt;color:#666666;vertical-align:top;text-align:left;'> Text 2 </font><font style='font-family:Wingdings;font-size:8.0pt;color:#009DD9;mso-font-charset:2;'>l</font><font style='font-family:Arial;font-size:10pt;color:#666666;vertical-align:top;text-align:left;'> Text 3 </font><font style='font-family:Wingdings;font-size:8.0pt;color:#009DD9;mso-font-charset:2;'>l</font><font style='font-family:Arial;font-size:10pt;color:#666666;vertical-align:top;text-align:left;'> Text 4 </font>";

            // Auto fit the Columns
            worksheet.AutoFitColumns();

            // Save the workbook
            workbook.Save(dataDir + "BulletsInCells_out.xlsx");
            // ExEnd:DisplayBulletsInCellUsingHtml
        }
    }
}
