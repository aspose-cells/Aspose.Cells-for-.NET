using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.HTML
{
    class GetHTML5StringFromCell
    {
        public static void Main()
        {
            //Create workbook.
            Workbook wb = new Workbook();

            //Access first worksheet.
            Worksheet ws = wb.Worksheets[0];

            //Access cell A1 and put some text inside it.
            Cell cell = ws.Cells["A1"];
            cell.PutValue("This is some text.");

            //Get the Normal and Html5 strings.
            string strNormal = cell.GetHtmlString(false);
            string strHtml5 = cell.GetHtmlString(true);

            //Print the Normal and Html5 strings on console.
            Console.WriteLine("Normal:\r\n" + strNormal);
            Console.WriteLine();
            Console.WriteLine("Html5:\r\n" + strHtml5);

            Console.WriteLine("GetHTML5StringFromCell executed successfully.");
        }
    }
}
