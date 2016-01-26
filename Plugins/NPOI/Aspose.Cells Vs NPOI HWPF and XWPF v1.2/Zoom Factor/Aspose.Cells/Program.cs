using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells;

namespace Aspose.Cells
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Adding a new worksheet to the Workbook object
            WorksheetCollection worksheets = workbook.Worksheets;
            Worksheet worksheet = worksheets.Add("My Worksheet");

            worksheet.Zoom = 75;

            //Saving the Excel file
            workbook.Save("../../data/newWorksheet.xls");
        }
    }
}
