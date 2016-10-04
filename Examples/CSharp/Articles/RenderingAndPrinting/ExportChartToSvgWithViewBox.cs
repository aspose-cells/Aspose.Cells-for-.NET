using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.RenderingAndPrinting
{
    public class ExportChartToSvgWithViewBox
    {
        public static void Run()
        {
            //ExStart:1

            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Create workbook object from source file
            Workbook workbook = new Workbook(dataDir + "SampleChartBook.xlsx");

            //Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Access first chart inside the worksheet
            Aspose.Cells.Charts.Chart chart = worksheet.Charts[0];

            //Set image or print options
            //with SVGFitToViewPort true
            Aspose.Cells.Rendering.ImageOrPrintOptions opts = new Aspose.Cells.Rendering.ImageOrPrintOptions();
            opts.SaveFormat = SaveFormat.SVG;
            opts.SVGFitToViewPort = true;

            //Save the chart to svg format
            chart.ToImage(dataDir + "Image_out_.svg", opts);

            //ExEnd:1
        }
    }
}