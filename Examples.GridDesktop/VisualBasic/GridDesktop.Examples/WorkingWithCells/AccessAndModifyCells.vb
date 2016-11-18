Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithCells
	Public Partial Class AccessAndModifyCells
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:UsingValue
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Accessing the cell using its name
			Dim cell As GridCell = sheet.Cells("A1")

			' Accessing & modifying the value of "A1" cell
			cell.Value = DateTime.Now
			' ExEnd:UsingValue
			gridDesktop1.Refresh()
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:UsingSetCellValue
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Accessing the cell using its name
			Dim cell As GridCell = sheet.Cells("A1")

			' Setting the value of "A1" cell
			cell.SetCellValue(DateTime.Now)
			' ExEnd:UsingSetCellValue
			gridDesktop1.Refresh()
		End Sub
	End Class
End Namespace
