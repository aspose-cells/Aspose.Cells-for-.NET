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
            //Specify the template excel file path.
            string myPath = "Protect and unProtect Worksheets.xlsx";

            //Instantiate a new Workbook.
            //Open the excel file.
            Workbook workbook = new Workbook(myPath);

            //Protect the worksheet specifying a password with Structure and Windows attributes.
            workbook.Worksheets[workbook.Worksheets.ActiveSheetIndex].Protect(ProtectionType.All, "thispassword", "");

            //Unprotect the worksheet specifying its password.
            workbook.Worksheets[workbook.Worksheets.ActiveSheetIndex].Unprotect("thispassword");

            //Save As the excel file.
            workbook.Save(myPath);
        }
    }
}
