Public Class SpecifySessionStorePath
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack AndAlso Not GridWeb1.IsPostBack Then
            LoadData()

            ' ExStart:SpecifySessionStorePath
            GridWeb1.SessionStorePath = "mytempdir/session"
            ' ExEnd:SpecifySessionStorePath
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
End Class