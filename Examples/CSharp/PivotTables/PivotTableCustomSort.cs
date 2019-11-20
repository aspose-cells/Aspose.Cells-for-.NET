using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aspose.Cells;
using Aspose.Cells.Pivot;

namespace Aspose.Cells.Examples.CSharp.PivotTables
{
    class PivotTableCustomSort
    {
        public static void Run()
        {
            // ExStart:1
            //Source directory
            string sourceDir = RunExamples.Get_SourceDirectory();
            string outputDir = RunExamples.Get_OutputDirectory();

            Workbook wb = new Workbook(sourceDir + "SamplePivotSort.xlsx");

            // Obtaining the reference of the newly added worksheet
            Worksheet sheet = wb.Worksheets[0];

            PivotTableCollection pivotTables = sheet.PivotTables;

            // source PivotTable
            // Adding a PivotTable to the worksheet
            int index = pivotTables.Add("=Sheet1!A1:C10", "E3", "PivotTable2");

            //Accessing the instance of the newly added PivotTable
            PivotTable pivotTable = pivotTables[index];

            // Unshowing grand totals for rows.
            pivotTable.RowGrand = false;
            pivotTable.ColumnGrand = false;

            // Dragging the first field to the row area.
            pivotTable.AddFieldToArea(PivotFieldType.Row, 1);
            PivotField rowField = pivotTable.RowFields[0];
            rowField.IsAutoSort = true;
            rowField.IsAscendSort = true;

            // Dragging the second field to the column area.
            pivotTable.AddFieldToArea(PivotFieldType.Column, 0);
            PivotField colField = pivotTable.ColumnFields[0];
            colField.NumberFormat = "dd/mm/yyyy";
            colField.IsAutoSort = true;
            colField.IsAscendSort = true;

            // Dragging the third field to the data area.
            pivotTable.AddFieldToArea(PivotFieldType.Data, 2);

            pivotTable.RefreshData();
            pivotTable.CalculateData();
            // end of source PivotTable


            // sort the PivotTable on "SeaFood" row field values
            // Adding a PivotTable to the worksheet
            index = pivotTables.Add("=Sheet1!A1:C10", "E10", "PivotTable2");

            // Accessing the instance of the newly added PivotTable
            pivotTable = pivotTables[index];

            // Unshowing grand totals for rows.
            pivotTable.RowGrand = false;
            pivotTable.ColumnGrand = false;

            // Dragging the first field to the row area.
            pivotTable.AddFieldToArea(PivotFieldType.Row, 1);
            rowField = pivotTable.RowFields[0];
            rowField.IsAutoSort = true;
            rowField.IsAscendSort = true;

            // Dragging the second field to the column area.
            pivotTable.AddFieldToArea(PivotFieldType.Column, 0);
            colField = pivotTable.ColumnFields[0];
            colField.NumberFormat = "dd/mm/yyyy";
            colField.IsAutoSort = true;
            colField.IsAscendSort = true;
            colField.AutoSortField = 0;


            //Dragging the third field to the data area.
            pivotTable.AddFieldToArea(PivotFieldType.Data, 2);

            pivotTable.RefreshData();
            pivotTable.CalculateData();
            // end of sort the PivotTable on "SeaFood" row field values


            // sort the PivotTable on "28/07/2000" column field values
            // Adding a PivotTable to the worksheet
            index = pivotTables.Add("=Sheet1!A1:C10", "E18", "PivotTable2");

            // Accessing the instance of the newly added PivotTable
            pivotTable = pivotTables[index];

            // Unshowing grand totals for rows.
            pivotTable.RowGrand = false;
            pivotTable.ColumnGrand = false;
            // Dragging the first field to the row area.
            pivotTable.AddFieldToArea(PivotFieldType.Row, 1);
            rowField = pivotTable.RowFields[0];
            rowField.IsAutoSort = true;
            rowField.IsAscendSort = true;
            rowField.AutoSortField = 0;

            // Dragging the second field to the column area.
            pivotTable.AddFieldToArea(PivotFieldType.Column, 0);
            colField = pivotTable.ColumnFields[0];
            colField.NumberFormat = "dd/mm/yyyy";
            colField.IsAutoSort = true;
            colField.IsAscendSort = true;


            // Dragging the third field to the data area.
            pivotTable.AddFieldToArea(PivotFieldType.Data, 2);

            pivotTable.RefreshData();
            pivotTable.CalculateData();
            // end of sort the PivotTable on "28/07/2000" column field values


            //Saving the Excel file
            wb.Save(outputDir + "out.xlsx");
            PdfSaveOptions options = new PdfSaveOptions();
            options.OnePagePerSheet = true;
            wb.Save(outputDir + "out.pdf", options);
            // ExEnd:1

            Console.WriteLine("PivotTableCustomSort executed successfully.");
        }
    }
}
