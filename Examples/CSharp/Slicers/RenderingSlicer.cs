using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Slicers
{
    class RenderingSlicer 
    {        
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            // Load sample Excel file containing slicer.
            Workbook wb = new Workbook(sourceDir + "sampleRenderingSlicer.xlsx");

            // Access first worksheet.
            Worksheet ws = wb.Worksheets[0];

            // Set the print area because we want to render slicer only.
            ws.PageSetup.PrintArea = "B15:E25";

            // Specify image or print options, set one page per sheet and only area to true.
            Aspose.Cells.Rendering.ImageOrPrintOptions imgOpts = new Aspose.Cells.Rendering.ImageOrPrintOptions();
            imgOpts.HorizontalResolution = 200;
            imgOpts.VerticalResolution = 200;
            imgOpts.ImageType = Aspose.Cells.Drawing.ImageType.Png;
            imgOpts.OnePagePerSheet = true;
            imgOpts.OnlyArea = true;

            // Create sheet render object and render worksheet to image.
            Aspose.Cells.Rendering.SheetRender sr = new Aspose.Cells.Rendering.SheetRender(ws, imgOpts);
            sr.ToImage(0, outputDir + "outputRenderingSlicer.png");

            Console.WriteLine("RenderingSlicer executed successfully.");
        }

    }
}
