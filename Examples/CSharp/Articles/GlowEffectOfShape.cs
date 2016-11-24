using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class GlowEffectOfShape
    {
        public static void Run()
        {
            // ExStart:GlowEffectOfShape
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load your source excel file
            Workbook wb = new Workbook(dataDir + "sample.xlsx");

            // Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            // Access first shape
            Shape sh = ws.Shapes[0];

            // Set the glow effect of the shape, Set its Size and Transparency properties
            GlowEffect ge = sh.Glow;
            ge.Size = 30;
            ge.Transparency = 0.4;

            // Save the workbook in xlsx format
            wb.Save(dataDir + "output_out.xlsx");
            // ExEnd:GlowEffectOfShape
        }
    }
}
