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
            //Create workbook
            Workbook workbook = new Workbook();

            //Access worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Place some text in cell A1 without wrapping
            Cell cellA1 = worksheet.Cells["A1"];
            cellA1.PutValue("Some Text Unwrapped");

            //Place some text in cell A5 wrapping
            Cell cellA5 = worksheet.Cells["A5"];
            cellA5.PutValue("Some Text Wrapped");
            Style style = cellA5.GetStyle();
            style.IsTextWrapped = true;
            cellA5.SetStyle(style);

            //Autofit rows
            worksheet.AutoFitRows();

            //Save the workbook
            workbook.Save("OutputAspose.xlsx", SaveFormat.Xlsx);

        }
    }
}
