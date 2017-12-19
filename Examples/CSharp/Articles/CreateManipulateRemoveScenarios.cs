using System.IO;
using System;
using Aspose.Cells;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class CreateManipulateRemoveScenarios
    {
        public static void Run()
        {
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();

            //Output directory
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiate the Workbook - load an Excel file
            Workbook workbook = new Workbook(sourceDir + "sampleCreateManipulateRemoveScenarios.xlsx");

            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Create a scenario
            int i = worksheet.Scenarios.Add("MyScenario");

            // Get the scenario
            Scenario scenario = worksheet.Scenarios[i];

            // Add comment to it
            scenario.Comment = "Test sceanrio is created.";

            // Get the input cells for the scenario
            ScenarioInputCellCollection sic = scenario.InputCells;

            // Add the scenario on B4 (as changing cell) with default value
            sic.Add(3, 1, "1100000");

            // Save the Excel file.
            workbook.Save(outputDir + "outputCreateManipulateRemoveScenarios.xlsx");

            Console.WriteLine("CreateManipulateRemoveScenarios executed successfully.\r\n");
        }
    }
}
