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


            // Aqua background
            ICellStyle style = wb.CreateCellStyle();
            style.FillBackgroundColor = IndexedColors.Aqua.Index;
            style.FillPattern = FillPattern.BigSpots;

            IRow row = ws.CreateRow(0);
            ICell cell = row.CreateCell(1);
            cell.SetCellValue("X");
            cell.CellStyle = style;            

            // Orange "foreground", foreground being the fill foreground not the font color.
            style = wb.CreateCellStyle();
            style.FillBackgroundColor = IndexedColors.Orange.Index;
            style.FillPattern = FillPattern.SolidForeground;
           
            cell = row.CreateCell(2);
            cell.SetCellValue("X");
            cell.CellStyle = style;

            FileStream sw = File.Create("test.xlsx");
            wb.Write(sw);
            sw.Close();

            
        }
    }
}
