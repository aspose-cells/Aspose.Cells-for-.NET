using System;
using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class FormatRanges1
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            // Get the first worksheet in the book.
            Worksheet WS = workbook.Worksheets[0];

            // Create a range of cells.
            Aspose.Cells.Range range = WS.Cells.CreateRange(1, 1, 5, 5);

            // Name the range.
            range.Name = "MyRange";

            // Declare a style object.
            Style stl;

            // Create/add the style object.
            stl = workbook.CreateStyle();

            // Specify some Font settings.
            stl.Font.Name = "Arial";
            stl.Font.IsBold = true;

            // Set the font text color
            stl.Font.Color = Color.Red;

            // To Set the fill color of the range, you may use ForegroundColor with
            // Solid Pattern setting.
            stl.ForegroundColor = Color.Yellow;
            stl.Pattern = BackgroundType.Solid;

            // Create a StyleFlag object.
            StyleFlag flg = new StyleFlag();
            // Make the corresponding attributes ON.
            flg.Font = true;
            flg.CellShading = true;

            // Apply the style to the range.
            range.ApplyStyle(stl, flg);

            // Save the excel file.
            workbook.Save(outputDir + "outputFormatRanges1.xlsx");

            Console.WriteLine("FormatRanges1 executed successfully.");
        }
    }
}
