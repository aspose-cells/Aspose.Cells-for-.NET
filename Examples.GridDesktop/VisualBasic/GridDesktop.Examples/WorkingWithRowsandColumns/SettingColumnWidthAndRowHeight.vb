Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithRowsandColumns
	Public Partial Class SettingColumnWidthAndRowHeight
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:SetColumnWidth
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Adding sample value to sheet cell
			Dim cell As GridCell = sheet.Cells("a1")
			cell.SetCellValue("Welcome to Aspose!")

			' Accessing the first column of the worksheet
			Dim column As Aspose.Cells.GridDesktop.Data.GridColumn = sheet.Columns(0)

			' Setting the width of the column
			column.Width = 150
			' ExEnd:SetColumnWidth
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:SetRowHeight
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Adding sample value to sheet cells
			Dim cell As GridCell = sheet.Cells("b2")
			cell.SetCellValue("1")
			cell = sheet.Cells("c2")
			cell.SetCellValue("2")
			cell = sheet.Cells("d2")
			cell.SetCellValue("3")
			cell = sheet.Cells("e2")
			cell.SetCellValue("4")

			' Accessing the first row of the worksheet
			Dim row As Aspose.Cells.GridDesktop.Data.GridRow = sheet.Rows(1)

			' Setting the height of the row
			row.Height = 100
			' ExEnd:SetRowHeight
		End Sub
	End Class
End Namespace
