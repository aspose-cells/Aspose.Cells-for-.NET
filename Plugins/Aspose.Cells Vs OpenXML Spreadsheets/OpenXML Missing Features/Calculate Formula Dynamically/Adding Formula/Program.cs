// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using Aspose.Cells;

namespace Adding_Formula
{
    class Program
    {
        static void Main(string[] args)
        {
            string MyDir = @"Files\";
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
            workbook.Save(MyDir + "Adding Formula.xls");
        }
    }
}
