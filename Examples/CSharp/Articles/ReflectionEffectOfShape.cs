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
            // ExStart:ReflactionEffectOfShape
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load your source excel file
            Workbook wb = new Workbook(dataDir + "sample.xlsx");

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
            wb.Save(dataDir + "output_out_.xlsx");
            // ExEnd:ReflactionEffectOfShape
        }
    }
}
