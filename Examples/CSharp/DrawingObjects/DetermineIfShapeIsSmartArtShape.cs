using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.DrawingObjects
{
    class DetermineIfShapeIsSmartArtShape
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Load the sample smart art shape - Excel file
            Workbook wb = new Workbook(sourceDir + "sampleSmartArtShape.xlsx");

            //Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            //Access first shape
            Shape sh = ws.Shapes[0];

            //Determine if shape is smart art
            Console.WriteLine("Is Smart Art Shape: " + sh.IsSmartArt);

            Console.WriteLine("DetermineIfShapeIsSmartArtShape executed successfully.\r\n");
        }
    }
}
