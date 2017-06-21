using System.IO;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using System;

namespace Aspose.Cells.Examples.CSharp.DrawingObjects
{
    public class TilePictureAsTextureInsideShape
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Load sample Excel file
            Workbook wb = new Workbook(sourceDir + "sampleTextureFill_IsTiling.xlsx");
            
            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Access first shape inside the worksheet
            Shape sh = ws.Shapes[0];

            //Tile Picture as a Texture inside the Shape 
            sh.Fill.TextureFill.IsTiling = true;

            //Save the output Excel file
            wb.Save(outputDir + "outputTextureFill_IsTiling.xlsx");

            Console.WriteLine("TilePictureAsTextureInsideShape executed successfully.\r\n");
        }
    }

}
