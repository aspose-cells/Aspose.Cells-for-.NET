Public Class ShowFormulaFeature
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' ExStart:ShowFormulaFeature
            ' Gets the web application's path.
            Dim path As String = TryCast(Me.Master, Site).GetDataDir()

            ' Clear the sheets
            GridWeb1.WebWorksheets.Clear()

            ' Load the file
            ' ExEnd:ShowFormulaFeature
            GridWeb1.WebWorksheets.ImportExcelFile(path & Convert.ToString("\Articles\source.xlsx"))
        End If
    End Sub

End Class