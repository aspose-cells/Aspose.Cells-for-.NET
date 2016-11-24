Imports Aspose.Cells.GridWeb.Data

Namespace Articles
    Public Class SetCellPercentageFormat
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                InitGridWeb()
            End If
        End Sub

        Private Sub InitGridWeb()
            ' ExStart:SetCellPercentageFormat
            ' Access cell A1 of first gridweb worksheet
            Dim cellA1 As GridCell = GridWeb1.WorkSheets(0).Cells("A1")

            ' Access cell style and set its number format to 10 which is a Percentage 0.00% format
            Dim st As GridTableItemStyle = cellA1.Style
            st.NumberType = 10
            cellA1.Style = st
            ' ExEnd:SetCellPercentageFormat

            cellA1.PutValue(0.03)
        End Sub
    End Class
End Namespace
