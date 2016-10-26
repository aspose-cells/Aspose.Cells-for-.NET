using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class ShadowEffectOfShape
    {
        public static void Run()
        {
            // ExStart:ShadowEffectOfShape
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load your source excel file
            Workbook wb = new Workbook(dataDir + "sample.xlsx");

            // Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            // Access first shape
            Shape sh = ws.Shapes[0];

            // Set the shadow effect of the shape, Set its Angle, Blur, Distance and Transparency properties
            ShadowEffect se = sh.ShadowEffect;
            se.Angle = 150;
            se.Blur = 4;
            se.Distance = 45;
            se.Transparency = 0.3;

            // Save the workbook in xlsx format
            wb.Save(dataDir + "output_out_.xlsx");
            // ExEnd:ShadowEffectOfShape
        }
    }
}
