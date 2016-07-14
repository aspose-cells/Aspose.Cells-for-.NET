Imports System.IO
Imports Aspose.Cells

Namespace Worksheets.Value
    Public Class AddingPageBreaks
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiating a Workbook object
            Dim workbook As New Workbook()

            ' Add a page break at cell Y30
            workbook.Worksheets(0).HorizontalPageBreaks.Add("Y30")
            workbook.Worksheets(0).VerticalPageBreaks.Add("Y30")

            ' Save the Excel file.
            workbook.Save(dataDir & Convert.ToString("AddingPageBreaks_out.xls"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace