Imports System.IO
Imports Aspose.Cells
Imports Microsoft.VisualBasic
Namespace Worksheets.Value
    Public Class CopyWorksheetsBetweenWorkbooks
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim InputPath As String = dataDir & Convert.ToString("book1.xls")

            ' Create a Workbook.
            ' Open a file into the first book.
            Dim excelWorkbook0 As New Workbook(InputPath)

            ' Create another Workbook.
            Dim excelWorkbook1 As New Workbook()

            ' Copy the first sheet of the first book into second book.
            excelWorkbook1.Worksheets(0).Copy(excelWorkbook0.Worksheets(0))

            ' Save the file.
            excelWorkbook1.Save(dataDir & Convert.ToString("CopyWorksheetsBetweenWorkbooks_out.xls"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace