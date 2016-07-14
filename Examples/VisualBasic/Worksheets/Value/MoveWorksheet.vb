Imports System.IO
Imports Aspose.Cells
Imports Microsoft.VisualBasic
Namespace Worksheets.Value
    Public Class MoveWorksheet
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim InputPath As String = dataDir & Convert.ToString("book1.xls")

            ' Create a new Workbook.
            ' Open an existing excel file.
            Dim wb As New Workbook(InputPath)

            ' Create a Worksheets object with reference to
            ' the sheets of the Workbook.
            Dim sheets As WorksheetCollection = wb.Worksheets

            ' Get the first worksheet.
            Dim worksheet As Worksheet = sheets(0)

            ' Move the first sheet to the third position in the workbook.
            worksheet.MoveTo(2)

            ' Save the excel file.
            wb.Save(dataDir & Convert.ToString("MoveWorksheet_out.xls"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace
