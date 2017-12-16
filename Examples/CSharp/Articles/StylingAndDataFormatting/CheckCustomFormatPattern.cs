using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.StylingAndDataFormatting
{
    class CheckCustomFormatPattern
    {
        public static void Run()
        {
            // Create an instance of Workbook class
            Workbook book = new Workbook();

            // Setting this property to true will make Aspose.Cells to throw exception
            // when invalid custom number format is assigned to Style.Custom property
            book.Settings.CheckCustomNumberFormat = true;

            // Access first worksheet
            Worksheet sheet = book.Worksheets[0];

            // Access cell A1 and put some number to it
            Cell cell = sheet.Cells["A1"];
            cell.PutValue(2347);

            // Access cell's style and set its Style.Custom property
            Style style = cell.GetStyle();

            // This line will throw exception if Workbook.Settings.CheckCustomNumberFormat is set to true
            style.Custom = "ggg @ fff"; //Invalid custom number format
        
        }
    }
}
