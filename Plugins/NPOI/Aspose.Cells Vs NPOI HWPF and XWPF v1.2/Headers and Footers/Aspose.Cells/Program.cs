using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Adding a new worksheet to the Workbook object
            WorksheetCollection worksheets = workbook.Worksheets;
            Worksheet worksheet = worksheets.Add("My Worksheet");

            //Obtaining the reference of the PageSetup of the worksheet
            PageSetup pageSetup = worksheet.PageSetup;

            //Setting worksheet name at the left  header
            pageSetup.SetHeader(0, "&A");

            //Setting current date and current time at the central header
            //and changing the font of the header
            pageSetup.SetHeader(1, "&\"Times New Roman,Bold\"&D-&T");

            //Setting current file name at the right header and changing the font of the header
            pageSetup.SetHeader(2, "&\"Times New Roman,Bold\"&12&F");

            //Setting a string at the left footer and changing the font of the footer
            pageSetup.SetFooter(0, "Hello World! &\"Courier New\"&14 123");

            //Setting picture at the central footer
            pageSetup.SetFooter(1, "&G");

            workbook.Save("../../data/headerfooter.xlsx");
        }
    }
}
