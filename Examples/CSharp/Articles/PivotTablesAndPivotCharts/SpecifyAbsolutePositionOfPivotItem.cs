using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells.Pivot;

namespace Aspose.Cells.Examples.CSharp.Articles.PivotTablesAndPivotCharts
{
    public class SpecifyAbsolutePositionOfPivotItem
    {
        public static void Run()
        {
            // ExStart:SpecifyAbsolutePositionOfPivotItem
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Workbook wb = new Workbook(dataDir + "source.xlsx");
            Worksheet wsPivot = wb.Worksheets.Add("pvtNew Hardware");
            Worksheet wsData = wb.Worksheets["New Hardware - Yearly"];

            // Get the pivottables collection for the pivot sheet
            PivotTableCollection pivotTables = wsPivot.PivotTables;

            // Add PivotTable to the worksheet
            int index = pivotTables.Add("='New Hardware - Yearly'!A1:D621", "A3", "HWCounts_PivotTable");

            // Get the PivotTable object
            PivotTable pvtTable = pivotTables[index];

            // Add vendor row field
            pvtTable.AddFieldToArea(PivotFieldType.Row, "Vendor");

            // Add item row field
            pvtTable.AddFieldToArea(PivotFieldType.Row, "Item");

            // Add data field
            pvtTable.AddFieldToArea(PivotFieldType.Data, "2014");

            // Turn off the subtotals for the vendor row field
            PivotField pivotField = pvtTable.RowFields["Vendor"];
            pivotField.SetSubtotals(PivotFieldSubtotalType.None, true);

            // Turn off grand total
            pvtTable.ColumnGrand = false;

            /*
             * Please call the PivotTable.RefreshData() and PivotTable.CalculateData()
             * before using PivotItem.Position,
             * PivotItem.PositionInSameParentNode and PivotItem.Move(int count, bool isSameParent).
            */
            pvtTable.RefreshData();
            pvtTable.CalculateData();

            pvtTable.RowFields["Item"].PivotItems["4H12"].PositionInSameParentNode = 0;
            pvtTable.RowFields["Item"].PivotItems["DIF400"].PositionInSameParentNode = 3;

            /* 
             * As a result of using PivotItem.PositionInSameParentNode,
             * it will change the original sort sequence.
             * So when you use PivotItem.PositionInSameParentNode in another parent node.
             * You need call the method named "CalculateData" again. 
            */
            pvtTable.CalculateData();

            pvtTable.RowFields["Item"].PivotItems["CA32"].PositionInSameParentNode = 1;
            pvtTable.RowFields["Item"].PivotItems["AAA3"].PositionInSameParentNode = 2;

            // Save file
            wb.Save(dataDir + "output_out_.xlsx");
            // ExEnd:SpecifyAbsolutePositionOfPivotItem
        }
    }
}
