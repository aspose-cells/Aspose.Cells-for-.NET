using System.IO;
using System;
using Aspose.Cells;
using Aspose.Cells.Pivot;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.PivotTableExamples
{
    public class SpecifyCompatibility
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load source excel file containing sample pivot table
            Workbook wb = new Workbook(dataDir + "sample-pivot-table.xlsx");

            // Access first worksheet that contains pivot table data
            Worksheet dataSheet = wb.Worksheets[0];

            // Access cell A3 and sets its data
            Cells cells = dataSheet.Cells;
            Cell cell = cells["A3"];
            cell.PutValue("FooBar");

            // Access cell B3, sets its data. We set B3 a very long string which has more than 255 characters
            string longStr = "Very long text 1. very long text 2. very long text 3. very long text 4. very long text 5. very long text 6. very long text 7. very long text 8. very long text 9. very long text 10. very long text 11. very long text 12. very long text 13. very long text 14. very long text 15. very long text 16. very long text 17. very long text 18. very long text 19. very long text 20. End of text.";
            cell = cells["B3"];
            cell.PutValue(longStr);

            // Print the length of cell B3 string
            Console.WriteLine("Length of original data string: " + cell.StringValue.Length);

            // Access cell C3 and sets its data
            cell = cells["C3"];
            cell.PutValue("closed");

            // Access cell D3 and sets its data
            cell = cells["D3"];
            cell.PutValue("2016/07/21");

            // Access the second worksheet that contains pivot table
            Worksheet pivotSheet = wb.Worksheets[1];

            // Access the pivot table
            PivotTable pivotTable = pivotSheet.PivotTables[0];

            // IsExcel2003Compatible property tells if PivotTable is compatible for Excel2003 while refreshing PivotTable.
            // If it is true, a string must be less than or equal to 255 characters, so if the string is greater than 255 characters,
            // it will be truncated. If false, a string will not have the aforementioned restriction. The default value is true.
            pivotTable.IsExcel2003Compatible = true;
            pivotTable.RefreshData();
            pivotTable.CalculateData();

            // Check the value of cell B5 of pivot sheet.
            // It will be 255 because we have set IsExcel2003Compatible property to true. All the data after 255 characters has been truncated
            Cell b5 = pivotSheet.Cells["B5"];
            Console.WriteLine("Length of cell B5 after setting IsExcel2003Compatible property to True: " + b5.StringValue.Length);

            // Now set IsExcel2003Compatible property to false and again refresh
            pivotTable.IsExcel2003Compatible = false;
            pivotTable.RefreshData();
            pivotTable.CalculateData();

            // Now it will print 383 the original length of cell data. The data has not been truncated now.
            b5 = pivotSheet.Cells["B5"];
            Console.WriteLine("Length of cell B5 after setting IsExcel2003Compatible property to False: " + b5.StringValue.Length);

            // Set the row height and column width of cell B5 and also wrap its text
            pivotSheet.Cells.SetRowHeight(b5.Row, 100);
            pivotSheet.Cells.SetColumnWidth(b5.Column, 65);
            Style st = b5.GetStyle();
            st.IsTextWrapped = true;
            b5.SetStyle(st);

            // Save workbook in xlsx format
            wb.Save(dataDir + "SpecifyCompatibility_out_.xlsx", SaveFormat.Xlsx);
            // ExEnd:
        }
    }
}