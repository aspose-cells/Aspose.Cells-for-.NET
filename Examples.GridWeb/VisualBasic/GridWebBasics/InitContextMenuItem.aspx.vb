Imports Aspose.Cells.GridWeb.Data

Namespace GridWebBasics
    Public Class InitContextMenuItem
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        ' ExStart:HandleContextMenuItemCommand
        ' Event Handler for custom command event of GridWeb
        Protected Sub GridWeb1_CustomCommand(sender As Object, command As String)
            If command.Equals("MyContextMenuItemCommand") Then
                ' Accessing the active sheet
                Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

                ' Putting value to "A1" cell
                sheet.Cells("A1").PutValue("My Custom Context Menu Item is Clicked.")

                ' Set first column width to make the text visible
                sheet.Cells.SetColumnWidth(0, 40)
            End If
        End Sub
        ' ExEnd:HandleContextMenuItemCommand
    End Class
End Namespace
