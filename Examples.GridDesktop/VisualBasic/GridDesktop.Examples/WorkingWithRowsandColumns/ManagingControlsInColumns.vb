Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithRowsandColumns
	Public Partial Class ManagingControlsInColumns
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Adding checkbox to a specific column of the Worksheet
			sheet.Columns(2).AddCheckBox()
			gridDesktop1.Refresh()
		End Sub

		Private Sub button3_Click(sender As Object, e As EventArgs)
			' ExStart:RemoveCheckbox
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Removing cell control from the column
			sheet.Columns(2).RemoveCellControl()
			' ExEnd:RemoveCheckbox
			gridDesktop1.Refresh()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:AccessCheckbox
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Accessing cell control in the column and typecasting it to CheckBox
			Dim cb As Aspose.Cells.GridDesktop.CheckBox = DirectCast(sheet.Columns(2).CellControl, Aspose.Cells.GridDesktop.CheckBox)

			If cb IsNot Nothing Then
				' Modifying the Checked property of CheckBox
				cb.Checked = True
			Else
				MessageBox.Show("Please add control before accessing it.")
			End If
			' ExEnd:AccessCheckbox
		End Sub
	End Class
End Namespace
