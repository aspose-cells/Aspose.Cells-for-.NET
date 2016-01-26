using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NPOI_HWPF_and_XWPF
{
    class Program
    {
        static void Main(string[] args)
        {
            IWorkbook wb = new XSSFWorkbook();
            ISheet sheet1 = wb.CreateSheet("First Sheet");
            ISheet sheet2 = wb.CreateSheet("Second Sheet");
            

            // Note that sheet name is Excel must not exceed 31 characters
            // and must not contain any of the any of the following characters:
            // 0x0000
            // 0x0003
            // colon (:)
            // backslash (\)
            // asterisk (*)
            // question mark (?)
            // forward slash (/)
            // opening square bracket ([)
            // closing square bracket (])

            // You can use org.apache.poi.ss.util.WorkbookUtil#createSafeSheetName(String nameProposal)}
            // for a safe way to create valid names, this utility replaces invalid characters with a space (' ')
            String safeName = WorkbookUtil.CreateSafeSheetName("[O'Brien's sales*?]");
            ISheet sheet3 = wb.CreateSheet(safeName);

            FileStream sw = File.Create("newWorksheet.xls");
            wb.Write(sw);
            sw.Close();            
        }
    }
}
