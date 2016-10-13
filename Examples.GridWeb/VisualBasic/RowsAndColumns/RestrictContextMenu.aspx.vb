
Namespace RowsAndColumns
    Public Class RestrictContextMenu
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub btnRestrictContextMenu_Click(sender As Object, e As EventArgs)
            ' ExStart:RestrictContextMenu
            ' Restricting column related operations in context menu
            GridWeb1.EnableClientColumnOperations = False

            ' Restricting row related operations in context menu
            GridWeb1.EnableClientRowOperations = False

            ' Restricting freeze option of context menu
            GridWeb1.EnableClientFreeze = False
            ' ExEnd:RestrictContextMenu
        End Sub
    End Class
End Namespace
