using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.StylingAndDataFormatting
{
    public class ExtractThemeData
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            // Create workbook object
            Workbook workbook = new Workbook(sourceDir + "sampleExtractThemeData.xlsx");

            // Extract theme name applied to this workbook
            Console.WriteLine(workbook.Theme);

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access cell A1
            Cell cell = worksheet.Cells["A1"];

            // Get the style object
            Style style = cell.GetStyle();

            if (style.ForegroundThemeColor != null)
            {
                // Extract theme color applied to this cell if theme has foregroundtheme color defined
                Console.WriteLine(style.ForegroundThemeColor.ColorType);
            }
            else
            {
                Console.WriteLine("Theme has no Foreground Color defined.");
            }

            // Extract theme color applied to the bottom border of the cell if theme has border color defined
            Border bot = style.Borders[BorderType.BottomBorder];
            if (bot.ThemeColor != null)
            {
                Console.WriteLine(bot.ThemeColor.ColorType);
            }
            else
            {
                Console.WriteLine("Theme has no Border Color defined.");
            }

            Console.WriteLine("ExtractThemeData executed successfully.");
        }
    }
}
