using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;
using Aspose.Cells.Drawing;

namespace Add_WordArt_Watermark_to_Chart
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate a new workbook.
            //Open the existing excel file.
            Workbook workbook = new Workbook("Watermark_Test1.xls");

            //Get the chart in the first worksheet.
            Aspose.Cells.Charts.Chart chart = workbook.Worksheets[0].Charts[0];

            //Add a WordArt watermark (shape) to the chart's plot area.
            Aspose.Cells.Drawing.Shape wordart = chart.Shapes.AddTextEffectInChart(MsoPresetTextEffect.TextEffect2,
            "CONFIDENTIAL", "Arial Black", 66, false, false, 1200, 500, 2000, 3000);

            //Get the shape's fill format.
            Aspose.Cells.Drawing.MsoFillFormat wordArtFormat = wordart.FillFormat;

            //Set the transparency.
            wordArtFormat.Transparency = 0.9;

            //Get the line format and make it invisible.
            Aspose.Cells.Drawing.MsoLineFormat lineFormat = wordart.LineFormat;
            lineFormat.IsVisible = false;

            //Save the excel file.
            workbook.Save("outWatermark_Test1.xls");
        }
    }
}
