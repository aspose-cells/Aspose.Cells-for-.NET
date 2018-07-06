using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Formulas
{
    class AddCellsToMicrosoftExcelFormulaWatchWindow 
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Main()
        {
            // Create empty workbook.
            Workbook wb = new Workbook();

            // Access first worksheet.
            Worksheet ws = wb.Worksheets[0];

            // Put some integer values in cell A1 and A2.
            ws.Cells["A1"].PutValue(10);
            ws.Cells["A2"].PutValue(30);

            // Access cell C1 and set its formula.
            Cell c1 = ws.Cells["C1"];
            c1.Formula = "=Sum(A1,A2)";

            // Add cell C1 into cell watches by name.
            ws.CellWatches.Add(c1.Name);

            // Access cell E1 and set its formula.
            Cell e1 = ws.Cells["E1"];
            e1.Formula = "=A2*A1";

            // Add cell E1 into cell watches by its row and column indices.
            ws.CellWatches.Add(e1.Row, e1.Column);

            // Save workbook to output XLSX format.
            wb.Save(outputDir + "outputAddCellsToMicrosoftExcelFormulaWatchWindow.xlsx", SaveFormat.Xlsx);

            Console.WriteLine("AddCellsToMicrosoftExcelFormulaWatchWindow executed successfully.");
        }

    }
}
