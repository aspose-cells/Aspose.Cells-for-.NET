using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Rendering
{
    class AvoidBlankPageInOutputPdfWhenThereIsNothingToPrint
    {
        public static void Main()
        {
            //Create empty workbook.
            Workbook wb = new Workbook();

            //Create Pdf save options.
            PdfSaveOptions opts = new PdfSaveOptions();

            //Default value of OutputBlankPageWhenNothingToPrint is true.
            //Setting false means - Do not output blank page when there is nothing to print.
            opts.OutputBlankPageWhenNothingToPrint = false;

            //Save workbook to Pdf format, it will throw exception because workbook has nothing to print.
            MemoryStream ms = new MemoryStream();

            try
            {
                //Save to Pdf format. It will throw exception.
                wb.Save(ms, opts);
            }
            catch (Exception ex)
            {
                Console.Write("Exception Message: " + ex.Message + "\r\n");
            }

            Console.WriteLine("AvoidBlankPageInOutputPdfWhenThereIsNothingToPrint executed successfully.");
        }
    }
}
