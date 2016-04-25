Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace Aspose.Cells.Examples.PivotTableExamples
    Public Class CreatePivotTable
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiating a Workbook object
            Dim workbook As New Workbook()

            'Obtaining the reference of the newly added worksheet
            Dim sheet As Worksheet = workbook.Worksheets(0)

            Dim cells As Cells = sheet.Cells

            'Setting the value to the cells
            Dim cell As Cell = cells("A1")
            cell.PutValue("Sport")
            cell = cells("B1")
            cell.PutValue("Quarter")
            cell = cells("C1")
            cell.PutValue("Sales")

            cell = cells("A2")
            cell.PutValue("Golf")
            cell = cells("A3")
            cell.PutValue("Golf")
            cell = cells("A4")
            cell.PutValue("Tennis")
            cell = cells("A5")
            cell.PutValue("Tennis")
            cell = cells("A6")
            cell.PutValue("Tennis")
            cell = cells("A7")
            cell.PutValue("Tennis")
            cell = cells("A8")
            cell.PutValue("Golf")

            cell = cells("B2")
            cell.PutValue("Qtr3")
            cell = cells("B3")
            cell.PutValue("Qtr4")
            cell = cells("B4")
            cell.PutValue("Qtr3")
            cell = cells("B5")
            cell.PutValue("Qtr4")
            cell = cells("B6")
            cell.PutValue("Qtr3")
            cell = cells("B7")
            cell.PutValue("Qtr4")
            cell = cells("B8")
            cell.PutValue("Qtr3")

            cell = cells("C2")
            cell.PutValue(1500)
            cell = cells("C3")
            cell.PutValue(2000)
            cell = cells("C4")
            cell.PutValue(600)
            cell = cells("C5")
            cell.PutValue(1500)
            cell = cells("C6")
            cell.PutValue(4070)
            cell = cells("C7")
            cell.PutValue(5000)
            cell = cells("C8")
            cell.PutValue(6430)

            Dim pivotTables As Aspose.Cells.Pivot.PivotTableCollection = sheet.PivotTables

            'Adding a PivotTable to the worksheet
            Dim index As Integer = pivotTables.Add("=A1:C8", "E3", "PivotTable2")

            'Accessing the instance of the newly added PivotTable
            Dim pivotTable As Aspose.Cells.Pivot.PivotTable = pivotTables(index)

            'Unshowing grand totals for rows.
            pivotTable.RowGrand = False

            'Draging the first field to the row area.
            pivotTable.AddFieldToArea(Aspose.Cells.Pivot.PivotFieldType.Row, 0)

            'Draging the second field to the column area.
            pivotTable.AddFieldToArea(Aspose.Cells.Pivot.PivotFieldType.Column, 1)

            'Draging the third field to the data area.
            pivotTable.AddFieldToArea(Aspose.Cells.Pivot.PivotFieldType.Data, 2)

            'Saving the Excel file
            workbook.Save(dataDir & "output.xls")

            'ExEnd:1

        End Sub
    End Class
End Namespace
