Imports System.IO
Imports System.Web
Imports Aspose.Cells

Namespace Files.Handling
    Public Class SaveInPdfFormat
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim Respose As HttpResponse = Nothing
            ' Creating a Workbook object
            Dim workbook As New Workbook()
            If Respose IsNot Nothing Then
                ' Save in Pdf format
                workbook.Save(Respose, dataDir + "output.pdf", ContentDisposition.Attachment, New PdfSaveOptions())
                Respose.[End]()
            End If
            ' ExEnd:1
        End Sub

    End Class
End Namespace
