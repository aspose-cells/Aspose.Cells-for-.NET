using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.RenderingAndPrinting
{
    public class ConvertChartToSvgImage
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create workbook object from source file
            Workbook workbook = new Workbook(sourceDir + "sampleConvertChartToSvgImage.xlsx");

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access first chart inside the worksheet
            Aspose.Cells.Charts.Chart chart = worksheet.Charts[0];

            // Set image or print options
            Aspose.Cells.Rendering.ImageOrPrintOptions opts = new Aspose.Cells.Rendering.ImageOrPrintOptions();
            opts.SaveFormat = SaveFormat.Svg;

            // Save the chart to svg format
            chart.ToImage(outputDir + "outputConvertChartToSvgImage.svg", opts);

            Console.WriteLine("ConvertChartToSvgImage executed successfully.");
        }
    }
}
