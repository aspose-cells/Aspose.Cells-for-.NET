using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;

namespace HideColumnAndRowInXls
{
    class Program
    {
        static HSSFWorkbook hssfworkbook;

        static void Main(string[] args)
        {
            hssfworkbook = new HSSFWorkbook();
            ISheet s = hssfworkbook.CreateSheet("Sheet1");
            IRow r1 = s.CreateRow(0);
            IRow r2 = s.CreateRow(1);           
            //hide Row 0
            r1.ZeroHeight = true;
            //hide column C
            s.SetColumnHidden(0, true);
            FileStream file = new FileStream(@"HidingRowsandColumn(NPOI).xls", FileMode.Create);
            hssfworkbook.Write(file);
            file.Close();
 
        }



 
    }
}