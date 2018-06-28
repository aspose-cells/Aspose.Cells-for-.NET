using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.DrawingObjects
{
    class ExtractTextFromGearTypeSmartArtShape
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();

        public static void Main()
        {
            // Load sample Excel file containing gear type smart art shape.
            Workbook wb = new Workbook(sourceDir + "sampleExtractTextFromGearTypeSmartArtShape.xlsx");

            // Access first worksheet.
            Worksheet ws = wb.Worksheets[0];

            // Access first shape.
            Aspose.Cells.Drawing.Shape sh = ws.Shapes[0];

            // Get the result of gear type smart art shape in the form of group shape.
            Aspose.Cells.Drawing.GroupShape gs = sh.GetResultOfSmartArt();

            // Get the list of individual shapes consisting of group shape.
            Aspose.Cells.Drawing.Shape[] shps = gs.GetGroupedShapes();

            // Extract the text of gear type shapes and print them on console.
            for (int i = 0; i < shps.Length; i++)
            {
                Aspose.Cells.Drawing.Shape s = shps[i];

                if (s.Type == Aspose.Cells.Drawing.AutoShapeType.Gear9 || s.Type == Aspose.Cells.Drawing.AutoShapeType.Gear6)
                {
                    Console.WriteLine("Gear Type Shape Text: " + s.Text);
                }
            }//for

            Console.WriteLine("ExtractTextFromGearTypeSmartArtShape executed successfully.");
        }

    }
}
