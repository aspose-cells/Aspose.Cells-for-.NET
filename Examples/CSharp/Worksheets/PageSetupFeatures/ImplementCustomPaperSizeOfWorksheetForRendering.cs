using System.IO;
using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Worksheets.PageSetupFeatures
{
    public class ImplementCustomPaperSizeOfWorksheetForRendering
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Create workbook object
            Workbook wb = new Workbook();

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Set custom paper size in unit of inches
            ws.PageSetup.CustomPaperSize(6, 4);

            //Access cell B4
            Cell b4 = ws.Cells["B4"];

            //Add the message in cell B4
            b4.PutValue("Pdf Page Dimensions: 6.00 x 4.00 in");

            //Save the workbook in pdf format
            wb.Save(outputDir + "outputCustomPaperSize.pdf");

        }
    }
}
