using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithCalculationEngine
{
    // ExStart:CustomFunctionStaticValue
    public class CustomFunctionStaticValue : AbstractCalculationEngine
    {
        public override void Calculate(CalculationData data)
        {
            data.CalculatedValue = new object[][] {
                new object[]{new DateTime(2015, 6, 12, 10, 6, 30), 2},
                new object[]{3.0, "Test"}
                };
        }
    }
    // ExEnd:CustomFunctionStaticValue

    public class ReturnRangeOfValuesUsingAbstractCalculationEngine
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create workbook
            Workbook workbook = new Workbook();
            Cells cells = workbook.Worksheets[0].Cells;

            // Set formula
            Cell cell = cells[0, 0];
            cell.SetArrayFormula("=MYFUNC()", 2, 2);

            Style style = cell.GetStyle();
            style.Number = 14;
            cell.SetStyle(style);

            // Set calculation options for formula
            CalculationOptions calculationOptions = new CalculationOptions();
            calculationOptions.CustomEngine = new CustomFunctionStaticValue();
            workbook.CalculateFormula(calculationOptions);

            // Save to xlsx by setting the calc mode to manual
            workbook.Settings.FormulaSettings.CalculationMode = CalcModeType.Manual;
            workbook.Save(dataDir + "output_out.xlsx");

            // Save to pdf
            workbook.Save(dataDir + "output_out.pdf");
            // ExEnd:1
        }
    }
}
