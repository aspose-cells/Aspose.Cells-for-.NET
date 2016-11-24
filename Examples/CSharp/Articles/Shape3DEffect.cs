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
            // ExStart:Shape3DEffect
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load excel file containing a shape
            Workbook wb = new Workbook(dataDir + "sample.xlsx");

            // Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            // Access first shape
            Shape sh = ws.Shapes[0];

            // Apply different three dimensional settings
            ThreeDFormat n3df = sh.ThreeDFormat;
            n3df.ContourWidth = 17;
            n3df.ExtrusionHeight = 32;

            // Save the output excel file in xlsx format
            wb.Save(dataDir + "output_out.xlsx");
            // ExEnd:Shape3DEffect
        }
    }
}
