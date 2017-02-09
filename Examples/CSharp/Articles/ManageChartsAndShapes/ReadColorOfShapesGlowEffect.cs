using Aspose.Cells.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    class ReadColorOfShapesGlowEffect
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Read the source excel file
            Workbook book = new Workbook(dataDir + "sourceGlowEffectColor.xlsx");

            // Access first worksheet
            Worksheet sheet = book.Worksheets[0];

            // Access the shape
            Shape shape = sheet.Shapes[0];

            // Read the glow effect color and its various properties
            GlowEffect effect = shape.Glow;
            CellsColor color = effect.Color;
            Console.WriteLine("Color: " + color.Color);
            Console.WriteLine("ColorIndex: " + color.ColorIndex);
            Console.WriteLine("IsShapeColor: " + color.IsShapeColor);
            Console.WriteLine("Transparency: " + color.Transparency);
            Console.WriteLine("Type: " + color.Type);
            // ExEnd:1
        }
    }
}
