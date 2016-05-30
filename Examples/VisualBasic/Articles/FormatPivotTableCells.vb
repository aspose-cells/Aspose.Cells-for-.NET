Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Pivot
Imports System.Drawing

Namespace Articles
    Public Class FormatPivotTableCells
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim filePath As String = dataDir & "pivotTable_test.xlsx"

            ' Create workbook object from source file containing pivot table
            Dim workbook As New Workbook(filePath)

            ' Access the worksheet by its name
            Dim worksheet As Worksheet = workbook.Worksheets("PivotTable")

            ' Access the pivot table
            Dim pivotTable As PivotTable = worksheet.PivotTables(0)

            ' Create a style object with background color light blue
            Dim style As Style = workbook.CreateStyle()
            style.Pattern = BackgroundType.Solid
            style.BackgroundColor = Color.LightBlue

            ' Format entire pivot table with light blue color
            pivotTable.FormatAll(style)

            ' Create another style object with yellow color
            style = workbook.CreateStyle()
            style.Pattern = BackgroundType.Solid
            style.BackgroundColor = Color.Yellow

            ' Format the cells of the first row of the pivot table with yellow color
            For col As Integer = 0 To 4
                pivotTable.Format(1, col, style)
            Next col

            ' Save the workbook object
            workbook.Save(dataDir & "output.xlsx")
            ' ExEnd:1

        End Sub
    End Class
End Namespace