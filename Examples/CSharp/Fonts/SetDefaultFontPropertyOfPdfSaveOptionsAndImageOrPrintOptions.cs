using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Rendering;
using System.Drawing.Imaging;

namespace Aspose.Cells.Examples.CSharp.Fonts
{
    public class SetDefaultFontPropertyOfPdfSaveOptionsAndImageOrPrintOptions 
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Open an Excel file.
            Workbook workbook = new Workbook(sourceDir + "sampleSetDefaultFontPropertyOfPdfSaveOptionsAndImageOrPrintOptions.xlsx");

            //Rendering to PNG file format while setting the CheckWorkbookDefaultFont attribue to false.
            //So, "Times New Roman" font would be used for any missing (not installed) font in the workbook.
            ImageOrPrintOptions imgOpt = new ImageOrPrintOptions();
            imgOpt.ImageType = Drawing.ImageType.Png;
            imgOpt.CheckWorkbookDefaultFont = false;
            imgOpt.DefaultFont = "Times New Roman";
            SheetRender sr = new SheetRender(workbook.Worksheets[0], imgOpt);
            sr.ToImage(0, outputDir + "out1_imagePNG.png");

            //Rendering to TIFF file format while setting the CheckWorkbookDefaultFont attribue to false.
            //So, "Times New Roman" font would be used for any missing (not installed) font in the workbook.
            imgOpt.ImageType = Drawing.ImageType.Tiff;
            WorkbookRender wr = new WorkbookRender(workbook, imgOpt);
            wr.ToImage(outputDir + "out1_imageTIFF.tiff");

            //Rendering to PDF file format while setting the CheckWorkbookDefaultFont attribue to false.
            //So, "Times New Roman" font would be used for any missing (not installed) font in the workbook.
            PdfSaveOptions saveOptions = new PdfSaveOptions();
            saveOptions.DefaultFont = "Times New Roman";
            saveOptions.CheckWorkbookDefaultFont = false;
            workbook.Save(outputDir + "out1_pdf.pdf", saveOptions);

            Console.WriteLine("SetDefaultFontPropertyOfPdfSaveOptionsAndImageOrPrintOptions executed successfully.\r\n");
        }
    }
}
