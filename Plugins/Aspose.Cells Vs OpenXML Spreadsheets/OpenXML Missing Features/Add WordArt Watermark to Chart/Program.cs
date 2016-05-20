using Aspose.Cells;
using Aspose.Cells.Drawing;

/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Cells for .NET API reference when the project is build. Please check https://docs.nuget.org/consume/nuget-faq for more information. If you do not wish to use NuGet, you can manually download Aspose.Cells for .NET API from http://www.aspose.com/downloads, install it and then add its reference to this project. For any issues, questions or suggestions please feel free to contact us using http://www.aspose.com/community/forums/default.aspx
*/
namespace Aspose.Plugins.AsposeVSOpenXML
{
    class Program
    {
        static void Main(string[] args)
        {

            string FilePath = @"..\..\..\Sample Files\";
            string FileName = FilePath + "Add WordArt Watermark to Chart.xlsx";
            
            //Open the existing excel file.
            Workbook workbook = new Workbook(FileName);

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
            workbook.Save(FileName);
        }
    }
}
