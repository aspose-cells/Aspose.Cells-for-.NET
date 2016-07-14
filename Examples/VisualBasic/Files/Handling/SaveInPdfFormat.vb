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
            ' Save in Pdf format
            workbook.Save(Respose, dataDir & Convert.ToString("output.pdf"), ContentDisposition.Attachment, New PdfSaveOptions())
            Respose.[End]()
            ' ExEnd:1
        End Sub

    End Class
End Namespace
