using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace SplitCellInExecl
{
    class Program
    {
        static HSSFWorkbook hssfworkbook;

            static void Main(string[] args)
            {
                hssfworkbook = new HSSFWorkbook();
                ISheet sheet1 = hssfworkbook.CreateSheet("new sheet");
                ISheet sheet2 = hssfworkbook.CreateSheet("second sheet");
                //Create a split with the lower left side being the active quadrant
                sheet2.CreateSplitPane(2000, 2000, 0, 0, PanePosition.LowerLeft);
                //Write the stream data of workbook to the root directory
                FileStream file = new FileStream(@"output-Split.xls", FileMode.Create);
                hssfworkbook.Write(file);
                file.Close();
            }
    }
}
