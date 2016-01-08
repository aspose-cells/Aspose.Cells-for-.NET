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
            ISheet cloneSheet = wb.CloneSheet(0);

            FileStream sw = File.Create("newWorksheet.xls");
            wb.Write(sw);
            sw.Close(); 
        }
    }
}
