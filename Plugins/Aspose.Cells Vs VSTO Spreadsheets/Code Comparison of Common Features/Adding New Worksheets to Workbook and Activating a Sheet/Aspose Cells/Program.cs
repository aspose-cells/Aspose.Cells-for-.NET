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
            //Instantiate an instance of license and set the license file
            //through its path
            Aspose.Cells.License license = new Aspose.Cells.License();
            license.SetLicense("Aspose.Total.lic");

            //Specify the template excel file path.
            string myPath = "Book1.xls";

            //Instantiate a new Workbook.
            //Open the excel file.
            Workbook workbook = new Workbook(myPath);

            //Declare a Worksheet object.
            Worksheet newWorksheet;

            //Add 5 new worksheets to the workbook and fill some data
            //into the cells.
            for (int i = 0; i < 5; i++)
            {

                //Add a worksheet to the workbook.
                newWorksheet = workbook.Worksheets[workbook.Worksheets.Add()];

                //Name the sheet.
                newWorksheet.Name = "New_Sheet" + (i + 1).ToString();

                //Get the Cells collection.
                Cells cells = newWorksheet.Cells;

                //Input a string value to a cell of the sheet.
                cells[i, i].PutValue("New_Sheet" + (i + 1).ToString());
            }

            //Activate the first worksheet by default.
            workbook.Worksheets.ActiveSheetIndex = 0;

            //Save As the excel file.
            workbook.Save("out_My_Book1.xls");
        }
    }
}
