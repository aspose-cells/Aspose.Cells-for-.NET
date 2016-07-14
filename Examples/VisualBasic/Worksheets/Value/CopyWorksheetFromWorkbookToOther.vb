Imports System.IO
Imports Aspose.Cells
Imports Microsoft.VisualBasic
Namespace Worksheets.Value
    Public Class CopyWorksheetFromWorkbookToOther
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a new Workbook.
            Dim excelWorkbook0 As New Workbook()

            ' Get the first worksheet in the book.
            Dim ws0 As Worksheet = excelWorkbook0.Worksheets(0)

            ' Put some data into header rows (A1:A4)
            For i As Integer = 0 To 4
                ws0.Cells(i, 0).PutValue(String.Format("Header Row {0}", i))
            Next

            ' Put some detail data (A5:A999)
            For i As Integer = 5 To 999
                ws0.Cells(i, 0).PutValue(String.Format("Detail Row {0}", i))
            Next

            ' Define a pagesetup object based on the first worksheet.
            Dim pagesetup As PageSetup = ws0.PageSetup

            ' The first five rows are repeated in each page...
            ' It can be seen in print preview.
            pagesetup.PrintTitleRows = "$1:$5"

            ' Create another Workbook.
            Dim excelWorkbook1 As New Workbook()

            ' Get the first worksheet in the book.
            Dim ws1 As Worksheet = excelWorkbook1.Worksheets(0)

            ' Name the worksheet.
            ws1.Name = "MySheet"

            ' Copy data from the first worksheet of the first workbook into the
            ' first worksheet of the second workbook.
            ws1.Copy(ws0)

            ' Save the excel file.
            excelWorkbook1.Save(dataDir & Convert.ToString("CopyWorksheetFromWorkbookToOther_out.xls"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace