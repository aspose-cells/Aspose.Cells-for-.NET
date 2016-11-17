Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithRowsandColumns
	Public Partial Class FreezeUnfreezeRowsColumns
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub FreezeUnfreezeRowsColumns_Load(sender As Object, e As EventArgs)
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Adding sample values to worksheet cells
			Dim cell As GridCell = sheet.Cells("a1")
			cell.SetCellValue("1")
			cell = sheet.Cells("a2")
			cell.SetCellValue("2")
			cell = sheet.Cells("a3")
			cell.SetCellValue("3")
			cell = sheet.Cells("a4")
			cell.SetCellValue("4")
			cell = sheet.Cells("a5")
			cell.SetCellValue("5")
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:FreezeColumns
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Setting the number of frozen columns to 2
			sheet.FrozenCols = 2
			' ExEnd:FreezeColumns
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:UnFreezeColumns
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Setting the number of frozen columns to 0 for unfreezing columns
			sheet.FrozenCols = 0
			' ExEnd:UnFreezeColumns
		End Sub

		Private Sub button3_Click(sender As Object, e As EventArgs)
			' ExStart:FreezeRows
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Setting the number of frozen rows to 2
			sheet.FrozenRows = 2
			' ExEnd:FreezeRows
		End Sub

		Private Sub button4_Click(sender As Object, e As EventArgs)
			' ExStart:UnFreezeRows
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Setting the number of frozen rows to 0 for unfreezing rows
			sheet.FrozenRows = 0
			' ExEnd:UnFreezeRows
		End Sub
	End Class
End Namespace
