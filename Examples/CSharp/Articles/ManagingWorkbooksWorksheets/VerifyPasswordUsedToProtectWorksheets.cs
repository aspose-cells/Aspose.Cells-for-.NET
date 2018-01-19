using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class VerifyPasswordUsedToProtectWorksheets
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Load a spreadsheet
            var book = new Workbook(sourceDir + "sampleVerifyPasswordUsedToProtectWorksheets.xlsx");

            // Access the protected Worksheet
            var sheet = book.Worksheets[0];

            // Check if Worksheet is password protected
            if (sheet.Protection.IsProtectedWithPassword)
            {
                // Verify the password used to protect the Worksheet
                if (sheet.Protection.VerifyPassword("1234"))
                {
                    Console.WriteLine("Specified password has matched");
                }
                else
                {
                    Console.WriteLine("Specified password has not matched");
                }
            }

            Console.WriteLine("VerifyPasswordUsedToProtectWorksheets executed successfully.");
        }
    }
}
