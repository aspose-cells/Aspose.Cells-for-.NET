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
            //Specify the excel file path.
            string myPath = "Get Text of Specific Cell.xlsx";

            //Instantiating a Workbook object
            Workbook workbook = new Workbook(myPath);

            //Get worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            String res = "";
           res= worksheet.Cells["A1"].Value.ToString();

           Console.Write(res);

           Console.ReadKey();

        }
    }
}
