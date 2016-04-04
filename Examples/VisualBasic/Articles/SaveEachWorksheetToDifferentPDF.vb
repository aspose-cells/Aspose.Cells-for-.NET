Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class SaveEachWorksheetToDifferentPDF
        Public Shared Sub Main()
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)


            'Get the Excel file path
            Dim filePath As String = dataDir & "input.xlsx"

            'Instantiage a new workbook and open the Excel
            'File from its location
            Dim workbook As New Workbook(filePath)

            'Get the count of the worksheets in the workbook
            Dim sheetCount As Integer = workbook.Worksheets.Count

            'Make all sheets invisible except first worksheet
            For i As Integer = 1 To workbook.Worksheets.Count - 1
                workbook.Worksheets(i).IsVisible = False
            Next i

            'Take Pdfs of each sheet
            For j As Integer = 0 To workbook.Worksheets.Count - 1
                Dim ws As Worksheet = workbook.Worksheets(j)
                workbook.Save(dataDir & "worksheet-" & ws.Name & ".output.pdf")

                If j < workbook.Worksheets.Count - 1 Then
                    workbook.Worksheets(j + 1).IsVisible = True
                    workbook.Worksheets(j).IsVisible = False
                End If
            Next j
            'ExEnd:1



        End Sub
    End Class
End Namespace