using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class UpdateReferenceInWorksheets
    {
        public static void Run()
        {
            // Create workbook
            Workbook wb = new Workbook();

            // Add second sheet with name Sheet2
            wb.Worksheets.Add("Sheet2");

            // Access first sheet and add some integer value in cell C1
            // Also add some value in any cell to increase the number of blank rows and columns
            Worksheet sht1 = wb.Worksheets[0];
            sht1.Cells["C1"].PutValue(4);
            sht1.Cells["K30"].PutValue(4);

            // Access second sheet and add formula in cell E3 which refers to cell C1 in first sheet
            Worksheet sht2 = wb.Worksheets[1];
            sht2.Cells["E3"].Formula = "'Sheet1'!C1";

            // Calculate formulas of workbook
            wb.CalculateFormula();

            // Print the formula and value of cell E3 in second sheet before deleting blank columns and rows in Sheet1.
            Console.WriteLine("Cell E3 before deleting blank columns and rows in Sheet1.");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Cell Formula: " + sht2.Cells["E3"].Formula);
            Console.WriteLine("Cell Value: " + sht2.Cells["E3"].StringValue);

            // If you comment DeleteOptions.UpdateReference property below, then the formula in cell E3 in second sheet will not be updated
            DeleteOptions opts = new DeleteOptions();
            opts.UpdateReference = true;

            // Delete all blank rows and columns with delete options
            sht1.Cells.DeleteBlankColumns(opts);
            sht1.Cells.DeleteBlankRows(opts);

            // Calculate formulas of workbook
            wb.CalculateFormula();

            // Print the formula and value of cell E3 in second sheet after deleting blank columns and rows in Sheet1.
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Cell E3 after deleting blank columns and rows in Sheet1.");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Cell Formula: " + sht2.Cells["E3"].Formula);
            Console.WriteLine("Cell Value: " + sht2.Cells["E3"].StringValue);

            Console.WriteLine("UpdateReferenceInWorksheets executed successfully.");
        }
    }
}