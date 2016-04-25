Imports System.IO

Imports Aspose.Cells
Imports System.Drawing
Imports Aspose.Cells.Pivot

Namespace Aspose.Cells.Examples.PivotTableExamples
    Public Class ClearPivotFields
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Load a template file
            Dim workbook As New Workbook(dataDir & "Book1.xls")

            'Get the first worksheet
            Dim sheet As Worksheet = workbook.Worksheets(0)

            'Get the pivot tables in the sheet
            Dim pivotTables As PivotTableCollection = sheet.PivotTables


            'Get the first PivotTable
            Dim pivotTable As PivotTable = pivotTables(0)

            'Clear all the data fields
            pivotTable.DataFields.Clear()

            'Add new data field
            pivotTable.AddFieldToArea(PivotFieldType.Data, "Betrag Netto FW")

            'Set the refresh data flag on
            pivotTable.RefreshDataFlag = False

            'Refresh and calculate the pivot table data
            pivotTable.RefreshData()
            pivotTable.CalculateData()

            'Saving the Excel file
            workbook.Save(dataDir & "output.xls")

            'ExEnd:1

        End Sub
    End Class
End Namespace
