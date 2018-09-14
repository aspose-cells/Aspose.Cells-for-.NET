using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Data.Processing.FilteringAndValidation
{
    public class ListDataValidation
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

            // Get the first worksheet.
            Worksheet worksheet1 = workbook.Worksheets[0];

            // Add a new worksheet and access it.
            int i = workbook.Worksheets.Add();
            Worksheet worksheet2 = workbook.Worksheets[i];

            // Create a range in the second worksheet.
            Range range = worksheet2.Cells.CreateRange("E1", "E4");

            // Name the range.
            range.Name = "MyRange";

            // Fill different cells with data in the range.
            range[0, 0].PutValue("Blue");
            range[1, 0].PutValue("Red");
            range[2, 0].PutValue("Green");
            range[3, 0].PutValue("Yellow");

            // Get the validations collection.
            ValidationCollection validations = worksheet1.Validations;

            // Create Cell Area
            CellArea ca = new CellArea();
            ca.StartRow = 0;
            ca.EndRow = 0;
            ca.StartColumn = 0;
            ca.EndColumn = 0;

            // Create a new validation to the validations list.
            Validation validation = validations[validations.Add(ca)];

            // Set the validation type.
            validation.Type = Aspose.Cells.ValidationType.List;

            // Set the operator.
            validation.Operator = OperatorType.None;

            // Set the in cell drop down.
            validation.InCellDropDown = true;

            // Set the formula1.
            validation.Formula1 = "=MyRange";

            // Enable it to show error.
            validation.ShowError = true;

            // Set the alert type severity level.
            validation.AlertStyle = ValidationAlertType.Stop;

            // Set the error title.
            validation.ErrorTitle = "Error";

            // Set the error message.
            validation.ErrorMessage = "Please select a color from the list";

            // Specify the validation area.
            CellArea area;
            area.StartRow = 0;
            area.EndRow = 4;
            area.StartColumn = 0;
            area.EndColumn = 0;

            // Add the validation area.
            validation.AddArea(area);

            // Save the Excel file.
            workbook.Save(dataDir + "output.out.xls");
            // ExEnd:1

        }
    }
}
