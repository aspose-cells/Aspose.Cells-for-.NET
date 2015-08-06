//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class CreateManipulateRemoveScenarios
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //Instantiate the Workbook
            //Load an Excel file
            Workbook workbook = new Workbook(dataDir+ "aspose-sample.xlsx");
            //Access first worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            //Remove the existing first scenario from the sheet
            worksheet.Scenarios.RemoveAt(0);


            //Create a scenario
            int i = worksheet.Scenarios.Add("MyScenario");
            //Get the scenario
            Scenario scenario = worksheet.Scenarios[i];
            //Add comment to it
            scenario.Comment = "Test sceanrio is created.";
            //Get the input cells for the scenario
            ScenarioInputCellCollection sic = scenario.InputCells;
            //Add the scenario on B4 (as changing cell) with default value
            sic.Add(3, 1, "1100000");


            //Save the Excel file.
            workbook.Save(dataDir+ "outBk_scenarios1.xlsx");
            
        }
    }
}