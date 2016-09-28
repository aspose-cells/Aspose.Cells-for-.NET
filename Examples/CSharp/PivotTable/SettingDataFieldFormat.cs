using System.IO;

using Aspose.Cells;
using System.Drawing;
using Aspose.Cells.Pivot;

namespace Aspose.Cells.Examples.CSharp.PivotTableExamples
{
    public class SettingDataFieldFormat
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load a template file
            Workbook workbook = new Workbook(dataDir + "Book1.xls");

            // Get the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];
            int pivotindex = 0;

            // Accessing the PivotTable
            PivotTable pivotTable = worksheet.PivotTables[pivotindex];
            // Accessing the data fields.
            Aspose.Cells.Pivot.PivotFieldCollection pivotFields = pivotTable.DataFields;

            // Accessing the first data field in the data fields.
            Aspose.Cells.Pivot.PivotField pivotField = pivotFields[0];

            // Setting data display format
            pivotField.DataDisplayFormat = Aspose.Cells.Pivot.PivotFieldDataDisplayFormat.PercentageOf;

            // Setting the base field.
            pivotField.BaseFieldIndex = 1;

            // Setting the base item.
            pivotField.BaseItemPosition = Aspose.Cells.Pivot.PivotItemPosition.Next;

            // Setting number format
            pivotField.Number = 10;
            // Saving the Excel file
            workbook.Save(dataDir + "output.xls");

            // ExEnd:1

        }
    }
}