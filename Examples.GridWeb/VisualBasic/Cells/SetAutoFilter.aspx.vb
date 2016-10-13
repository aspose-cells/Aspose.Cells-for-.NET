
Namespace Cells
    Public Class SetAutoFilter
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' If first visit to the page, init GridWeb
            If Not Page.IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                InitGridWeb()
            End If
        End Sub

        Private Sub InitGridWeb()
            GridWeb1.WorkSheets.Clear()

            ' Gets the web application's path.
            Dim path As String = TryCast(Me.Master, Site).GetDataDir()

            Dim fileName As String = path + "\Cells\Products.xlsx"

            ' Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName)
            GridWeb1.ActiveCell = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex).Cells("A1")

            ' ExStart:SetAutoFilter
            ' Enable GridWeb's auto-filter.
            GridWeb1.WebWorksheets(GridWeb1.ActiveSheetIndex).RowFilter.EnableAutoFilter = True

            ' Set the header row.
            GridWeb1.WebWorksheets(GridWeb1.ActiveSheetIndex).RowFilter.HeaderRow = 0

            ' Set the starting column.
            GridWeb1.WebWorksheets(0).RowFilter.StartColumn = 0

            ' Set the ending column.
            GridWeb1.WebWorksheets(0).RowFilter.EndColumn = 9
            ' ExEnd:SetAutoFilter
        End Sub

    End Class
End Namespace
