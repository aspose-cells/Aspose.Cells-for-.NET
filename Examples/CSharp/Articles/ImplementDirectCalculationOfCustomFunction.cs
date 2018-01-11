using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    class ICustomEngine : AbstractCalculationEngine
    {
        // Override the Calculate method with custom logic
        public override void Calculate(CalculationData data)
        {
            // Check the forumla name and calculate it yourself
            if (data.FunctionName == "MyCompany.CustomFunction")
            {
                // This is our calculated value
                data.CalculatedValue = "Aspose.Cells.";
            }
        }
    }
    class ImplementDirectCalculationOfCustomFunction
    {
        public static void Run()
        {
            // Create a workbook
            Workbook wb = new Workbook();

            // Accesss first worksheet
            Worksheet ws = wb.Worksheets[0];

            // Add some text in cell A1
            ws.Cells["A1"].PutValue("Welcome to ");

            // Create a calculation options with custom engine
            CalculationOptions opts = new CalculationOptions();
            opts.CustomEngine = new ICustomEngine();

            // This line shows how you can call your own custom function without
            // a need to write it in any worksheet cell
            // After the execution of this line, it will return
            // Welcome to Aspose.Cells.
            object ret = ws.CalculateFormula("=A1 & MyCompany.CustomFunction()", opts);

            // Print the calculated value on Console
            Console.WriteLine("Calculated Value: " + ret);

            Console.WriteLine("ImplementDirectCalculationOfCustomFunction executed successfully.");
        }
    }
}
