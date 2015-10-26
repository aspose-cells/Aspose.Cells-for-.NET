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

            //Specify the template excel file path.
            string myPath = "Book1.xls";

            //Open the excel file.
            workbook.Open(myPath);

            //Get the range of cells i.e.., A1:C1.
            Aspose.Cells.Range rng1 = workbook.Worksheets[0].Cells.CreateRange("A1", "C1");

            //Merge the cells.
            rng1.Merge();

            Cells rng = workbook.Worksheets[0].Cells;

            //UnMerge the cell.
            rng.UnMerge(0, 0, 1, 3);

            //Save the file.
            workbook.Save("Book1.xls");
        
        }
    }
}
