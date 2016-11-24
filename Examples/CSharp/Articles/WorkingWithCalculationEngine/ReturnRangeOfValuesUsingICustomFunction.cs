using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithCalculationEngine
{
    // ExStart:CustomFunctionStaticValue
    public class CustomFunctionStaticValue : ICustomFunction
    {
        public object CalculateCustomFunction(string functionName, ArrayList paramsList, ArrayList contextObjects)
        {
            return new object[][] {
                new object[]{new DateTime(2015, 6, 12, 10, 6, 30), 2},
                new object[]{3.0, "Test"}
                };
        }
    }
    // ExEnd:CustomFunctionStaticValue

    public class ReturnRangeOfValuesUsingICustomFunction
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook
            Workbook wb = new Workbook();
            Cells cells = wb.Worksheets[0].Cells;

            // Set formula
            Cell cell = cells[0, 0];
            cell.SetArrayFormula("=MYFUNC()", 2, 2);

            Style style = cell.GetStyle();
            style.Number = 14;
            cell.SetStyle(style);

            // Set calculation options for formula
            CalculationOptions copt = new CalculationOptions();
            copt.CustomFunction = new CustomFunctionStaticValue();
            wb.CalculateFormula(copt);

            // Save to xlsx by setting the calc mode to manual
            wb.Settings.CalcMode = CalcModeType.Manual;
            wb.Save(dataDir + "output_out.xlsx");

            // Save to pdf
            wb.Save(dataDir + "output_out.pdf");
            // ExEnd:1
        }
    }
}
