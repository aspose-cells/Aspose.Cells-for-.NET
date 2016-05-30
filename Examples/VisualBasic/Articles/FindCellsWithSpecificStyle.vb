Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles
    Public Class FindCellsWithSpecificStyle
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim filePath As String = dataDir & "TestBook.xlsx"

            Dim workbook As New Workbook(filePath)

            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access the style of cell A1
            Dim style As Style = worksheet.Cells("A1").GetStyle()

            ' Specify the style for searching
            Dim options As New FindOptions()
            options.Style = style

            Dim nextCell As Cell = Nothing

            Do
                ' Find the cell that has a style of cell A1
                nextCell = worksheet.Cells.Find(Nothing, nextCell, options)

                If nextCell Is Nothing Then
                    Exit Do
                End If

                ' Change the text of the cell
                nextCell.PutValue("Found")

            Loop While True

            workbook.Save(dataDir & "output.xlsx")
            ' ExEnd:1


        End Sub
    End Class
End Namespace