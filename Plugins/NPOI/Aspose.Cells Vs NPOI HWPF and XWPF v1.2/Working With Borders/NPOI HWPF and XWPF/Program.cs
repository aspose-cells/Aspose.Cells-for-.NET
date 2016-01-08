using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace NPOI_HWPF_and_XWPF
{
    class Program
    {
        static void Main(string[] args)
        {
            IWorkbook wb = new XSSFWorkbook();

            // Create a Worksheet
            ISheet ws = wb.CreateSheet("Sheet1");

            ICellStyle style = wb.CreateCellStyle();

            //Setting the line of the top border
            style.BorderTop = BorderStyle.Thick;
            style.TopBorderColor = 256;

            style.BorderLeft = BorderStyle.Thick;
            style.LeftBorderColor = 256;

            style.BorderRight = BorderStyle.Thick;
            style.RightBorderColor = 256;

            style.BorderBottom = BorderStyle.Thick;
            style.BottomBorderColor = 256;

            IRow row = ws.CreateRow(0);
            ICell cell = row.CreateCell(1);
            cell.CellStyle = style;

            FileStream sw = File.Create("test.xlsx");
            wb.Write(sw);
            sw.Close();
        }
    }
}
