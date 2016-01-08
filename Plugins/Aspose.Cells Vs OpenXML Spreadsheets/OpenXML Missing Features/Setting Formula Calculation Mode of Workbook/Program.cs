using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace Setting_Formula_Calculation_Mode_of_Workbook
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a workbook
            Workbook workbook = new Workbook();

            //Set the Formula Calculation Mode to Manual
            workbook.Settings.CalcMode = CalcModeType.Manual;

            //Save the workbook
            workbook.Save("output.xlsx", SaveFormat.Xlsx);
        }
    }
}
