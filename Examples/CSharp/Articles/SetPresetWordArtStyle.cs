using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class SetPresetWordArtStyle
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object
            Workbook wb = new Workbook();

            // Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            // Create a textbox with some text
            TextBox tb = ws.Shapes.AddTextBox(0, 0, 0, 0, 100, 700);
            tb.Text = "Aspose File Format APIs";
            tb.Font.Size = 44;

            // Sets preset WordArt style to the text of the shape.
            FontSetting fntSetting = tb.GetCharacters()[0] as FontSetting;
            fntSetting.SetWordArtStyle(PresetWordArtStyle.WordArtStyle3);

            // Save the workbook in xlsx format
            wb.Save(dataDir + "output_out.xlsx");
            // ExEnd:1
        }
    }
}
