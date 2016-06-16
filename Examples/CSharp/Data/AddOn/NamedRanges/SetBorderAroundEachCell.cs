using System.IO;

using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Data.AddOn.NamedRanges
{
    public class SetBorderAroundEachCell
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
          
            // Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            // Access the cells in the first worksheet.
            Cells cells = workbook.Worksheets[0].Cells;

            // Create a range of cells.
            Range range = cells.CreateRange("A6", "P216");

            // Declare style.
            Style stl;

            // Create the style adding to the style collection.
            stl = workbook.CreateStyle();

            // Specify the font settings.
            stl.Font.Name = "Arial";
            stl.Font.IsBold = true;
            stl.Font.Color = Color.Blue;

            // Set the borders
            stl.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            stl.Borders[BorderType.TopBorder].Color = Color.Blue;
            stl.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            stl.Borders[BorderType.LeftBorder].Color = Color.Blue;
            stl.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
            stl.Borders[BorderType.BottomBorder].Color = Color.Blue;
            stl.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            stl.Borders[BorderType.RightBorder].Color = Color.Blue;


            // Create StyleFlag object.
            StyleFlag flg = new StyleFlag();
            // Make the corresponding formatting attributes ON.
            flg.Font = true;
            flg.Borders = true;

            // Apply the style with format settings to the range.
            range.ApplyStyle(stl, flg);

            // Save the excel file.
            workbook.Save( dataDir + "output.xls");

            // ExEnd:1
        }
    }
}