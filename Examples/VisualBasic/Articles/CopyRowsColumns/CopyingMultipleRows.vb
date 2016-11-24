Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles.CopyRowsColumns
    Public Class CopyingMultipleRows
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create an instance of Workbook class by loading the existing spreadsheet
            Dim workbook As New Workbook(dataDir & Convert.ToString("aspose-sample.xlsx"))

            ' Get the cells collection of worksheet by name Rows
            Dim cells As Cells = workbook.Worksheets("Rows").Cells

            ' Copy the first 3 rows to 7th row
            cells.CopyRows(cells, 0, 6, 3)

            ' Save the result on disc
            workbook.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace