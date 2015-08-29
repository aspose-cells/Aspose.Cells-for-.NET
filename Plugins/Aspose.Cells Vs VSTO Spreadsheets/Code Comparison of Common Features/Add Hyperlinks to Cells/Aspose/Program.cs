using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace Aspose
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate a new Workbook object.
            Workbook workbook = new Workbook();
            //Get the First sheet.
            Worksheet worksheet = workbook.Worksheets[0];

            //Define A1 Cell.
            Aspose.Cells.Cell cell = worksheet.Cells["A1"];
            //Add a hyperlink to it.
            int index = worksheet.Hyperlinks.Add("A1", 1, 1, "http://www.aspose.com/");
            worksheet.Hyperlinks[index].TextToDisplay = "Aspose Site!";
            worksheet.Hyperlinks[index].ScreenTip = "Click to go to Aspose site";

            //Save the excel file.
            workbook.Save("Hyperlink_test.xls");
        }
    }
}
