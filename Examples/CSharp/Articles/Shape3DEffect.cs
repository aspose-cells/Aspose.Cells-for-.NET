using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class Shape3DEffect
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Load excel file containing a shape
            Workbook wb = new Workbook(sourceDir + "sampleShape3DEffect.xlsx");

            // Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            // Access first shape
            Shape sh = ws.Shapes[0];

            // Apply different three dimensional settings
            ThreeDFormat n3df = sh.ThreeDFormat;
            n3df.ContourWidth = 17;
            n3df.ExtrusionHeight = 32;

            // Save the output excel file in xlsx format
            wb.Save(outputDir + "outputShape3DEffect.xlsx");

            Console.WriteLine("Shape3DEffect executed successfully.");
        }
    }
}
