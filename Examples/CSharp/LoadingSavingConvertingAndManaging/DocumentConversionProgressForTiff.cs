using Aspose.Cells.Drawing;
using Aspose.Cells.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.LoadingSavingConvertingAndManaging 
{
    public class DocumentConversionProgressForTiff
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            Workbook workbook = new Workbook(sourceDir + "sampleUseWorkbookRenderForImageConversion.xlsx");
            ImageOrPrintOptions opts = new ImageOrPrintOptions();
            opts.PageSavingCallback = new TestTiffPageSavingCallback();
            opts.ImageType = ImageType.Tiff;

            WorkbookRender wr = new WorkbookRender(workbook, opts);
            wr.ToImage(outputDir + "DocumentConversionProgressForTiff_out.tiff");
            // ExEnd:1

            Console.WriteLine("DocumentConversionProgressForTiff executed successfully.");
        }
    }

    // ExStart:2
    public class TestTiffPageSavingCallback : IPageSavingCallback
    {
        public void PageStartSaving(PageStartSavingArgs args)
        {
            Console.WriteLine("Start saving page index {0} of pages {1}", args.PageIndex, args.PageCount);

            //don't output pages before page index 2.
            if (args.PageIndex < 2)
            {
                args.IsToOutput = false;
            }
        }

        public void PageEndSaving(PageEndSavingArgs args)
        {
            Console.WriteLine("End saving page index {0} of pages {1}", args.PageIndex, args.PageCount);

            //don't output pages after page index 8.
            if (args.PageIndex >= 8)
            {
                args.HasMorePages = false;
            }
        }
    }
    // ExEnd:2
}
