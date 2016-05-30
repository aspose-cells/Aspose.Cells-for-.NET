using System.IO;
using System;
using Aspose.Cells;

namespace CSharp.Articles
{
    public class CreateManipulateRemoveScenarios
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // Instantiate the Workbook
            // Load an Excel file
            Workbook workbook = new Workbook(dataDir+ "aspose-sample.xlsx");
            // Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            if (worksheet.Scenarios.Count > 0)
            {
                // Remove the existing first scenario from the sheet
                worksheet.Scenarios.RemoveAt(0);


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

                dataDir = dataDir + "outBk_scenarios1.out.xlsx";

                // Save the Excel file.
                workbook.Save(dataDir);               
                Console.WriteLine("\nProcess completed successfully.\nFile saved at " + dataDir);
            }
            // ExEnd:1
            
        }
    }
}
