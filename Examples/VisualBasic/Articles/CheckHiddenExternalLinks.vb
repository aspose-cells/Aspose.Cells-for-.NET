Imports System
Imports Aspose.Cells
Imports Aspose.Cells.Drawing

Namespace Articles
    Public Class CheckHiddenExternalLinks
        Public Shared Sub Run()
            ' ExStart:CheckHiddenExternalLinks
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Loads the workbook which contains hidden external links
            Dim workbook As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Access the external link collection of the workbook
            Dim links As ExternalLinkCollection = workbook.Worksheets.ExternalLinks

            ' Print all the external links and check there IsVisible property
            For i As Integer = 0 To links.Count - 1
                Console.WriteLine("Data Source: " & links(i).DataSource)
                Console.WriteLine("Is Referred: " & links(i).IsReferred)
                Console.WriteLine("Is Visible: " & links(i).IsVisible)
                Console.WriteLine()
            Next
            ' ExEnd:CheckHiddenExternalLinks
        End Sub
    End Class
End Namespace