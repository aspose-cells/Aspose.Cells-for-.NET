using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Data.Processing.FilteringAndValidation
{
    public class TextLengthDataValidation
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

            // Create a new workbook.
            Workbook workbook = new Workbook();

            // Obtain the cells of the first worksheet.
            Cells cells = workbook.Worksheets[0].Cells;

            // Put a string value into A1 cell.
            cells["A1"].PutValue("Please enter a string not more than 5 chars");


            // Set row height and column width for the cell.
            cells.SetRowHeight(0, 31);
            cells.SetColumnWidth(0, 35);

            // Get the validations collection.
            ValidationCollection validations = workbook.Worksheets[0].Validations;

            // Create Cell Area
            CellArea ca = new CellArea();
            ca.StartRow = 0;
            ca.EndRow = 0;
            ca.StartColumn = 0;
            ca.EndColumn = 0;

            // Add a new validation.
            Validation validation = validations[validations.Add(ca)];

            // Set the data validation type.
            validation.Type = ValidationType.TextLength;

            // Set the operator for the data validation.
            validation.Operator = OperatorType.LessOrEqual;

            // Set the value or expression associated with the data validation.
            validation.Formula1 = "5";

            // Enable the error.
            validation.ShowError = true;

            // Set the validation alert style.
            validation.AlertStyle = ValidationAlertType.Warning;

            // Set the title of the data-validation error dialog box.
            validation.ErrorTitle = "Text Length Error";

            // Set the data validation error message.
            validation.ErrorMessage = " Enter a Valid String";

            // Set and enable the data validation input message.
            validation.InputMessage = "TextLength Validation Type";
            validation.IgnoreBlank = true;
            validation.ShowInput = true;

            // Set a collection of CellArea which contains the data validation settings.
            CellArea cellArea;
            cellArea.StartRow = 0;
            cellArea.EndRow = 0;
            cellArea.StartColumn = 1;
            cellArea.EndColumn = 1;

            // Add the validation area.
            validation.AddArea(cellArea);

            // Save the Excel file.
            workbook.Save(dataDir + "output.out.xls");
            // ExEnd:1
        }
    }
}
