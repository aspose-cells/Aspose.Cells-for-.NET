using System.IO;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using System;

namespace Aspose.Cells.Examples.CSharp.DrawingObjects
{
    public class SendShapeFrontOrBackInWorksheet
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Load source Excel file
            Workbook wb = new Workbook(sourceDir + "sampleToFrontOrBack.xlsx");

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Access first and fourth shape
            Shape sh1 = ws.Shapes[0];
            Shape sh4 = ws.Shapes[3];

            //Print the Z-Order position of the shape
            Console.WriteLine("Z-Order Shape 1: " + sh1.ZOrderPosition);

            //Send this shape to front
            sh1.ToFrontOrBack(2);

            //Print the Z-Order position of the shape
            Console.WriteLine("Z-Order Shape 4: " + sh4.ZOrderPosition);

            //Send this shape to back
            sh4.ToFrontOrBack(-2);

            //Save the output Excel file
            wb.Save(outputDir + "outputToFrontOrBack.xlsx");

            Console.WriteLine("SendShapeFrontOrBackInWorksheet executed successfully.\r\n");
        }
    }

}
