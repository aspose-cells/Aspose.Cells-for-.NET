Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Data.AddOn.Hyperlinks
    Public Class AddingLinkToURL
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Instantiating a Workbook object
            Dim workbook As New Workbook()

            ' Obtaining the reference of the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Adding a hyperlink to a URL at "A1" cell
            worksheet.Hyperlinks.Add("A1", 1, 1, "http://www.aspose.com")

            ' Saving the Excel file
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1

        End Sub
    End Class
End Namespace