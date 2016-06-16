using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    // ExStart:ImplementCustomCalculationEngine
    // Create a new class derived from AbstractCalculationEngine
    class CustomEngine : AbstractCalculationEngine
    {
        // Override the Calculate method with custom logic
        public override void Calculate(CalculationData data)
        {
            // Check the forumla name and change the implementation
            if (data.FunctionName.ToUpper() == "SUM")
            {
                double val = (double)data.CalculatedValue;
                val = val + 30;

                // Assign the CalculationData.CalculatedValue
                data.CalculatedValue = val;
            }
        }
    }

    class ImplementCustomCalculationEngine
    {
        public static void Run()
        {
            // Create an instance of Workbook
            Workbook workbook = new Workbook();

            // Access first Worksheet from the collection
            Worksheet sheet = workbook.Worksheets[0];

            // Access Cell A1 and put a formula to sum values of B1 to B2
            Cell a1 = sheet.Cells["A1"];
            a1.Formula = "=Sum(B1:B2)";

            // Assign values to cells B1 & B2
            sheet.Cells["B1"].PutValue(10);
            sheet.Cells["B2"].PutValue(10);

            // Calculate all formulas in the Workbook 
            workbook.CalculateFormula();

            // The result of A1 should be 20 as per default calculation engine
            Console.WriteLine("The value of A1 with default calculation engine: " + a1.StringValue);

            // Create an instance of CustomEngine
            CustomEngine engine = new CustomEngine();

            // Create an instance of CalculationOptions
            CalculationOptions opts = new CalculationOptions();

            // Assign the CalculationOptions.CustomEngine property to the instance of CustomEngine
            opts.CustomEngine = engine;

            // Recalculate all formulas in Workbook using the custom calculation engine
            workbook.CalculateFormula(opts);

            // The result of A1 will be 50 as per custom calculation engine
            Console.WriteLine("The value of A1 with custom calculation engine: " + a1.StringValue);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
    // ExEnd:ImplementCustomCalculationEngine
}
