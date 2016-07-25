using System.IO;
using System.Drawing;
using System;
using Aspose.Cells;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class SettingTextEffectsShadowOfShapeOrTextbox
    {
        public static void Run()
        {
            // ExStart:SettingTextEffectsShadowOfShapeOrTextbox
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object
            Workbook wb = new Workbook();

            // Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            // Add text box with these dimensions
            TextBox tb = ws.Shapes.AddTextBox(2, 0, 2, 0, 100, 400);

            // Set the text of the textbox
            tb.Text = "This text has the following settings.\n\nText Effects > Shadow > Offset Bottom";

            // Set all the text runs shadow to preset offset bottom
            for (int i = 0; i < tb.TextBody.Count; i++)
            {
                tb.TextBody[i].ShapeFont.FillFormat.ShadowEffect.PresetType = PresetShadowType.OffsetBottom;
            }

            // Set the font color and size of the textbox
            tb.Font.Color = Color.Red;
            tb.Font.Size = 16;

            // Save the output file
            wb.Save(dataDir + "SettingTextEffectsShadowOfShapeOrTextbox_out_.xlsx", SaveFormat.Xlsx);
            // ExEnd:SettingTextEffectsShadowOfShapeOrTextbox
        }
    }
}