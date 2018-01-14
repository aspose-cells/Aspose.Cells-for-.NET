using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.ConvertExcelChartToImage
{
    public class ConvertingColumnChartToImage
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open the existing excel file which contains the column chart.
            Workbook workbook = new Workbook(sourceDir + "sampleConvertingColumnChartToImage.xlsx");

            Worksheet ws = workbook.Worksheets[0];

            // Get the designer chart (first chart) in the first worksheet of the workbook.
            Aspose.Cells.Charts.Chart chart = ws.Charts[0];

            // Convert the chart to an image file.
            chart.ToImage(outputDir + "outputConvertingColumnChartToImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

            Console.WriteLine("ConvertingColumnChartToImage executed successfully.");
        }
    }
}
