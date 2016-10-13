Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Cells
Imports System
Imports Aspose.Cells.Pivot

Namespace Articles.PivotTablesAndPivotCharts
    Public Class SpecifyAbsolutePositionOfPivotItem
        Public Shared Sub Run()
            ' ExStart:SpecifyAbsolutePositionOfPivotItem
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim wb As New Workbook(dataDir & Convert.ToString("source.xlsx"))
            Dim wsPivot As Worksheet = wb.Worksheets.Add("pvtNew Hardware")
            Dim wsData As Worksheet = wb.Worksheets("New Hardware - Yearly")

            ' Get the pivottables collection for the pivot sheet
            Dim pivotTables As PivotTableCollection = wsPivot.PivotTables

            ' Add PivotTable to the worksheet
            Dim index As Integer = pivotTables.Add("='New Hardware - Yearly'!A1:D621", "A3", "HWCounts_PivotTable")

            ' Get the PivotTable object
            Dim pvtTable As PivotTable = pivotTables(index)

            ' Add vendor row field
            pvtTable.AddFieldToArea(PivotFieldType.Row, "Vendor")

            ' Add item row field
            pvtTable.AddFieldToArea(PivotFieldType.Row, "Item")

            ' Add data field
            pvtTable.AddFieldToArea(PivotFieldType.Data, "2014")

            ' Turn off the subtotals for the vendor row field
            Dim pivotField As PivotField = pvtTable.RowFields("Vendor")
            pivotField.SetSubtotals(PivotFieldSubtotalType.None, True)

            ' Turn off grand total
            pvtTable.ColumnGrand = False

            ' Please call the PivotTable.RefreshData() and PivotTable.CalculateData()
            ' before using PivotItem.Position,
            ' PivotItem.PositionInSameParentNode and PivotItem.Move(int count, bool isSameParent).          
            pvtTable.RefreshData()
            pvtTable.CalculateData()

            pvtTable.RowFields("Item").PivotItems("4H12").PositionInSameParentNode = 0
            pvtTable.RowFields("Item").PivotItems("DIF400").PositionInSameParentNode = 3

            ' As a result of using PivotItem.PositionInSameParentNode,
            ' it will change the original sort sequence.
            ' So when you use PivotItem.PositionInSameParentNode in another parent node.
            ' You need call the method named "CalculateData" again.       

            pvtTable.CalculateData()

            pvtTable.RowFields("Item").PivotItems("CA32").PositionInSameParentNode = 1
            pvtTable.RowFields("Item").PivotItems("AAA3").PositionInSameParentNode = 2

            ' Save file
            wb.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:SpecifyAbsolutePositionOfPivotItem
        End Sub
    End Class
End Namespace