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
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Create an instance of Workbook and load a spreadsheet
            var book = new Workbook(sourceDir + "sampleCheckIfPasswordProtected.xlsx");

            // Access the protected Worksheet
            var sheet = book.Worksheets[0];

            // Check if Worksheet is password protected
            if (sheet.Protection.IsProtectedWithPassword)
            {
                Console.WriteLine("Worksheet is Password Protected");
            }
            else
            {
                Console.WriteLine("Worksheet is Not Password Protected");
            }

            Console.WriteLine("CheckIfPasswordProtected executed successfully.");
        }
    }
}
