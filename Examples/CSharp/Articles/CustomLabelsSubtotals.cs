using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class CustomLabelsSubtotals
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Loads an existing spreadsheet containing some data
            Workbook book = new Workbook(sourceDir + "sampleCustomLabelsSubtotals.xlsx");

            // Assigns the GlobalizationSettings property of the WorkbookSettings class to the class created in first step
            book.Settings.GlobalizationSettings = new CustomSettings();

            // Accesses the 1st worksheet from the collection which contains data resides in the cell range A2:B9
            Worksheet sheet = book.Worksheets[0];

            // Adds Subtotal of type Average to the worksheet
            sheet.Cells.Subtotal(CellArea.CreateCellArea("A2", "B9"), 0, ConsolidationFunction.Average, new int[] { 1 });

            // Calculates Formulas
            book.CalculateFormula();

            // Auto fits all columns
            sheet.AutoFitColumns();

            // Saves the workbook on disc
            book.Save(outputDir + "outputCustomLabelsSubtotals.xlsx");

            Console.WriteLine("CustomLabelsSubtotals executed successfully.");
        }
    }


    // Defines a custom class derived from GlobalizationSettings class
    class CustomSettings : GlobalizationSettings
    {
        // Overrides the GetTotalName method
        public override string GetTotalName(ConsolidationFunction functionType)
        {
            // Checks the function type used to add the subtotals
            switch (functionType)
            {
                // Returns custom value based on the function type used to add the subtotals
                case ConsolidationFunction.Average:
                    return "AVG";
                // Handle other cases as per requirement
                default:
                    return base.GetTotalName(functionType);
            }
        }

        // Overrides the GetGrandTotalName method
        public override string GetGrandTotalName(ConsolidationFunction functionType)
        {
            // Checks the function type used to add the subtotals
            switch (functionType)
            {
                // Returns custom value based on the function type used to add the subtotals
                case ConsolidationFunction.Average:
                    return "GRD AVG";
                // Handle other cases as per requirement
                default:
                    return base.GetGrandTotalName(functionType);
            }
        }
    }

}
