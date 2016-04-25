Imports System.IO

Imports Aspose.Cells
Imports System.Drawing
Imports Aspose.Cells.Pivot

Namespace Aspose.Cells.Examples.PivotTableExamples
    Public Class SettingPageFieldFormat
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Load a template file
            Dim workbook As New Workbook(dataDir & "Book1.xls")

            'Get the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)
            Dim pivotindex As Integer = 0

            'Accessing the PivotTable
            Dim pivotTable As PivotTable = worksheet.PivotTables(pivotindex)

            'Setting the PivotTable report shows grand totals for rows.
            pivotTable.RowGrand = True

            'Accessing the row fields.
            Dim pivotFields As Aspose.Cells.Pivot.PivotFieldCollection = pivotTable.RowFields

            'Accessing the first row field in the row fields.
            Dim pivotField As Aspose.Cells.Pivot.PivotField = pivotFields(0)

            'Setting Subtotals.
            pivotField.SetSubtotals(Aspose.Cells.Pivot.PivotFieldSubtotalType.Sum, True)
            pivotField.SetSubtotals(Aspose.Cells.Pivot.PivotFieldSubtotalType.Count, True)

            'Setting autosort options.
            'Setting the field auto sort.
            pivotField.IsAutoSort = True

            'Setting the field auto sort ascend.
            pivotField.IsAscendSort = True

            'Setting the field auto sort using the field itself.
            pivotField.AutoSortField = -5

            'Setting autoShow options.
            'Setting the field auto show.
            pivotField.IsAutoShow = True

            'Setting the field auto show ascend.
            pivotField.IsAscendShow = False

            'Setting the auto show using field(data field).
            pivotField.AutoShowField = 0

            'Saving the Excel file
            workbook.Save(dataDir & "output.xls")

            'ExEnd:1

        End Sub
    End Class
End Namespace
