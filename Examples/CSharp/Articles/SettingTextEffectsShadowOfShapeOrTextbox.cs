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
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create workbook object
            Workbook wb = new Workbook();

            // Access first worksheet
            Worksheet ws = wb.Worksheets[0];

            // Add text box with these dimensions
            TextBox tb = ws.Shapes.AddTextBox(2, 0, 2, 0, 100, 400);

            // Set the text of the textbox
            tb.Text = "This text has the following settings.\n\nText Effects > Shadow > Offset Bottom";            

            // Set the font color and size of the textbox
            tb.Font.Color = Color.Red;
            tb.Font.Size = 16;

            // Save the output file
            wb.Save(outputDir + "outputSettingTextEffectsShadowOfShapeOrTextbox.xlsx", SaveFormat.Xlsx);

            Console.WriteLine("SettingTextEffectsShadowOfShapeOrTextbox executed successfully.");
        }
    }
}