
Namespace Articles
    Public Class ShowFormulaFeature
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
                ' ExStart:ShowFormulaFeature
                ' Gets the web application's path.
                Dim path As String = TryCast(Me.Master, Site).GetDataDir()

                ' Clear the sheets
                GridWeb1.WorkSheets.Clear()

                ' Load the file
                GridWeb1.ImportExcelFile(path & Convert.ToString("\Articles\source.xlsx"))
                ' ExEnd:ShowFormulaFeature
            End If
        End Sub

    End Class
End Namespace
