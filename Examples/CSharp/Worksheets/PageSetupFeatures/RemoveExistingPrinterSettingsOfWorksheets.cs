using System.IO;
using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Worksheets.PageSetupFeatures
{
    public class RemoveExistingPrinterSettingsOfWorksheets
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Load source Excel file
            Workbook wb = new Workbook(sourceDir + "sampleRemoveExistingPrinterSettingsOfWorksheets.xlsx");

            //Get the sheet counts of the workbook
            int sheetCount = wb.Worksheets.Count;

            //Iterate all sheets
            for (int i = 0; i < sheetCount; i++)
            {
                //Access the i-th worksheet
                Worksheet ws = wb.Worksheets[i];

                //Access worksheet page setup
                PageSetup ps = ws.PageSetup;

                //Check if printer settings for this worksheet exist
                if (ps.PrinterSettings != null)
                {
                    //Print the following message
                    Console.WriteLine("PrinterSettings of this worksheet exist.");

                    //Print sheet name and its paper size
                    Console.WriteLine("Sheet Name: " + ws.Name);
                    Console.WriteLine("Paper Size: " + ps.PaperSize);

                    //Remove the printer settings by setting them null
                    ps.PrinterSettings = null;
                    Console.WriteLine("Printer settings of this worksheet are now removed by setting it null.");
                    Console.WriteLine("");
                }//if
            }//for

            //Save the workbook
            wb.Save(outputDir + "outputRemoveExistingPrinterSettingsOfWorksheets.xlsx");


        }
    }
}
