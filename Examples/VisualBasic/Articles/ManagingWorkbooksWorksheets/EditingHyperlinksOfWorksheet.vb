Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingWorkbooksWorksheets
    Public Class EditingHyperlinksOfWorksheet
        Public Shared Sub Run()
            ' ExStart:EditingHyperlinksOfWorksheet
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim workbook As New Workbook(dataDir & Convert.ToString("Sample.xlsx"))

            Dim worksheet As Worksheet = workbook.Worksheets(0)

            For i As Integer = 0 To worksheet.Hyperlinks.Count - 1
                Dim hl As Hyperlink = worksheet.Hyperlinks(i)
                hl.Address = "http://www.aspose.com"
            Next

            workbook.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:EditingHyperlinksOfWorksheet
        End Sub
    End Class
End Namespace