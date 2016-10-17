using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingWorkbooksWorksheets
{
    public class CheckIfPasswordProtected
    {
        public static void Run()
        {
            // ExStart:CheckIfPasswordProtected
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create an instance of Workbook and load a spreadsheet
            var book = new Workbook(dataDir + "sample.xlsx");

            // Access the protected Worksheet
            var sheet = book.Worksheets[0];

            // Check if Worksheet is password protected
            if (sheet.Protection.IsProtectedWithPassword)
            {
                Console.WriteLine("Worksheet is password protected");
            }
            else
            {
                Console.WriteLine("Worksheet is not password protected");
            }
            // ExEnd:CheckIfPasswordProtected
        }
    }
}
