Public Class CellDataPercentageFormat
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' ExStart:ShowPercentageFormat
            ' Access cell A1 of first gridweb worksheet
            Dim cellA1 As Data.GridCell = GridWeb1.WorkSheets(0).Cells("A1")

            ' Access cell style and set its number format to 10 which is a Percentage 0.00% format
            Dim st As GridTableItemStyle = cellA1.Style
            st.NumberType = 10
            ' ExEnd:ShowPercentageFormat
            cellA1.Style = st
        End If
    End Sub

End Class