Imports System.IO

Imports Aspose.Cells
Imports System.Drawing
Imports Aspose.Cells.Pivot

Namespace PivotTableExamples
    Public Class SettingAutoFormat
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load a template file
            Dim workbook As New Workbook(dataDir & "Book1.xls")

            Dim pivotindex As Integer = 0

            ' Get the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Accessing the PivotTable
            Dim pivotTable As PivotTable = worksheet.PivotTables(pivotindex)

            ' Setting the PivotTable report is automatically formatted
            pivotTable.IsAutoFormat = True

            ' Setting the PivotTable atuoformat type.
            pivotTable.AutoFormatType = Aspose.Cells.Pivot.PivotTableAutoFormatType.Report5

            ' Saving the Excel file
            workbook.Save(dataDir & "output.xls")

            ' ExEnd:1

        End Sub
    End Class
End Namespace
