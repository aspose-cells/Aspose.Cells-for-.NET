Imports System.IO

Namespace KnowledgeBase.KnownIssues
    Public Class HTTPSSSLIssue
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub btnDownload_Click(sender As Object, e As EventArgs)
            Dim path As String = TryCast(Me.Master, Site).GetDataDir()
            Dim excel As Workbook = New Workbook(path & "\KnowledgeBase\SampleData.xlsx")

            ' ExStart:SSLIssue
            ' Saves file to memory
            Dim stream As MemoryStream = New MemoryStream()
            excel.Save(stream, SaveFormat.Excel97To2003)

            Response.ContentType = "application/vnd.ms-excel"

            ' This is same as OpenInExcel option
            Response.AddHeader("content-disposition", "attachment;  filename=book1.xls")

            ' This is same as OpenInBrowser option
            ' response.AddHeader("content-disposition", "inline;  filename=book1.xls")

            Response.BinaryWrite(stream.ToArray())
            ' ExEnd:SSLIssue
        End Sub
    End Class
End Namespace
