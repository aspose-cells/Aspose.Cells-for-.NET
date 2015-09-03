using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose_ApplyStylesToRanges
{
    class Program
    {
        private static string fileName = @"E:\Aspose\Aspose Vs VSTO\Aspose.Cells Vs VSTO Cells v 1.1\Sample Files\Aspose_ApplyStylesToRanges.xlsx";
        static void Main(string[] args)
        {
            Workbook myWorkbook = new Workbook(fileName);
            Worksheet mySheet = myWorkbook.Worksheets[myWorkbook.Worksheets.ActiveSheetIndex];

            Style style = myWorkbook.CreateStyle();
            style.VerticalAlignment = TextAlignmentType.Center;
            //Setting the horizontal alignment of the text in the "A1" cell
            style.HorizontalAlignment = TextAlignmentType.Center;
            //Setting the font color of the text in the "A1" cell
            style.Font.Color = Color.Green;
            //Shrinking the text to fit in the cell
            style.ShrinkToFit = true;
            //Setting the bottom border color of the cell to red
            style.Borders[BorderType.BottomBorder].Color = Color.Red;

            //Creating StyleFlag
            StyleFlag styleFlag = new StyleFlag();
            styleFlag.HorizontalAlignment = true;
            styleFlag.VerticalAlignment = true;
            styleFlag.ShrinkToFit = true;
            styleFlag.Borders = true;
            styleFlag.FontColor = true;

            //Accessing a row from the Rows collection
            Column column = mySheet.Cells.Columns[0];
            //Assigning the Style object to the Style property of the row
            column.ApplyStyle(style, styleFlag);

            myWorkbook.Save(fileName);
        }
    }
}
