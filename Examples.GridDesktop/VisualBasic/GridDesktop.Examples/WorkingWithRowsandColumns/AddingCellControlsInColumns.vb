Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithRowsandColumns
	Public Partial Class AddingCellControlsInColumns
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:AddingButton
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Adding button to a specific column of the Worksheet
			sheet.Columns(2).AddButton(80, 20, "Hello")
			' ExEnd:AddingButton
			gridDesktop1.Refresh()
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:AddingCheckbox
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Adding checkbox to a specific column of the Worksheet
			sheet.Columns(2).AddCheckBox()
			' ExEnd:AddingCheckbox
			gridDesktop1.Refresh()
		End Sub

		Private Sub button3_Click(sender As Object, e As EventArgs)
			' ExStart:AddingCombobox
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Creating an array of items or values that will be added to combobox
			Dim items As String() = New String(2) {}
			items(0) = "Aspose"
			items(1) = "Aspose.Grid"
			items(2) = "Aspose.Grid.Desktop"

			' Adding combobox (containing items) to a specific column of the Worksheet
			sheet.Columns(2).AddComboBox(items)
			' ExEnd:AddingCombobox
			gridDesktop1.Refresh()
		End Sub
	End Class
End Namespace
