using Aspose.Cells.ODS;
using System;
using System.Drawing;
using System.IO;

namespace Aspose.Cells.Examples.CSharp.Worksheets
{
    class ReadODSBackground
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Load source Excel file
            Workbook workbook = new Workbook(sourceDir + "GraphicBackground.ods");

            //Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            ODSPageBackground background = worksheet.PageSetup.ODSPageBackground;

            Console.WriteLine("Background Type: " + background.Type.ToString());
            Console.WriteLine("Backgorund Position: " + background.GraphicPositionType.ToString());

            //Save background image
            Bitmap image = new Bitmap(new MemoryStream(background.GraphicData));
            image.Save(outputDir + "background.jpg");
            // ExEnd:1

            Console.WriteLine("ReadODSBackground executed successfully.");
        }
    }
}
