using System.IO;

using Aspose.Cells;
using System.Drawing;
using Aspose.Cells.Pivot;

namespace CSharp.PivotTableExamples
{
    public class ClearPivotFields
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load a template file
            Workbook workbook = new Workbook(dataDir + "Book1.xls");

            // Get the first worksheet
            Worksheet sheet = workbook.Worksheets[0];

            // Get the pivot tables in the sheet
            PivotTableCollection pivotTables = sheet.PivotTables;


            // Get the first PivotTable
            PivotTable pivotTable = pivotTables[0];

            // Clear all the data fields
            pivotTable.DataFields.Clear();

            // Add new data field
            pivotTable.AddFieldToArea(PivotFieldType.Data, "Betrag Netto FW");

            // Set the refresh data flag on
            pivotTable.RefreshDataFlag = false;

            // Refresh and calculate the pivot table data
            pivotTable.RefreshData();
            pivotTable.CalculateData();

            // Saving the Excel file
            workbook.Save(dataDir + "output.xls");

            // ExEnd:1

        }
    }
}