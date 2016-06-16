using System.IO;
using System;
using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class CopyRangeDataWithStyle
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


            // Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            // Get the first Worksheet Cells.
            Cells cells = workbook.Worksheets[0].Cells;

            // Fill some sample data into the cells.
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    cells[i, j].PutValue(i.ToString() + "," + j.ToString());
                }

            }

            // Create a range (A1:D3).
            Range range = cells.CreateRange("A1", "D3");

            // Create a style object.
            Style style;
            style = workbook.CreateStyle();
            // Specify the font attribute.
            style.Font.Name = "Calibri";
            // Specify the shading color.
            style.ForegroundColor = Color.Yellow;
            style.Pattern = BackgroundType.Solid;
            // Specify the border attributes.
            style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            style.Borders[BorderType.TopBorder].Color = Color.Blue;
            style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
            style.Borders[BorderType.BottomBorder].Color = Color.Blue;
            style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            style.Borders[BorderType.LeftBorder].Color = Color.Blue;
            style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            style.Borders[BorderType.RightBorder].Color = Color.Blue;
            // Create the styleflag object.
            StyleFlag flag1 = new StyleFlag();
            // Implement font attribute
            flag1.FontName = true;
            // Implement the shading / fill color.
            flag1.CellShading = true;
            // Implment border attributes.
            flag1.Borders = true;
            // Set the Range style.
            range.ApplyStyle(style, flag1);

            // Create a second range (C10:F12).
            Range range2 = cells.CreateRange("C10", "F12");

            // Copy the range data with formatting.
            range2.Copy(range);

            dataDir = dataDir + "CopyRange.out.xlsx";
            // Save the excel file.
            workbook.Save(dataDir);
            // ExEnd:1
            Console.WriteLine("\nProcess completed successfully.\nFile saved at " + dataDir);
            
        }
    }
}
