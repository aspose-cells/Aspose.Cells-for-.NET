Imports System.IO

Imports Aspose.Cells
Imports System.Drawing
Imports Aspose.Cells.Pivot

Namespace Aspose.Cells.Examples.PivotTableExamples
    Public Class SettingDataFieldFormat
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
            'Accessing the data fields.
            Dim pivotFields As Aspose.Cells.Pivot.PivotFieldCollection = pivotTable.DataFields

            'Accessing the first data field in the data fields.
            Dim pivotField As Aspose.Cells.Pivot.PivotField = pivotFields(0)

            'Setting data display format
            pivotField.DataDisplayFormat = Aspose.Cells.Pivot.PivotFieldDataDisplayFormat.PercentageOf

            'Setting the base field.
            pivotField.BaseField = 1

            'Setting the base item.
            pivotField.BaseItemPosition = Aspose.Cells.Pivot.PivotItemPosition.Next

            'Setting number format
            pivotField.Number = 10
            'Saving the Excel file
            workbook.Save(dataDir & "output.xls")

            'ExEnd:1

        End Sub
    End Class
End Namespace
