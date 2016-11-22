Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles.DeleteBlankRowsColumns
    Public Class DeletingBlankRows
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Open an existing excel file.
            Dim wb As New Workbook(dataDir & "SampleInput.xlsx")

            ' Create a Worksheets object with reference to
            ' The sheets of the Workbook.
            Dim sheets As WorksheetCollection = wb.Worksheets

            ' Get first Worksheet from WorksheetCollection
            Dim sheet As Worksheet = sheets(0)

            ' Delete the Blank Rows from the worksheet
            sheet.Cells.DeleteBlankRows()

            ' Save the excel file.
            wb.Save(dataDir & "output.xlsx")
            ' ExEnd:1


        End Sub
    End Class
End Namespace