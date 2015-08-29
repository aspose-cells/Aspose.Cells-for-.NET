using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace Aspose_Cells
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create workbook
            Workbook workbook = new Workbook();

            //Access worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Access cells A1, A2, A3 , A4
            Cell cellA1 = worksheet.Cells["A1"];
            Cell cellA2 = worksheet.Cells["A2"];
            Cell cellA3 = worksheet.Cells["A3"];
            Cell cellA4 = worksheet.Cells["A4"];

            //Set integer values in cells A1, A2 and A3
            cellA1.Value = 10;
            cellA2.Value = 20;
            cellA3.Value = 30;

            //Add formula in cell A4
            cellA4.Formula = "=Sum(A1:A3)";

            //Set the font bold in cell A4
            //and set the background color to Yellow in cell A4
            Style style = cellA4.GetStyle();
            style.Font.IsBold = true;
            style.Pattern = BackgroundType.Solid;
            style.ForegroundColor = Color.Yellow;
            cellA4.SetStyle(style);

            //Save the workbook
            workbook.Save("OutputAspose.xlsx", SaveFormat.Xlsx);
        }
    }
}
