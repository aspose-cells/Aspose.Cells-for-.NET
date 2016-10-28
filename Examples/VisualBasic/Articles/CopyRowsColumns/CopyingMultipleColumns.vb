Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles.CopyRowsColumns
    Public Class CopyingMultipleColumns
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create an instance of Workbook class by loading the existing spreadsheet
            Dim workbook As New Workbook(dataDir & Convert.ToString("aspose-sample.xlsx"))

            ' Get the cells collection of worksheet by name Columns
            Dim cells As Cells = workbook.Worksheets("Columns").Cells

            ' Copy the first 3 columns 7th column
            cells.CopyColumns(cells, 0, 6, 3)

            ' Save the result on disc
            workbook.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace