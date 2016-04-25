using System.IO;

using Aspose.Cells;
using System.Drawing;
using Aspose.Cells.Pivot;

namespace Aspose.Cells.Examples.PivotTableExamples
{
    public class SettingPageFieldFormat
    {
        public static void Main(string[] args)
        {
            //ExStart:1
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //Load a template file
            Workbook workbook = new Workbook(dataDir + "Book1.xls");

            //Get the first worksheet
            Worksheet worksheet = workbook.Worksheets[0];
            int pivotindex = 0;

            //Accessing the PivotTable
            PivotTable pivotTable = worksheet.PivotTables[pivotindex];

            //Setting the PivotTable report shows grand totals for rows.
            pivotTable.RowGrand = true;

            //Accessing the row fields.
            Aspose.Cells.Pivot.PivotFieldCollection pivotFields = pivotTable.RowFields;

            //Accessing the first row field in the row fields.
            Aspose.Cells.Pivot.PivotField pivotField = pivotFields[0];

            //Setting Subtotals.
            pivotField.SetSubtotals(Aspose.Cells.Pivot.PivotFieldSubtotalType.Sum, true);
            pivotField.SetSubtotals(Aspose.Cells.Pivot.PivotFieldSubtotalType.Count, true);

            //Setting autosort options.
            //Setting the field auto sort.
            pivotField.IsAutoSort = true;

            //Setting the field auto sort ascend.
            pivotField.IsAscendSort = true;

            //Setting the field auto sort using the field itself.
            pivotField.AutoSortField = -5;

            //Setting autoShow options.
            //Setting the field auto show.
            pivotField.IsAutoShow = true;

            //Setting the field auto show ascend.
            pivotField.IsAscendShow = false;

            //Setting the auto show using field(data field).
            pivotField.AutoShowField = 0;

            //Saving the Excel file
            workbook.Save(dataDir + "output.xls");

            //ExEnd:1

        }
    }
}