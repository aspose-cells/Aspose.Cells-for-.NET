using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Formulas
{
    public class CalculatingFormulas
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiating a Workbook object
            Workbook workbook = new Workbook();

            //Adding a new worksheet to the Excel object
            int sheetIndex = workbook.Worksheets.Add();

            //Obtaining the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[sheetIndex];

            //Adding a value to "A1" cell
            worksheet.Cells["A1"].PutValue(1);

            //Adding a value to "A2" cell
            worksheet.Cells["A2"].PutValue(2);

            //Adding a value to "A3" cell
            worksheet.Cells["A3"].PutValue(3);

            //Adding a SUM formula to "A4" cell
            worksheet.Cells["A4"].Formula = "=SUM(A1:A3)";

            //Calculating the results of formulas
            workbook.CalculateFormula();

            //Get the calculated value of the cell
            string value = worksheet.Cells["A4"].Value.ToString();

            //Saving the Excel file
            workbook.Save(dataDir + "output.xls");

        }
    }
}