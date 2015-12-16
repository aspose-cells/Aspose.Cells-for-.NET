using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace Setting_Shared_Formula
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "source.xlsx";
 
            //Instantiate a Workbook from existing file
            Workbook workbook = new Workbook(filePath);

            //Get the cells collection in the first worksheet
            Cells cells = workbook.Worksheets[0].Cells;

            //Apply the shared formula in the range i.e.., B2:B14
            cells["B2"].SetSharedFormula("=A2*0.09", 13, 1);

            //Save the excel file
            workbook.Save(filePath + ".out.xlsx", SaveFormat.Xlsx);
        }
    }
}
