using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.DrawingObjects
{
    class SpecifyFarEastAndLatinNameOfFontInTextOptionsOfShape 
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            // Create empty workbook.
            Workbook wb = new Workbook();

            // Access first worksheet.
            Worksheet ws = wb.Worksheets[0];

            // Add textbox inside the worksheet.
            int idx = ws.TextBoxes.Add(5, 5, 50, 200);
            Aspose.Cells.Drawing.TextBox tb = ws.TextBoxes[idx];

            // Set the text of the textbox.
            tb.Text = "こんにちは世界";

            // Specify the Far East and Latin name of the font.
            tb.TextOptions.LatinName = "Comic Sans MS";
            tb.TextOptions.FarEastName = "KaiTi";

            // Save the output Excel file.
            wb.Save(outputDir + "outputSpecifyFarEastAndLatinNameOfFontInTextOptionsOfShape.xlsx", SaveFormat.Xlsx);

            Console.WriteLine("SpecifyFarEastAndLatinNameOfFontInTextOptionsOfShape executed successfully.");
        }
    }
}
