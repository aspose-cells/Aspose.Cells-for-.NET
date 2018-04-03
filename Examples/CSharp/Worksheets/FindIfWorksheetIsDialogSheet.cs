using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Worksheets
{
    class FindIfWorksheetIsDialogSheet
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        public static void Run()
        {
            //Load Excel file containing Dialog Sheet
            Workbook wb = new Workbook(sourceDir + "sampleFindIfWorksheetIsDialogSheet.xlsx");

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Find if the sheet type is dialog and print the message
            if (ws.Type == SheetType.Dialog)
            {
                Console.WriteLine("Worksheet is a Dialog Sheet.");
            }

            Console.WriteLine("FindIfWorksheetIsDialogSheet executed successfully.");
        }
    }

}
