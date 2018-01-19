using System;
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles.ModifyExistingStyle
{
    public class ModifyThroughStyleObject
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Create a workbook.
            Workbook workbook = new Workbook();

            // Create a new style object.
            Style style = workbook.CreateStyle();

            // Set the number format.
            style.Number = 14;

            // Set the font color to red color.
            style.Font.Color = System.Drawing.Color.Red;
            style.Pattern = BackgroundType.Solid;
            style.ForegroundColor = System.Drawing.Color.Yellow;

            // Name the style.
            style.Name = "MyCustomDate";

            // Get the first worksheet cells.
            Cells cells = workbook.Worksheets[0].Cells;

            // Specify the style (described above) to A1 cell.
            cells["A1"].SetStyle(style);

            // Create a range (B1:D1).
            Range range = cells.CreateRange("B6", "D10");

            // Initialize styleflag object.
            StyleFlag flag = new StyleFlag();

            // Set all formatting attributes on.
            flag.All = true;

            Style style2 = workbook.GetNamedStyle("MyCustomDate");

            // Apply the style (described above)to the range.
            range.ApplyStyle(style2, flag);

            cells["C8"].PutValue(43105);

            // Save the excel file. 
            workbook.Save(outputDir + "outputModifyThroughStyleObject.xlsx");

            Console.WriteLine("ModifyThroughStyleObject executed successfully.");
        }
    }
}
