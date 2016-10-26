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
            // ExStart:VerifyPasswordUsedToProtectWorksheets
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create an instance of Workbook and load a spreadsheet
            var book = new Workbook(dataDir + "Sample.xlsx");

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
            // ExEnd:VerifyPasswordUsedToProtectWorksheets
        }
    }
}
