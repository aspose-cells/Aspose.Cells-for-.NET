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
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // ExStart:1
            // Create workbook object
            Workbook workbook = new Workbook();

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Create a textbox with some text
            TextBox textbox = worksheet.Shapes.AddTextBox(0, 0, 0, 0, 100, 700);
            textbox.Text = "Aspose File Format APIs";
            textbox.Font.Size = 44;

            // Sets preset WordArt style to the text of the shape.
            FontSetting fntSetting = textbox.GetCharacters()[0] as FontSetting;
            fntSetting.SetWordArtStyle(PresetWordArtStyle.WordArtStyle3);

            // Save the workbook in xlsx format
            workbook.Save(outputDir + "outputSetPresetWordArtStyle.xlsx");
            // ExEnd:1

            Console.WriteLine("SetPresetWordArtStyle executed successfully.");
        }
    }
}
