using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithCalculationEngine
{
    public class SettingSharedFormula
    {
        public static void Run()
        {
            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiate a Workbook from existing file
            Workbook workbook = new Workbook();

            //Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Put some data in column A
            worksheet.Cells["A1"].PutValue(50);
            worksheet.Cells["A2"].PutValue(100);
            worksheet.Cells["A3"].PutValue(150);
            worksheet.Cells["A4"].PutValue(30);
            worksheet.Cells["A5"].PutValue(65);
            worksheet.Cells["A6"].PutValue(49);

            // Get the cells collection in the first worksheet
            Cells cells = worksheet.Cells;

            // Apply the shared formula in the range i.e.., C1:C6
            cells["C1"].SetSharedFormula("=A1*2", 6, 1);

            // Save the excel file
            workbook.Save(outputDir + "outputSettingSharedFormula.xlsx", SaveFormat.Xlsx);

            Console.WriteLine("SettingSharedFormula executed successfully.");
        }
    }
}
