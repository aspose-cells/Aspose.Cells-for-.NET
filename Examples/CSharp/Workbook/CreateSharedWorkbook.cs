using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp._Workbook
{
    class CreateSharedWorkbook 
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            //Create Workbook object
            Workbook wb = new Workbook();

            //Share the Workbook
            wb.Settings.Shared = true;

            //Save the Shared Workbook
            wb.Save(outputDir + "outputSharedWorkbook.xlsx");

            Console.WriteLine("CreateSharedWorkbook executed successfully.\r\n");
        }
    }
}
