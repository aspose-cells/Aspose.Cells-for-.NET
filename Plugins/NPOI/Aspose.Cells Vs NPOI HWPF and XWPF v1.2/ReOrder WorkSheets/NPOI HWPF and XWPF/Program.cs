using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NPOI_HWPF_and_XWPF
{
    class Program
    {
        static void Main(string[] args)
        {
            IWorkbook wb = new XSSFWorkbook();
            wb.CreateSheet("new sheet");
            wb.CreateSheet("second sheet");
            wb.CreateSheet("third sheet");

            wb.SetSheetOrder("second sheet", 0);
            wb.SetSheetOrder("new sheet", 1);
            wb.SetSheetOrder("third sheet", 2);

            FileStream sw = File.Create("../../data/Reordered.xls");
            wb.Write(sw);
            sw.Close(); 
        }
    }
}
