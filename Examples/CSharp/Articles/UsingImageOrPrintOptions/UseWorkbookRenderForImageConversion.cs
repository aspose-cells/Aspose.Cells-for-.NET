using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Rendering;
using System.Drawing.Imaging;

namespace Aspose.Cells.Examples.CSharp.Articles.UsingImageOrPrintOptions
{
    public class UseWorkbookRenderForImageConversion
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook(sourceDir + "sampleUseWorkbookRenderForImageConversion.xlsx");

            ImageOrPrintOptions opts = new ImageOrPrintOptions();
            opts.ImageType = Drawing.ImageType.Tiff;

            WorkbookRender wr = new WorkbookRender(wb, opts);
            wr.ToImage(outputDir + "outputUseWorkbookRenderForImageConversion.tiff");
            // ExEnd:1

            Console.WriteLine("UseWorkbookRenderForImageConversion executed successfully.");
        }
    }
}
