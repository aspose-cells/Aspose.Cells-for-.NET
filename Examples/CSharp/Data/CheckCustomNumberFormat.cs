using System;
using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class CheckCustomNumberFormat
    {
        public static void Run()
        {
            //Create a workbook
            Workbook wb = new Workbook();

            //Setting this property to true will make Aspose.Cells to throw exception
            //when invalid custom number format is assigned to Style.Custom property
            wb.Settings.CheckCustomNumberFormat = true;

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Access cell A1 and put some number inside it
            Cell c = ws.Cells["A1"];
            c.PutValue(2347);

            //Access cell's style and set its Style.Custom property
            Style s = c.GetStyle();
            try
            {
                //This line will throw exception if Workbook.Settings.CheckCustomNumberFormat is set to true
                s.Custom = "ggg @ fff"; //Invalid custom number format
                c.SetStyle(s);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occured. Exception: " + ex.Message);
            }

            Console.WriteLine("CheckCustomNumberFormat executed successfully.");
        }
    }
}