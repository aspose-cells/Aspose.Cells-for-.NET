Imports Aspose.Cells.GridWeb.Data

Namespace RowsAndColumns
    Public Class MakeRowsColumnsReadOnly
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub btnMakeCellReadOnly_Click(sender As Object, e As EventArgs)
            ' ExStart:MakeCellReadOnly
            ' Accessing the first worksheet that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Set the 1st cell (A1) read only
            sheet.SetIsReadonly(sheet.Cells("A1"), True)
            ' ExEnd:MakeCellReadOnly
        End Sub
    End Class
End Namespace
