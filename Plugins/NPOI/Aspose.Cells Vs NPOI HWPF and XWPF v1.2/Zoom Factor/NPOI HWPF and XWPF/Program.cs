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
            ISheet sheet1 = wb.CreateSheet("First Sheet");

            sheet1.SetZoom(3, 4); // 75 percent

            FileStream sw = File.Create("../../data/newWorksheet.xls");
            wb.Write(sw);
            sw.Close(); 
        }
    }
}
