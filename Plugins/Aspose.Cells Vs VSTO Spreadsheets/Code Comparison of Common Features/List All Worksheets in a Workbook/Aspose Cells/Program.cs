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
            string myPath = "List All Worksheets in a Workbook.xlsx";
            Workbook workbook = new Workbook(myPath);

            ListSheets(workbook);
        }

        private static void ListSheets(Workbook workbook)
        {
            int index=0;
            Worksheet thisWorksheet = workbook.Worksheets[0];
            foreach (Worksheet worksheet in workbook.Worksheets)
            {
                thisWorksheet.Cells[index, 0].Value = worksheet.Name;
                index++;
            }
        }
    }
}
