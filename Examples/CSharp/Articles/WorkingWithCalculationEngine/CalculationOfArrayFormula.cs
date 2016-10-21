using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithCalculationEngine
{
    public class CalculationOfArrayFormula
    {
        public static void Run()
        {
            // ExStart:CalculateArrayFormula
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook from source excel file
            Workbook workbook = new Workbook(dataDir + "DataTable.xlsx");

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // When you will put 100 in B1, then all Data Table values formatted as Yellow will become 120
            worksheet.Cells["B1"].PutValue(100);

            // Calculate formula, now it also calculates Data Table array formula
            workbook.CalculateFormula();

            // Save the workbook in pdf format
            workbook.Save(dataDir + "output_out_.pdf");
            // ExEnd:CalculateArrayFormula
        }
    }
}
