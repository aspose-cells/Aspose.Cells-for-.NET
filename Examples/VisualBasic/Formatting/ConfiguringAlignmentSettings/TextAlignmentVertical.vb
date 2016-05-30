Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Formatting.ConfiguringAlignmentSettings
    Public Class TextAlignmentVertical
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Instantiating a Workbook object
            Dim workbook As New Workbook()

            ' Clearing all the worksheets
            workbook.Worksheets.Clear()

            ' Adding a new worksheet to the Excel object
            Dim i As Integer = workbook.Worksheets.Add()

            ' Obtaining the reference of the newly added worksheet by passing its sheet index
            Dim worksheet As Worksheet = workbook.Worksheets(i)

            ' Accessing the "A1" cell from the worksheet
            Dim cell As Global.Aspose.Cells.Cell = worksheet.Cells("A1")

            ' Adding some value to the "A1" cell
            cell.PutValue("Visit Aspose!")

            ' Setting the horizontal alignment of the text in the "A1" cell
            Dim style As Style = cell.GetStyle()

            ' Setting the vertical alignment of the text in a cell
            style.VerticalAlignment = TextAlignmentType.Center

            cell.SetStyle(style)

            ' Saving the Excel file
            workbook.Save(dataDir & "output.xls", SaveFormat.Excel97To2003)
            ' ExEnd:1

        End Sub
    End Class
End Namespace