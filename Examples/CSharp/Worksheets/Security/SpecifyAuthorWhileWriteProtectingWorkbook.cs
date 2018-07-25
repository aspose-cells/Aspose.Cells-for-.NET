using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Worksheets.Security
{
    class SpecifyAuthorWhileWriteProtectingWorkbook 
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            // Create empty workbook.
            Workbook wb = new Workbook();

            // Write protect workbook with password.
            wb.Settings.WriteProtection.Password = "1234";

            // Specify author while write protecting workbook.
            wb.Settings.WriteProtection.Author = "SimonAspose";

            // Save the workbook in XLSX format.
            wb.Save(outputDir + "outputSpecifyAuthorWhileWriteProtectingWorkbook.xlsx");

            Console.WriteLine("SpecifyAuthorWhileWriteProtectingWorkbook executed successfully.");
        }
    }
}
