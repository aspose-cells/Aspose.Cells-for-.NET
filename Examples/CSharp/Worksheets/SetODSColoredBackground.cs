using Aspose.Cells.Ods;
using System;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Worksheets
{
    class SetODSColoredBackground
    {
        public static void Run()
        {
            // ExStart:1
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

            background.Color = Color.Azure;
            background.Type = OdsPageBackgroundType.Color;

            workbook.Save(outputDir + "ColoredBackground.ods", SaveFormat.ODS);
            // ExEnd:1

            Console.WriteLine("SetODSColoredBackground executed successfully.");
        }
    }
}
