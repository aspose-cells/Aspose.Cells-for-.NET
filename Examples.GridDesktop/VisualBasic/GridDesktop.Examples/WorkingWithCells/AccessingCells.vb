Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithCells
	Public Partial Class AccessingCells
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:AccessByName
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Accessing a cell using its name
			Dim cell As GridCell = sheet.Cells("A1")
			' ExEnd:AccessByName
			MessageBox.Show(cell.Name)
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:AccessByIndices
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Accessing a cell using its row and column indices
			Dim cell As GridCell = sheet.Cells(1, 1)
			' ExEnd:AccessByIndices
			MessageBox.Show(cell.Name)
		End Sub

		Private Sub button3_Click(sender As Object, e As EventArgs)
			' ExStart:AccessFocusedCell
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Accessing a cell that is currently in focus
			Dim cell As GridCell = sheet.GetFocusedCell()
			' ExEnd:AccessFocusedCell
			MessageBox.Show(cell.Name)
		End Sub
	End Class
End Namespace
