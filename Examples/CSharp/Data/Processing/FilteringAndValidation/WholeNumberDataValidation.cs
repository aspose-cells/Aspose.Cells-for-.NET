using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Data.Processing.FilteringAndValidation
{
    public class WholeNumberDataValidation
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            // Create a workbook object.
            Workbook workbook = new Workbook();

            // Create a worksheet and get the first worksheet.
            Worksheet ExcelWorkSheet = workbook.Worksheets[0];

            //Accessing the Validations collection of the worksheet
            ValidationCollection validations = workbook.Worksheets[0].Validations;

            //Creating a Validation object
            Validation validation = validations[validations.Add()];

            //Setting the validation type to whole number
            validation.Type = ValidationType.WholeNumber;

            //Setting the operator for validation to Between
            validation.Operator = OperatorType.Between;

            //Setting the minimum value for the validation
            validation.Formula1 = "10";

            //Setting the maximum value for the validation
            validation.Formula2 = "1000";

            //Applying the validation to a range of cells from A1 to B2 using the
            //CellArea structure
            CellArea area;
            area.StartRow = 0;
            area.EndRow = 1;
            area.StartColumn = 0;
            area.EndColumn = 1;

            //Adding the cell area to Validation
            validation.AreaList.Add(area);


            // Save the workbook.
            workbook.Save(dataDir + "output.out.xls");

            
        }
    }
}