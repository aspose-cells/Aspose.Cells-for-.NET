
Namespace Cells
    Public Class SetCustomFilter
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
        End Sub

        Protected Sub btnApplyCustomFilter_Click(sender As Object, e As EventArgs)
            ' ExStart:SetCustomFilter
            ' Set the starting column.
            GridWeb1.WebWorksheets(GridWeb1.ActiveSheetIndex).RowFilter.StartColumn = 0

            ' Set the ending column.
            GridWeb1.WebWorksheets(GridWeb1.ActiveSheetIndex).RowFilter.EndColumn = 9

            ' Get the RowFilter object for the first worksheet.
            Dim rowFilter As Aspose.Cells.GridWeb.Data.RowFilterSettings = GridWeb1.WebWorksheets(GridWeb1.ActiveSheetIndex).RowFilter

            ' Set the criteria.
            rowFilter.Criteria = "CELL1=""Chai"""

            ' Filter Rows.
            rowFilter.FilterRows()
            ' ExEnd:SetCustomFilter
        End Sub
    End Class
End Namespace
