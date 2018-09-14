using System.IO;

using Aspose.Cells;
using System;

namespace Aspose.Cells.Examples.CSharp.Data.Processing.FilteringAndValidation
{
    public class DecimalDataValidation
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            // Create a workbook object.
            Workbook workbook = new Workbook();

            // Create a worksheet and get the first worksheet.
            Worksheet ExcelWorkSheet = workbook.Worksheets[0];

            // Obtain the existing Validations collection.
            ValidationCollection validations = ExcelWorkSheet.Validations;

            // Create Cell Area
            CellArea ca = new CellArea();
            ca.StartRow = 0;
            ca.EndRow = 0;
            ca.StartColumn = 0;
            ca.EndColumn = 0;

            // Create a validation object adding to the collection list.
            Validation validation = validations[validations.Add(ca)];

            // Set the validation type.
            validation.Type = ValidationType.Decimal;

            // Specify the operator.
            validation.Operator = OperatorType.Between;

            // Set the lower and upper limits.
            validation.Formula1 = Decimal.MinValue.ToString();
            validation.Formula2 = Decimal.MaxValue.ToString();

            // Set the error message.
            validation.ErrorMessage = "Please enter a valid integer or decimal number";

            // Specify the validation area of cells.
            CellArea area;
            area.StartRow = 0;
            area.EndRow = 9;
            area.StartColumn = 0;
            area.EndColumn = 0;

            // Add the area.
            validation.AddArea(area);

            // Save the workbook.
            workbook.Save(dataDir + "output.out.xls");
            // ExEnd:1

        }
    }
}
