using System.IO;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using System;
namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class AddWordArtWatermarkToWorksheet
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiate a new Workbook
            Workbook workbook = new Workbook();

            // Get the first default sheet
            Worksheet sheet = workbook.Worksheets[0];

            // Add Watermark
            Aspose.Cells.Drawing.Shape wordart = sheet.Shapes.AddTextEffect(MsoPresetTextEffect.TextEffect1,
            "CONFIDENTIAL", "Arial Black", 50, false, true
            , 18, 8, 1, 1, 130, 800);

            // Get the fill format of the word art
           FillFormat wordArtFormat = wordart.Fill;            

            // Set the transparency
            wordArtFormat.Transparency = 0.9;

            // Make the line invisible
            LineFormat lineFormat = wordart.Line;          

            // Save the file
            workbook.Save(outputDir + "outputAddWordArtWatermarkToWorksheet.xlsx");

            Console.WriteLine("AddWordArtWatermarkToWorksheet executed successfully.\r\n");
        }
    }
}
