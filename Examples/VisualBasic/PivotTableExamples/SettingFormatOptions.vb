Imports System.IO

Imports Aspose.Cells
Imports System.Drawing
Imports Aspose.Cells.Pivot

Namespace Aspose.Cells.Examples.PivotTableExamples
    Public Class SettingFormatOptions
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

            'Setting the PivotTable report shows grand totals for columns.
            pivotTable.ColumnGrand = True

            'Setting the PivotTable report displays a custom string in cells that contain null values.
            pivotTable.DisplayNullString = True
            pivotTable.NullString = "null"

            'Setting the PivotTable report's layout
            pivotTable.PageFieldOrder = PrintOrderType.DownThenOver

            'Saving the Excel file
            workbook.Save(dataDir & "output.xls")

            'ExEnd:1

        End Sub
    End Class
End Namespace
