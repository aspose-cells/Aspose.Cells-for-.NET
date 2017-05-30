using System.IO;
using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Worksheets.PageSetupFeatures
{
    public class CopyPageSetupSettingsFromSourceWorksheetToDestinationWorksheet
    {
        public static void Run()
        {
            //Create workbook
            Workbook wb = new Workbook();

            //Add two test worksheets
            wb.Worksheets.Add("TestSheet1");
            wb.Worksheets.Add("TestSheet2");

            //Access both worksheets as TestSheet1 and TestSheet2
            Worksheet TestSheet1 = wb.Worksheets["TestSheet1"];
            Worksheet TestSheet2 = wb.Worksheets["TestSheet2"];

            //Set the Paper Size of TestSheet1 to PaperA3ExtraTransverse
            TestSheet1.PageSetup.PaperSize = PaperSizeType.PaperA3ExtraTransverse;

            //Print the Paper Size of both worksheets
            Console.WriteLine("Before Paper Size: " + TestSheet1.PageSetup.PaperSize);
            Console.WriteLine("Before Paper Size: " + TestSheet2.PageSetup.PaperSize);
            Console.WriteLine();


            //Copy the PageSetup from TestSheet1 to TestSheet2
            TestSheet2.PageSetup.Copy(TestSheet1.PageSetup, new CopyOptions());

            //Print the Paper Size of both worksheets
            Console.WriteLine("After Paper Size: " + TestSheet1.PageSetup.PaperSize);
            Console.WriteLine("After Paper Size: " + TestSheet2.PageSetup.PaperSize);
            Console.WriteLine();

            Console.WriteLine("CopyPageSetupSettingsFromSourceWorksheetToDestinationWorksheet executed successfully.\r\n");
        }
    }
}
