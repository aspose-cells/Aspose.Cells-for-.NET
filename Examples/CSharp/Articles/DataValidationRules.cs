using System.IO;
using System;
using Aspose.Cells;
namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class DataValidationRules
    {
        //Source directory
        static string sourceDir = RunExamples.Get_SourceDirectory();
        public static void Main()
        {
            // ExStart:DataValidationRules
            // Instantiate the workbook from sample Excel file
            Workbook workbook = new Workbook(sourceDir + "sampleDataValidationRules.xlsx");

            // Access the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Access Cell C1
            // Cell C1 has the Decimal Validation applied on it.
            // It can take only the values Between 10 and 20
            Cell cell = worksheet.Cells["C1"];

            // Enter 3 inside this cell
            // Since it is not between 10 and 20, it should fail the validation
            cell.PutValue(3);

            // Check if number 3 satisfies the Data Validation rule applied on this cell
            Console.WriteLine("Is 3 a Valid Value for this Cell: " + cell.GetValidationValue());

            // Enter 15 inside this cell
            // Since it is between 10 and 20, it should succeed the validation
            cell.PutValue(15);

            // Check if number 15 satisfies the Data Validation rule applied on this cell
            Console.WriteLine("Is 15 a Valid Value for this Cell: " + cell.GetValidationValue());

            // Enter 30 inside this cell
            // Since it is not between 10 and 20, it should fail the validation again
            cell.PutValue(30);

            // Check if number 30 satisfies the Data Validation rule applied on this cell
            Console.WriteLine("Is 30 a Valid Value for this Cell: " + cell.GetValidationValue());

            // Enter large number 12345678901 inside this cell
            // Since it is not between 1 and 999999999999, it should pass the validation again
            Cell cell2 = worksheet.Cells["D1"];
            cell2.PutValue(12345678901);

            // Check if number 12345678901 satisfies the Data Validation rule applied on this cell
            Console.WriteLine("Is 12345678901 a Valid Value for this Cell: " + cell2.GetValidationValue());
            // ExEnd:DataValidationRules

            Console.WriteLine("DataValidationRules executed successfully.\r\n");
        }
    }
}
