Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Cells
Imports System
Imports Aspose.Cells.Pivot
Imports System.Drawing

Namespace Articles.PivotTablesAndPivotCharts
    Public Class GetCellByDisplayName
        Public Shared Sub Run()
            ' ExStart:GetCellObjectByDisplayName
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object from source excel file
            Dim workbook As New Workbook(dataDir & Convert.ToString("source.xlsx"))

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access first pivot table inside the worksheet
            Dim pivotTable As PivotTable = worksheet.PivotTables(0)

            ' Access cell by display name of 2nd data field of the pivot table
            Dim cell As Cell = pivotTable.GetCellByDisplayName(pivotTable.DataFields(0).DisplayName)

            ' Access cell style and set its fill color and font color
            Dim style As Style = cell.GetStyle()
            style.ForegroundColor = Color.LightBlue
            style.Font.Color = Color.Black

            ' Set the style of the cell
            pivotTable.Format(cell.Row, cell.Column, style)

            ' Save workbook
            workbook.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:GetCellObjectByDisplayName
        End Sub
    End Class
End Namespace