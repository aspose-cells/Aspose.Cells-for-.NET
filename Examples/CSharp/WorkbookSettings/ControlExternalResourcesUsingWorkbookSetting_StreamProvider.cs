using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Aspose.Cells.Rendering;
using System.Drawing.Imaging;

namespace Aspose.Cells.Examples.CSharp.WorkbookSettings
{
    class ControlExternalResourcesUsingWorkbookSetting_StreamProvider
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        //Implementation of IStreamProvider
        class SP : IStreamProvider
        {
            public void CloseStream(StreamProviderOptions options)
            {

            }

            public void InitStream(StreamProviderOptions options)
            {
                //string sourceDir = RunExamples.Get_SourceDirectory();

                //Open the filestream of Aspose Logo and assign it to StreamProviderOptions.Stream property
                FileStream fi = new FileStream(sourceDir + "sampleControlExternalResourcesUsingWorkbookSetting_StreamProvider.png", FileMode.OpenOrCreate, FileAccess.Read);
                options.Stream = fi;
            }
        }
        public static void Run()
        {
            //Load sample Excel file containing the external resource e.g. linked image etc.
            Workbook wb = new Workbook(sourceDir + "sampleControlExternalResourcesUsingWorkbookSetting_StreamProvider.xlsx");

            //Provide your implementation of IStreamProvider
            wb.Settings.StreamProvider = new SP();

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Specify image or print options, we need one page per sheet and png output
            ImageOrPrintOptions opts = new ImageOrPrintOptions();
            opts.OnePagePerSheet = true;
            opts.ImageType = Drawing.ImageType.Png;

            //Create sheet render by passing required parameters
            SheetRender sr = new SheetRender(ws, opts);

            //Convert your entire worksheet into png image
            sr.ToImage(0, outputDir + "outputControlExternalResourcesUsingWorkbookSetting_StreamProvider.png");

            Console.WriteLine("ControlExternalResourcesUsingWorkbookSetting_StreamProvider executed successfully.");
        }
    }
}
