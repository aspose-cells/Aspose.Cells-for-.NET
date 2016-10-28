using System;
using Aspose.Cells;
using System.Data;

namespace Aspose.Cells.Examples.CSharp.Articles
{
    public class GetSmartMarkerNotifications
    {
        public static void Run()
        {
            // ExStart:1
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string outputPath = dataDir + "Output.out.xlsx";

            // Creating a DataTable that will serve as data source for designer spreadsheet
            DataTable table = new DataTable("OppLineItems");
            table.Columns.Add("PRODUCT_FAMILY");
            table.Columns.Add("OPPORTUNITY_LINEITEM_PRODUCTNAME");
            table.Rows.Add(new object[] { "MMM", "P1" });
            table.Rows.Add(new object[] { "MMM", "P2" });
            table.Rows.Add(new object[] { "DDD", "P1" });
            table.Rows.Add(new object[] { "DDD", "P2" });
            table.Rows.Add(new object[] { "AAA", "P1" });

            // Loading the designer spreadsheet in an instance of Workbook
            Workbook workbook = new Workbook(dataDir + "source.xlsx");

            // Loading the instance of Workbook in an instance of WorkbookDesigner
            WorkbookDesigner designer = new WorkbookDesigner(workbook);

            // Set the WorkbookDesigner.CallBack property to an instance of newly created class
            designer.CallBack = new SmartMarkerCallBack(workbook);

            // Set the data source 
            designer.SetDataSource(table);

            // Process the Smart Markers in the designer spreadsheet
            designer.Process(false);

            // Save the result
            workbook.Save(outputPath);
            // ExEnd:1
        }
    }

    // ExStart:ISmartMarkerCallBack
    class SmartMarkerCallBack: ISmartMarkerCallBack
    {
        Workbook workbook;

        public SmartMarkerCallBack(Workbook workbook) {
            this.workbook = workbook;
        }

        public void Process(int sheetIndex, int rowIndex, int colIndex, String tableName, String columnName) {
            Console.WriteLine("Processing Cell: " + workbook.Worksheets[sheetIndex].Name + "!" + CellsHelper.CellIndexToName(rowIndex, colIndex));
            Console.WriteLine("Processing Marker: " + tableName + "." + columnName);
        }
    }
    // ExEnd:ISmartMarkerCallBack
}
