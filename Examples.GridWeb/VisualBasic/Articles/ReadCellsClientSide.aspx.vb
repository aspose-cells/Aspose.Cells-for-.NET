
Namespace Articles
    Public Class ReadCellsClientSide
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            ' Load data on fist visit
            If Not IsPostBack And Not GridWeb1.IsPostBack Then
                InitData()
            End If
        End Sub

        Private Sub InitData()
            ' Gets the web application's path.
            Dim path As String = TryCast(Me.Master, Site).GetDataDir()

            Dim fileName As String = path + "\Articles\Data.xlsx"

            ' Clears datasheets first.
            GridWeb1.WorkSheets.Clear()

            ' Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName)
        End Sub

    End Class
End Namespace
