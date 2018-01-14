using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.ConvertExcelChartToImage
{
    public class ConvertingPieChartToImageFile
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open the existing excel file which contains the pie chart.
            Workbook workbook = new Workbook(sourceDir + "sampleConvertingPieChartToImageFile.xlsx");

            Worksheet ws = workbook.Worksheets[0];

            // Get the designer chart (first chart) in the first worksheet of the workbook.
            Aspose.Cells.Charts.Chart chart = ws.Charts[0];

            // Convert the chart to an image file.
            chart.ToImage(outputDir + "outputConvertingPieChartToImageFile.emf", System.Drawing.Imaging.ImageFormat.Emf);

            Console.WriteLine("ConvertingPieChartToImageFile executed successfully.");
        }
    }
}
