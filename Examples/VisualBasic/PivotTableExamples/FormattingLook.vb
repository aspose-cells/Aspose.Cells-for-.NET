Option Infer On

Imports System.IO

Imports Aspose.Cells
Imports System.Drawing
Imports Aspose.Cells.Pivot

Namespace PivotTableExamples
    Public Class FormattingLook
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load a template file
            Dim workbook As New Workbook(dataDir & "Book1.xls")

            ' Get the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)
            Dim pivot = workbook.Worksheets(0).PivotTables(0)

            pivot.PivotTableStyleType = PivotTableStyleType.PivotTableStyleDark1

            Dim style As Style = workbook.CreateStyle()
            style.Font.Name = "Arial Black"
            style.ForegroundColor = Color.Yellow
            style.Pattern = BackgroundType.Solid

            pivot.FormatAll(style)

            ' Saving the Excel file
            workbook.Save(dataDir & "output.xls")

            ' ExEnd:1

        End Sub
    End Class
End Namespace
