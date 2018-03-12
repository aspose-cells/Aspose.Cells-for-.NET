using System;
using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class SetBorderAroundEachCell
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {         
            // Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            // Access the cells in the first worksheet.
            Cells cells = workbook.Worksheets[0].Cells;

            // Create a range of cells.
            Range range = cells.CreateRange("D6", "M16");

            // Declare style.
            Style stl;

            // Create the style adding to the style collection.
            stl = workbook.CreateStyle();

            // Specify the font settings.
            stl.Font.Name = "Arial";
            stl.Font.IsBold = true;
            stl.Font.Color = Color.Blue;

            // Set the borders
            stl.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thick;
            stl.Borders[BorderType.TopBorder].Color = Color.Blue;
            stl.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thick;
            stl.Borders[BorderType.LeftBorder].Color = Color.Blue;
            stl.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thick;
            stl.Borders[BorderType.BottomBorder].Color = Color.Blue;
            stl.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thick;
            stl.Borders[BorderType.RightBorder].Color = Color.Blue;


            // Create StyleFlag object.
            StyleFlag flg = new StyleFlag();
            // Make the corresponding formatting attributes ON.
            flg.Font = true;
            flg.Borders = true;

            // Apply the style with format settings to the range.
            range.ApplyStyle(stl, flg);

            // Save the excel file.
            workbook.Save(outputDir + "outputSetBorderAroundEachCell.xlsx");

            Console.WriteLine("SetBorderAroundEachCell executed successfully.");
        }
    }
}