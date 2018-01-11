using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ReflactionEffectOfShape
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Load your source excel file
            Workbook wb = new Workbook(sourceDir + "sampleReflactionEffectOfShape.xlsx");

            // Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            // Access first shape
            Shape sh = ws.Shapes[0];

            // Set the reflection effect of the shape, set its Blur, Size, Transparency and Distance properties
            ReflectionEffect re = sh.Reflection;
            re.Blur = 30;
            re.Size = 90;
            re.Transparency = 0;
            re.Distance = 80;

            // Save the workbook in xlsx format
            wb.Save(outputDir + "outputReflactionEffectOfShape.xlsx");

            Console.WriteLine("ReflactionEffectOfShape executed successfully.");
        }
    }
}
