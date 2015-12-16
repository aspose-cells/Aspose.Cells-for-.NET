using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace Copy_Shapes_between_Worksheets
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a workbook object
            //Open the template file
            Workbook workbook = new Workbook("Shapes.xls");

            //Get the Chart from the "Chart" worksheet.
            Aspose.Cells.Charts.Chart source = workbook.Worksheets["Chart"].Charts[0];

            Aspose.Cells.Drawing.ChartShape cshape = source.ChartObject;

            //Copy the Chart to the Result Worksheet
            workbook.Worksheets["Result"].Shapes.AddCopy(cshape, 20, 0, 2, 0);

            //Save the Worksheet
            workbook.Save("Shapes.xls");
 
        }
    }
}
