Imports System.IO
Imports Aspose.Cells

Namespace Worksheets.Value
    Public Class RemoveSpecificPageBreak
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiating a Workbook object
            Dim workbook As New Workbook(dataDir & Convert.ToString("PageBreaks.xls"))

            ' Removing a specific page break
            workbook.Worksheets(0).HorizontalPageBreaks.RemoveAt(0)
            workbook.Worksheets(0).VerticalPageBreaks.RemoveAt(0)

            ' Save the Excel file.
            workbook.Save(dataDir & Convert.ToString("RemoveSpecificPageBreak_out.xls"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace