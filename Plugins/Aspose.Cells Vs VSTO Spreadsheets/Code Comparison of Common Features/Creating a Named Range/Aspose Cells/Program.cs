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
            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            //Creating a named range
            Range range = worksheet.Cells.CreateRange("A1", "B4");

            //Setting the name of the named range
            range.Name = "Test_Range";

            for (int row = 0; row < range.RowCount; row++)
            {
                for (int column = 0; column < range.ColumnCount; column++)
                {
                    range[row, column].PutValue("Test");
                }
            }

            //Saving the modified Excel file in default (that is Excel 2003) format
            workbook.Save("Test_Range.xls");
        }
    }
}
