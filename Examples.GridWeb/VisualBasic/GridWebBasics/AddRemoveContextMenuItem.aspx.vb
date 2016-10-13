Imports Aspose.Cells.GridWeb.Data

Namespace GridWebBasics
    Public Class AddRemoveContextMenuItem
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub btnAddContextMenuItem_Click(sender As Object, e As EventArgs)
            ' ExStart:AddContextMenuItem
            ' Init context menu item command button
            Dim cmd As New CustomCommandButton()
            cmd.CommandType = CustomCommandButtonType.ContextMenuItem
            cmd.Text = "MyNewContextMenuItem"
            cmd.Command = "MyNewContextMenuItemCommand"

            ' Add context menu item command button to GridWeb
            GridWeb1.CustomCommandButtons.Add(cmd)
            ' ExEnd:AddContextMenuItem
        End Sub

        Protected Sub btnRemoveContextMenuItem_Click(sender As Object, e As EventArgs)
            ' ExStart:RemoveContextMenuItem
            If GridWeb1.CustomCommandButtons.Count > 1 Then
                ' Remove the 2nd custom command button or context menu item using remove at method
                GridWeb1.CustomCommandButtons.RemoveAt(1)
            End If

            If GridWeb1.CustomCommandButtons.Count >= 1 Then
                ' Access the 1st custom command button or context menu item and remove it
                Dim custbtn As CustomCommandButton = GridWeb1.CustomCommandButtons(0)
                GridWeb1.CustomCommandButtons.Remove(custbtn)
            End If
            ' ExEnd:RemoveContextMenuItem
        End Sub

        ' Event Handler for custom command event of GridWeb
        Protected Sub GridWeb1_CustomCommand(sender As Object, command As String)
            If command.Equals("MyContextMenuItemCommand") Or command.Equals("MyNewContextMenuItemCommand") Then
                ' Accessing the active sheet
                Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

                ' Putting value to "A1" cell
                sheet.Cells("A1").PutValue("My Custom Context Menu Item command " + command + " is Clicked.")

                ' Set first column width to make the text visible
                sheet.Cells.SetColumnWidth(0, 40)
            End If
        End Sub
    End Class
End Namespace
