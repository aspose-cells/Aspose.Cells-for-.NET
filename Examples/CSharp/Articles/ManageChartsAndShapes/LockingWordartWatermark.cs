using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles.ManageChartsAndShapes
{
    public class LockingWordartWatermark
    {
        public static void Run()
        {
            // ExStart:LockingWordartWatermark
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiate a new Workbook
            Workbook workbook = new Workbook();

            // Get the first default sheet
            Worksheet sheet = workbook.Worksheets[0];

            // Add Watermark
            Shape wordart = sheet.Shapes.AddTextEffect(MsoPresetTextEffect.TextEffect1,
            "CONFIDENTIAL", "Arial Black", 50, false, true
            , 18, 8, 1, 1, 130, 800);

            // Lock Shape Aspects
            wordart.IsLocked = true;
            wordart.SetLockedProperty(ShapeLockType.Selection, true);
            wordart.SetLockedProperty(ShapeLockType.ShapeType, true);
            wordart.SetLockedProperty(ShapeLockType.Move, true);
            wordart.SetLockedProperty(ShapeLockType.Resize, true);
            wordart.SetLockedProperty(ShapeLockType.Text, true);

            // Get the fill format of the word art
            FillFormat wordArtFormat = wordart.Fill;

            // Set the color
            wordArtFormat.SetOneColorGradient(Color.Red, 0.2, GradientStyleType.Horizontal, 2);

            // Set the transparency
            wordArtFormat.Transparency = 0.9;

            // Make the line invisible
            wordart.HasLine = false;

            // Save the file
            workbook.Save(dataDir + "output_out_.xlsx");
            // ExEnd:LockingWordartWatermark
        }
    }
}
