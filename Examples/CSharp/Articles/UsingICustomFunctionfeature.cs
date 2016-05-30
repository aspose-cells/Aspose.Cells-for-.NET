using System.IO;

using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Articles
{
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

    public class UsingICustomFunctionfeature
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            
            // Open the workbook
        Workbook workbook = new Workbook();

        // Obtaining the reference of the first worksheet
        Worksheet worksheet = workbook.Worksheets[0];

        // Adding a sample value to "A1" cell
        worksheet.Cells["B1"].PutValue(5);

        // Adding a sample value to "A2" cell
        worksheet.Cells["C1"].PutValue(100);

        // Adding a sample value to "A3" cell
        worksheet.Cells["C2"].PutValue(150);

        // Adding a sample value to "B1" cell
        worksheet.Cells["C3"].PutValue(60);

        // Adding a sample value to "B2" cell
        worksheet.Cells["C4"].PutValue(32);

        // Adding a sample value to "B2" cell
        worksheet.Cells["C5"].PutValue(62);

        // Adding custom formula to Cell A1
        workbook.Worksheets[0].Cells["A1"].Formula = "=MyFunc(B1,C1:C5)";

        // Calcualting Formulas
        workbook.CalculateFormula(false, new CustomFunction());

        // Assign resultant value to Cell A1
        workbook.Worksheets[0].Cells["A1"].PutValue(workbook.Worksheets[0].Cells["A1"].Value);

        // Save the file
        workbook.Save(dataDir+ "UsingICustomFunction.out.xls");
        }
    }
}
        