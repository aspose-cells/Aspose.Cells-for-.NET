Public Class Site
    Inherits MasterPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Function GetDataDir() As String
        ' Gets the web application's path.
        Dim path As String = Server.MapPath("~")

        path = path.Replace("VisualBasic", "Data")
        path = path.Substring(0, path.LastIndexOf("\"))

        Return path
    End Function
End Class