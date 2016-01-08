using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace Set_External_Links_in_Formula_Aspose.Cells_
{
    class Program
    {
        static void Main(string[] args)
        {

            //Instantiate a new Workbook.
            Workbook workbook = new Workbook();

            //Get first Worksheet
            Worksheet sheet = workbook.Worksheets[0];

            //Get Cells collection
            Cells cells = sheet.Cells;

            //Set formula with external links
            cells["A1"].Formula = "=SUM('[book1.xls]Sheet1'!A2, '[book1.xls]Sheet1'!A4)";

            //Set formula with external links
            cells["A2"].Formula = "='[book1.xls]Sheet1'!A8";

            //Save the workbook
            workbook.Save("output.xls");
        }
    }
}
