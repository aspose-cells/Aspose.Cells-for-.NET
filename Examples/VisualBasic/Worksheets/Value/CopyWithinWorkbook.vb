Imports System.IO
Imports Aspose.Cells
Imports Microsoft.VisualBasic
Namespace Worksheets.Value
    Public Class CopyWithinWorkbook
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim InputPath As String = dataDir & Convert.ToString("book1.xls")

            ' Create a new Workbook.
            ' Open an existing Excel file.
            Dim wb As New Workbook(InputPath)

            ' Create a Worksheets object with reference to
            ' the sheets of the Workbook.
            Dim sheets As WorksheetCollection = wb.Worksheets

            ' Copy data to a new sheet from an existing
            ' sheet within the Workbook.
            sheets.AddCopy("Sheet1")

            ' Save the Excel file.
            wb.Save(dataDir & Convert.ToString("CopyWithinWorkbook_out.xls"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace
