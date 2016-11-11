Imports Aspose.Cells.GridDesktop

Public Class Form1

    Private Sub button1_Click(sender As System.Object, e As System.EventArgs) Handles button1.Click
        ' ExStart:HideContextMenuItem
        ' Get the ContextMenuManager
        Dim cmm As ContextMenuManager = Me.grdDataEntry.ContextMenuManager

        ' Hide the Copy option in the context menu
        cmm.MenuItemAvailable_Copy = False

        ' Hide the InsertRow option in the context menu
        cmm.MenuItemAvailable_InsertRow = False

        ' Hide the Format Cell dialog box
        cmm.MenuItemAvailable_FormatCells = False
        ' ExEnd:HideContextMenuItem
    End Sub

    Private Sub button2_Click(sender As System.Object, e As System.EventArgs) Handles button2.Click
        ' ExStart:AddContextMenuItem
        ' Get the GridDesktop control
        Dim gridDesktop1 As GridDesktop = Me.grdDataEntry

        ' Get the active worksheet
        Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

        ' Set the total columns diaplyed in the grid
        sheet.ColumnsCount = 15

        ' Set the total rows displayed in the grid
        sheet.RowsCount = 15

        ' Define a new menu item and specify its event handler
        Dim mi As New MenuItem("newMenuItem", New System.EventHandler(AddressOf miClicked))

        ' Set the label
        mi.Text = "New Item"

        ' Add the menu item to the GridDesktop's context menu
        gridDesktop1.ContextMenu.MenuItems.Add(mi)
        ' ExEnd:AddContextMenuItem
    End Sub

    ' ExStart:EventHandler
    ' Event Handler for the new menu item
    Private Sub miClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mi As MenuItem = CType(sender, MenuItem)
        MessageBox.Show("miCliked: " & mi.Text)
    End Sub
    ' ExEnd:EventHandler
End Class
