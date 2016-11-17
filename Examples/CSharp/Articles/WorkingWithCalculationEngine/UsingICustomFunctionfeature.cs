using System.IO;

using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Aspose.Cells.Examples.CSharp.Articles.WorkingWithCalculationEngine
{
    // ExStart:ICustomFunction
    public class CustomFunction : ICustomFunction
    {
        public object CalculateCustomFunction(string functionName, System.Collections.ArrayList paramsList, System.Collections.ArrayList contextObjects)
        {
            decimal total = 0M;
            try
            {
                // Get value of first parameter
                decimal firstParamB1 = System.Convert.ToDecimal(paramsList[0]);

                // Get value of second parameter
                Array secondParamC1C5 = (Array)(paramsList[1]);

                // get every item value of second parameter
                foreach (object[] value in secondParamC1C5)
                {
                    total += System.Convert.ToDecimal(value[0]);
                }

                total = total / firstParamB1;
            }
            catch
            {

            }

            // Return result of the function
            return total;
        }
    }
    // ExEnd:ICustomFunction

    public class UsingICustomFunctionfeature
    {
        public static void Run()
        {
            // ExStart:UsingICustomFunctionFeature
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

            // Calcualting Formulas
            workbook.CalculateFormula(false, new CustomFunction());

            // Assign resultant value to Cell A1
            workbook.Worksheets[0].Cells["A1"].PutValue(workbook.Worksheets[0].Cells["A1"].Value);

            // Save the file
            workbook.Save(dataDir + "UsingICustomFunction_out_.xls");
            // ExEnd:UsingICustomFunctionFeature
        }
    }
}