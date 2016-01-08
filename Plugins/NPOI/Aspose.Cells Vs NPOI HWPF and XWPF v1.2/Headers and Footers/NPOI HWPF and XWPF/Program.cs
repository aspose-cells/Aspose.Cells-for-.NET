using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace NPOI_HWPF_and_XWPF
{
    class Program
    {
        static void Main(string[] args)
        {
            IWorkbook wb = new XSSFWorkbook();
            ISheet sheet1 = wb.CreateSheet("First Sheet");

            IHeader header = sheet1.Header;
            header.Center = "Center Header";
            header.Left = "Left Header";
            header.Right = "Right Header";            

            FileStream sw = File.Create("../../data/header.xls");
            wb.Write(sw);
            sw.Close();
        }
    }
}
