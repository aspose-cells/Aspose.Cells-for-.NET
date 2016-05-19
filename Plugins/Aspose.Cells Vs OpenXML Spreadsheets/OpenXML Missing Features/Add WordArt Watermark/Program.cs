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
            string FileName = FilePath + "Add WordArt Watermark to Worksheet.xlsx";
            
            //Instantiate a new Workbook
            Workbook workbook = new Workbook();

            //Get the first default sheet
            Worksheet sheet = workbook.Worksheets[0];

            //Add Watermark
            Aspose.Cells.Drawing.Shape wordart = sheet.Shapes.AddTextEffect(MsoPresetTextEffect.TextEffect1,
            "CONFIDENTIAL", "Arial Black", 50, false, true
            , 18, 8, 1, 1, 130, 800);

            //Get the fill format of the word art
            MsoFillFormat wordArtFormat = wordart.FillFormat;

            //Set the color
            wordArtFormat.ForeColor = System.Drawing.Color.Red;

            //Set the transparency
            wordArtFormat.Transparency = 0.9;

            //Make the line invisible
            MsoLineFormat lineFormat = wordart.LineFormat;
            lineFormat.IsVisible = false;

            //Save the file
            workbook.Save(FileName);
        }
    }
}
