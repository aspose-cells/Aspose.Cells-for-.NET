Imports System.Web.Mvc
Imports System.Web.Routing
Imports System.Threading

Public Class GridWebFAQController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /FAQ

    Function Index() As ActionResult
        Return View()
    End Function

    Private postedFile As HttpPostedFileBase

    ' ExStart:FixStackOverflowException
    <HttpPost>
    Public Function Index(file As HttpPostedFileBase, mode As String) As ActionResult
        Me.postedFile = file
        Dim newThread As New Thread(AddressOf Calculate, 1048576)
        newThread.Start()
        newThread.Join()
        Return View()
    End Function

    Private Sub Calculate()
        If postedFile IsNot Nothing AndAlso postedFile.ContentLength > 0 Then
            Dim wbkMain = New Workbook(postedFile.InputStream)
            wbkMain.CalculateFormula()
        End If
    End Sub
    ' ExEnd:FixStackOverflowException
End Class