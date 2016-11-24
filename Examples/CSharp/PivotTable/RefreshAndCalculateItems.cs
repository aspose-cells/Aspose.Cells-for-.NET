using System.IO;
using Aspose.Cells.Pivot;
using Aspose.Cells;
using System.Drawing;

namespace Aspose.Cells.Examples.CSharp.PivotTableExamples
{
    public class RefreshAndCalculateItems
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Load source excel file containing a pivot table having calculated items
            Workbook wb = new Workbook(dataDir + "sample.xlsx");

            // Access first worksheet
            Worksheet sheet = wb.Worksheets[0];

            // Change the value of cell D2
            sheet.Cells["D2"].PutValue(20);

            // Refresh and calculate all the pivot tables inside this sheet
            foreach (PivotTable pt in sheet.PivotTables)
            {
                pt.RefreshData();
                pt.CalculateData();
            }

            // Save the workbook in output pdf
            wb.Save(dataDir + "RefreshAndCalculateItems_out.pdf", SaveFormat.Pdf);
            // ExEnd:1

        }
    }
}