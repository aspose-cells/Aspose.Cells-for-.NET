using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles.ManagingRowsColumnsCells
{
    public class GetValidationAppliedOnCell
    {
        public static void Run()
        {
            // ExStart:GetValidationAppliedOnCell
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Instantiate the workbook from sample Excel file
            Workbook workbook = new Workbook(dataDir + "sample.xlsx");

            // Access its first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Cell C1 has the Decimal Validation applied on it. It can take only the values Between 10 and 20
            Cell cell = worksheet.Cells["C1"];

            // Access the valditation applied on this cell
            Validation validation = cell.GetValidation();

            // Read various properties of the validation
            Console.WriteLine("Reading Properties of Validation");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Type: " + validation.Type);
            Console.WriteLine("Operator: " + validation.Operator);
            Console.WriteLine("Formula1: " + validation.Formula1);
            Console.WriteLine("Formula2: " + validation.Formula2);
            Console.WriteLine("Ignore blank: " + validation.IgnoreBlank);
            // ExEnd:GetValidationAppliedOnCell
        }
    }
}
