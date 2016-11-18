Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithCells
	Public Partial Class ChangeFontColorOfCell
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub ChangeFontColorOfCell_Load(sender As Object, e As EventArgs)
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Setting sample values
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
			' ExStart:1
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Accessing a cell using its name
			Dim cell As GridCell = sheet.Cells("A1")

			' Creating a customized Font object
			Dim font As New Font("Arial", 10, FontStyle.Bold)

			' Setting the font of the cell to the customized Font object
			cell.SetFont(font)

			' Setting the font color of the cell to Blue
			cell.SetFontColor(Color.Blue)
			' ExEnd:1
			gridDesktop1.Refresh()
		End Sub
	End Class
End Namespace
