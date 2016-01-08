using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOI_HWPF_and_XWPF
{
    class Program
    {
        static void Main(string[] args)
        {
            IWorkbook wb = new XSSFWorkbook();

            // Create a Worksheet
            ISheet ws = wb.CreateSheet("Sheet1");

            // Create a new font and alter it
            IFont font = wb.CreateFont();
            font.FontHeightInPoints = 24;
            font.FontName = "Courier New";
            font.IsItalic = true;
            font.IsStrikeout = true;            

            // Fonts are set into a style so create a new one to use.
            ICellStyle style = wb.CreateCellStyle();
            style.SetFont(font);

            IRow row = ws.CreateRow(0);

            // Create a cell and put a value in it.
            ICell cell = row.CreateCell(1);
            cell.SetCellValue("Thisi s a test of fonts");
            cell.CellStyle = style;

            FileStream sw = File.Create("test.xlsx");
            wb.Write(sw);
            sw.Close();
        }
    }
}
