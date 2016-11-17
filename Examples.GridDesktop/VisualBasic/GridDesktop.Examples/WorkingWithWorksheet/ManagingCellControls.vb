Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithWorksheet
	Public Partial Class ManagingCellControls
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Accessing the location of the cell that is currently in focus
			Dim cl As CellLocation = sheet.GetFocusedCellLocation()

			' Adding checkbox to the Controls collection of the Worksheet
			sheet.Controls.AddCheckBox(cl.Row, cl.Column, True)
		End Sub

		Private Sub button3_Click(sender As Object, e As EventArgs)
			' ExStart:RemoveCheckbox
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Getting the location of the cell that is currently in focus
			Dim cl As CellLocation = sheet.GetFocusedCellLocation()

			' Removing the cell control by specifying the location of cell containing it
			sheet.Controls.Remove(cl.Row, cl.Column)
			' ExEnd:RemoveCheckbox
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:AccessCheckbox
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Getting the location of the cell that is currently in focus
			Dim cl As CellLocation = sheet.GetFocusedCellLocation()

			' Accessing cell control and typecasting it to CheckBox
			Dim cb As Aspose.Cells.GridDesktop.CheckBox = DirectCast(sheet.Controls(cl.Row, cl.Column), Aspose.Cells.GridDesktop.CheckBox)

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
