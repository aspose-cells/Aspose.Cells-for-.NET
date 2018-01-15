using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    public class AddWordArtWatermarkToChart
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Open the existing excel file.
            Workbook workbook = new Workbook(sourceDir + "sampleAddWordArtWatermarkToChart.xlsx");

            // Get the chart in the first worksheet.
            Aspose.Cells.Charts.Chart chart = workbook.Worksheets[0].Charts[0];

            // Add a WordArt watermark (shape) to the chart's plot area.
            Aspose.Cells.Drawing.Shape wordart = chart.Shapes.AddTextEffectInChart(MsoPresetTextEffect.TextEffect2,
            "CONFIDENTIAL", "Arial Black", 66, false, false, 1200, 500, 2000, 3000);

            // Get the shape's fill format.
            FillFormat wordArtFormat = wordart.Fill;

            // Set the transparency.
            wordArtFormat.Transparency = 0.9;

            // Get the line format.
            LineFormat lineFormat = wordart.Line;

            // Set Line format to invisible.
            lineFormat.Weight = 0.0;

            // Save the excel file.
            workbook.Save(outputDir + "outputAddWordArtWatermarkToChart.xlsx");

            Console.WriteLine("AddWordArtWatermarkToChart executed successfully.");
        }
    }
}
