Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithCells
	Public Partial Class FormattingCellRange
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub FormattingCellRange_Load(sender As Object, e As EventArgs)
			' ExStart:1
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Setting sample values
			Dim cell As GridCell = sheet.Cells("b7")
			cell.SetCellValue("1")
			cell = sheet.Cells("c7")
			cell.SetCellValue("2")
			cell = sheet.Cells("d7")
			cell.SetCellValue("3")
			cell = sheet.Cells("e7")
			cell.SetCellValue("4")

			' Creating a CellRange object starting from "B7" to "E7"
			Dim range As New CellRange(6, 1, 6, 4)

			' Accessing and setting Style attributes
			Dim style As New Style(Me.gridDesktop1)
			style.Color = Color.Yellow

			' Applying Style object on the range of cells
			sheet.SetStyle(range, style)

			' Creating a customized Font object
			Dim font As New Font("Courier New", 12F)

			' Setting the font of range of cells to the customized Font object
			sheet.SetFont(range, font)

			' Setting the font color of range of cells to Red
			sheet.SetFontColor(range, Color.Red)
			' ExEnd:1
			gridDesktop1.Refresh()
		End Sub
	End Class
End Namespace
