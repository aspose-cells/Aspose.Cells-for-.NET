Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithCells
	Public Partial Class MergingAndUnMergingCells
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:MergeCells
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Creating a CellRange object starting from "B4" to "C6"
			Dim range As New CellRange("B4", "C6")

			' Merging a range of cells
			sheet.Merge(range)
			' ExEnd:MergeCells
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:UnMergeCells
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Accessing the merged cell that is currently in focus
			Dim cell As GridCell = sheet.GetFocusedCell()

			' Unmerging a cell using its location
			sheet.Unmerge(cell.Location)
			' ExEnd:UnMergeCells
		End Sub
	End Class
End Namespace
