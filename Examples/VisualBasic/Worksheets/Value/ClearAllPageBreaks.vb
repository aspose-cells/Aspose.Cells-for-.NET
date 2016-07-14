Imports System.IO
Imports Aspose.Cells

Namespace Worksheets.Value
    Public Class ClearAllPageBreaks
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiating a Workbook object
            Dim workbook As New Workbook()

            ' Clearing all page breaks
            workbook.Worksheets(0).HorizontalPageBreaks.Clear()
            workbook.Worksheets(0).VerticalPageBreaks.Clear()

            ' Save the Excel file.
            workbook.Save(dataDir & Convert.ToString("ClearAllPageBreaks_out.xls"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace