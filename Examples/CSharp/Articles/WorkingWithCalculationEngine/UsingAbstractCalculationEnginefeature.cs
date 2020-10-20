using System.IO;

using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithCalculationEngine
{
    // ExStart:AbstractCalculationEngine
    public class CustomFunction : AbstractCalculationEngine
    {
        public override void Calculate(CalculationData data)
        {
            decimal total = 0M;
            try
            {
                // Get value of first parameter
                object firstParameter = data.GetParamValue(0);
                Console.WriteLine(data.GetParamValue(0).GetType());

                decimal firstParamB1 = 0;

                if (firstParameter is ReferredArea)
                {
                    ReferredArea ra = (ReferredArea)firstParameter;
                    firstParamB1 = System.Convert.ToDecimal(ra.GetValue(0, 0));
                }

                // Get value of second parameter
                object secondParameter = data.GetParamValue(1);
                Console.WriteLine(data.GetParamValue(1).GetType());

                if (secondParameter is ReferredArea)
                {
                    ReferredArea ra = (ReferredArea)secondParameter;

                    // get every item value of second parameter
                    foreach (object[] value in (Array)ra.GetValues())
                    {
                        total += System.Convert.ToDecimal(value[0]);
                    }
                }

                total = total / firstParamB1;
            }
            catch
            {

            }

            // Result of the function
            data.CalculatedValue = total;
        }
    }
    // ExEnd:AbstractCalculationEngine

    public class UsingAbstractCalculationEnginefeature
    {
        public static void Run()
        {
            // ExStart:UsingAbstractCalculationEnginefeature
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Open the workbook
            Workbook workbook = new Workbook();

            // Obtaining the reference of the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Adding sample values to cells
            worksheet.Cells["B1"].PutValue(5);
            worksheet.Cells["C1"].PutValue(100);
            worksheet.Cells["C2"].PutValue(150);
            worksheet.Cells["C3"].PutValue(60);
            worksheet.Cells["C4"].PutValue(32);
            worksheet.Cells["C5"].PutValue(62);

            // Adding custom formula to Cell A1
            workbook.Worksheets[0].Cells["A1"].Formula = "=MyFunc(B1,C1:C5)";

            // Set calculation options
            CalculationOptions calculationOptions = new CalculationOptions();
            calculationOptions.CustomEngine = new CustomFunction();

            // Calcualting Formulas
            workbook.CalculateFormula(calculationOptions);

            // Assign resultant value to Cell A1
            workbook.Worksheets[0].Cells["A1"].PutValue(workbook.Worksheets[0].Cells["A1"].Value);

            // Save the file
            workbook.Save(dataDir + "UsingAbstractCalculationEnginefeature_out.xls");
            // ExEnd:UsingAbstractCalculationEnginefeature
        }
    }
}