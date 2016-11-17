Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithGrid
	Public Partial Class ManagingContextMenu
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
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

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:AddContextMenuItem
			' Get the active worksheet
			Dim sheet As Worksheet = grdDataEntry.GetActiveWorksheet()

			' Set the total columns diaplyed in the grid
			sheet.ColumnsCount = 15

			' Set the total rows displayed in the grid
			sheet.RowsCount = 15

			' Define a new menu item and specify its event handler
			Dim mi As New MenuItem("newMenuItem", New System.EventHandler(AddressOf miClicked))

			' Set the label
			mi.Text = "New Item"

			' Add the menu item to the GridDesktop's context menu
			grdDataEntry.ContextMenu.MenuItems.Add(mi)
			' ExEnd:AddContextMenuItem
		End Sub

		' ExStart:EventHandler
		' Event Handler for the new menu item
		Private Sub miClicked(sender As Object, e As EventArgs)
			Dim mi As MenuItem = DirectCast(sender, MenuItem)
			MessageBox.Show("miCliked: " & mi.Text)
		End Sub
		' ExEnd:EventHandler
	End Class
End Namespace
