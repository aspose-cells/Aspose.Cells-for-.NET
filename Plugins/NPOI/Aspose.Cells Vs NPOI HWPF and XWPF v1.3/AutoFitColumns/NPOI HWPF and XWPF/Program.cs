using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace AutoFitColumns
{
    class Program
    {
        static HSSFWorkbook hssfworkbook;
        static void Main(string[] args)
        {
            hssfworkbook = new HSSFWorkbook();

            ISheet sheet=hssfworkbook.CreateSheet("Sheet1");
            IRow row=sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("This is a test input");
            row.CreateCell(1).SetCellValue("Hello");
            row.CreateCell(2).SetCellValue("1234.0023");
            sheet.AutoSizeColumn(0);
            sheet.AutoSizeColumn(1);
            sheet.AutoSizeColumn(2);
            FileStream file = new FileStream(@"AutoFiltRowsandColumns(NPOI).xls", FileMode.Create);
            hssfworkbook.Write(file);
            file.Close();
     
        }
    }
}
