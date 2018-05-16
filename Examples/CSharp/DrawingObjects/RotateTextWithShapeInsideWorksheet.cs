using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.DrawingObjects
{
    class RotateTextWithShapeInsideWorksheet
    { 
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            //Load sample Excel file.
            Workbook wb = new Workbook(sourceDir + "sampleRotateTextWithShapeInsideWorksheet.xlsx");

            //Access first worksheet.
            Worksheet ws = wb.Worksheets[0];

            //Access cell B4 and add message inside it.
            Cell b4 = ws.Cells["B4"];
            b4.PutValue("Text is not rotating with shape because RotateTextWithShape is false.");

            //Access first shape.
            Shape sh = ws.Shapes[0];

            //Access shape text alignment.
            Aspose.Cells.Drawing.Texts.ShapeTextAlignment shapeTextAlignment = sh.TextBody.TextAlignment;

            //Do not rotate text with shape by setting RotateTextWithShape as false.
            shapeTextAlignment.RotateTextWithShape = false;

            //Save the output Excel file.
            wb.Save(outputDir + "outputRotateTextWithShapeInsideWorksheet.xlsx");

            Console.WriteLine("RotateTextWithShapeInsideWorksheet executed successfully.");
        }
    }
}
