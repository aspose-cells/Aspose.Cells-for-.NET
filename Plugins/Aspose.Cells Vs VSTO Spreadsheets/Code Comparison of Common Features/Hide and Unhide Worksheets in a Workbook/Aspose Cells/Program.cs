using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace Aspose_Cells
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            //Specify the template Excel file path.
            string myPath = "Book1.xls";

            //Open the Excel file.
            workbook.Open(myPath);

            //Get the first sheet.
            Aspose.Cells.Worksheet objSheet = workbook.Worksheets["Sheet1"];

            //Hide the worksheet.
            objSheet.IsVisible = false;

            //Unhide the worksheet.
            objSheet.IsVisible = true;

            //Save As the Excel file.
            workbook.Save("Book1.xls");
        }
    }
}
