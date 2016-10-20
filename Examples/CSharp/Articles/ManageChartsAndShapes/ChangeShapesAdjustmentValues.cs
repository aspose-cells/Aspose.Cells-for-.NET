using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    public class ChangeShapesAdjustmentValues
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object from source excel file
            Workbook workbook = new Workbook(dataDir + "source.xlsx");

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access first three shapes of the worksheet
            Shape shape1 = worksheet.Shapes[0];
            Shape shape2 = worksheet.Shapes[1];
            Shape shape3 = worksheet.Shapes[2];

            // Change the adjustment values of the shapes
            shape1.Geometry.ShapeAdjustValues[0].Value = 0.5d;
            shape2.Geometry.ShapeAdjustValues[0].Value = 0.8d;
            shape3.Geometry.ShapeAdjustValues[0].Value = 0.5d;

            // Save the workbook
            workbook.Save(dataDir + "output_out_.xlsx");
            // ExEnd:1
        }
    }
}
