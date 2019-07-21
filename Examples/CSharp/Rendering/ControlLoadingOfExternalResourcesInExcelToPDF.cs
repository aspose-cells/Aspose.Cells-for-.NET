using System.IO;

using System.Drawing;
using System.Drawing.Imaging;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Rendering;
using System;

namespace Aspose.Cells.Examples.CSharp.Rendering
{
    public class ControlLoadingOfExternalResourcesInExcelToPDF
    {
        // ExStart:1
        //Implement IStreamProvider
        class MyStreamProvider : IStreamProvider
        {
            public void CloseStream(StreamProviderOptions options)
            {
                System.Diagnostics.Debug.WriteLine("-----Close Stream-----");
            }

            public void InitStream(StreamProviderOptions options)
            {
                string sourceDir = RunExamples.Get_SourceDirectory();

                System.Diagnostics.Debug.WriteLine("-----Init Stream-----");

                //Read the new image in a memory stream and assign it to Stream property
                byte[] bts = File.ReadAllBytes(sourceDir + "newPdfSaveOptions_StreamProvider.png");
                MemoryStream ms = new MemoryStream(bts);
                options.Stream = ms;
            }
        }

        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Load source Excel file containing external image
            Workbook wb = new Workbook(sourceDir + "samplePdfSaveOptions_StreamProvider.xlsx");

            //Specify Pdf Save Options - Stream Provider
            PdfSaveOptions opts = new PdfSaveOptions();
            opts.OnePagePerSheet = true;

            wb.Settings.StreamProvider = new MyStreamProvider();

            //Save the workbook to Pdf
            wb.Save(outputDir + "outputPdfSaveOptions_StreamProvider.pdf", opts);

            Console.WriteLine("ControlLoadingOfExternalResourcesInExcelToPDF executed successfully.\r\n");
        }
        // ExEnd:1
    }

}
