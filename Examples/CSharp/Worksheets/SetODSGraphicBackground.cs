using Aspose.Cells.Ods;
using System;
using System.IO;

namespace Aspose.Cells.Examples.CSharp.Worksheets
{
    class SetODSGraphicBackground
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            worksheet.Cells[0, 0].Value = 1;
            worksheet.Cells[1, 0].Value = 2;
            worksheet.Cells[2, 0].Value = 3;
            worksheet.Cells[3, 0].Value = 4;
            worksheet.Cells[4, 0].Value = 5;
            worksheet.Cells[5, 0].Value = 6;
            worksheet.Cells[0, 1].Value = 7;
            worksheet.Cells[1, 1].Value = 8;
            worksheet.Cells[2, 1].Value = 9;
            worksheet.Cells[3, 1].Value = 10;
            worksheet.Cells[4, 1].Value = 11;
            worksheet.Cells[5, 1].Value = 12;

            OdsPageBackground background = worksheet.PageSetup.ODSPageBackground;

            background.Type = OdsPageBackgroundType.Graphic;
            background.GraphicData = File.ReadAllBytes(sourceDir + "background.jpg");
            background.GraphicType = OdsPageBackgroundGraphicType.Area;

            workbook.Save(outputDir + "GraphicBackground.ods");
            // ExEnd:1

            Console.WriteLine("SetODSGraphicBackground executed successfully.");
        }
    }
}
