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
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook object
            Workbook workbook = new Workbook(dataDir + "source.xlsx");

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
                Console.WriteLine("Theme has not foreground color defined.");
            }

            // Extract theme color applied to the bottom border of the cell if theme has border color defined
            Border bot = style.Borders[BorderType.BottomBorder];
            if (bot.ThemeColor != null)
            {
                Console.WriteLine(bot.ThemeColor.ColorType);
            }
            else
            {
                Console.WriteLine("Theme has not Border color defined.");
            }
            // ExEnd:1
        }
    }
}
