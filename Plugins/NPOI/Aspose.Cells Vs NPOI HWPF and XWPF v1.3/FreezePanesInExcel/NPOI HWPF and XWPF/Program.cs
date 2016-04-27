using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace FreezPanesInNpoi
{
    class Program
    {
        static HSSFWorkbook hssfworkbook;
        static void Main(string[] args)
        {

            hssfworkbook = new HSSFWorkbook();
            ISheet sheet1 = hssfworkbook.CreateSheet("new sheet");
            ISheet sheet2 = hssfworkbook.CreateSheet("second sheet");
            ISheet sheet3 = hssfworkbook.CreateSheet("third sheet");

            // Freeze just one row
            sheet1.CreateFreezePane(0, 2, 0, 2);
            // Freeze just one column
            sheet2.CreateFreezePane(2, 0, 2, 0);
            // Freeze the columns and rows (forget about scrolling position of the lower right quadrant).
            sheet3.CreateFreezePane(2, 2);

            //Write the stream data of workbook to the root directory
            FileStream file = new FileStream(@"output-FreezeFile-NPOI.xls", FileMode.Create);
            hssfworkbook.Write(file);
            file.Close();

        }




    }
}
