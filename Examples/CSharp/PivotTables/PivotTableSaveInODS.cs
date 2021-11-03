using System;
using Aspose.Cells.Pivot;

namespace Aspose.Cells.Examples.CSharp.PivotTables
{
    class PivotTableSaveInODS
    {
        public static void Run()
        {
            // ExStart:1
            string outputDir = RunExamples.Get_OutputDirectory();

            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Obtaining the reference of the newly added worksheet
            Worksheet sheet = workbook.Worksheets[0];

            Cells cells = sheet.Cells;

            // Setting the value to the cells
            Cell cell = cells["A1"];
            cell.PutValue("Sport");
            cell = cells["B1"];
            cell.PutValue("Quarter");
            cell = cells["C1"];
            cell.PutValue("Sales");

            cell = cells["A2"];
            cell.PutValue("Golf");
            cell = cells["A3"];
            cell.PutValue("Golf");
            cell = cells["A4"];
            cell.PutValue("Tennis");
            cell = cells["A5"];
            cell.PutValue("Tennis");
            cell = cells["A6"];
            cell.PutValue("Tennis");
            cell = cells["A7"];
            cell.PutValue("Tennis");
            cell = cells["A8"];
            cell.PutValue("Golf");

            cell = cells["B2"];
            cell.PutValue("Qtr3");
            cell = cells["B3"];
            cell.PutValue("Qtr4");
            cell = cells["B4"];
            cell.PutValue("Qtr3");
            cell = cells["B5"];
            cell.PutValue("Qtr4");
            cell = cells["B6"];
            cell.PutValue("Qtr3");
            cell = cells["B7"];
            cell.PutValue("Qtr4");
            cell = cells["B8"];
            cell.PutValue("Qtr3");

            cell = cells["C2"];
            cell.PutValue(1500);
            cell = cells["C3"];
            cell.PutValue(2000);
            cell = cells["C4"];
            cell.PutValue(600);
            cell = cells["C5"];
            cell.PutValue(1500);
            cell = cells["C6"];
            cell.PutValue(4070);
            cell = cells["C7"];
            cell.PutValue(5000);
            cell = cells["C8"];
            cell.PutValue(6430);

            PivotTableCollection pivotTables = sheet.PivotTables;

            // Adding a PivotTable to the worksheet
            int index = pivotTables.Add("=A1:C8", "E3", "PivotTable2");

            // Accessing the instance of the newly added PivotTable
            PivotTable pivotTable = pivotTables[index];

            // Unshowing grand totals for rows.
            pivotTable.RowGrand = false;

            // Draging the first field to the row area.
            pivotTable.AddFieldToArea(PivotFieldType.Row, 0);

            // Draging the second field to the column area.
            pivotTable.AddFieldToArea(PivotFieldType.Column, 1);

            // Draging the third field to the data area.
            pivotTable.AddFieldToArea(PivotFieldType.Data, 2);

            pivotTable.CalculateData();

            // Saving the ods file
            workbook.Save(outputDir + "PivotTableSaveInODS_out.ods");
            // ExEnd:1

            Console.WriteLine("PivotTableSaveInODS executed successfully.");
        }
    }
}
