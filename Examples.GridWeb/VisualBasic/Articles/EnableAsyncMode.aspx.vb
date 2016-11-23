
Namespace Articles
    Public Class EnableAsyncMode
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                LoadData()
            End If
        End Sub

        Private Sub LoadData()
            ' Gets the web application's path.
            Dim path As String = TryCast(Me.Master, Site).GetDataDir()

            ' Clear the sheets
            GridWeb1.WorkSheets.Clear()

            ' Load the file
            GridWeb1.ImportExcelFile(path & Convert.ToString("\Articles\Data.xlsx"))
        End Sub

        Protected Sub btnEnableAsync_Click(sender As Object, e As EventArgs)
            ' ExStart:EnableAsync
            GridWeb1.EnableAsync = True
            ' ExEnd:EnableAsync
        End Sub
    End Class
End Namespace
