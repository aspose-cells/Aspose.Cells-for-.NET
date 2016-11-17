Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop
Imports Aspose.Cells.GridDesktop.Data

Namespace WorkingWithRowsandColumns
	Public Partial Class ChangeFontColorRowColumn
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub ChangeFontColorRowColumn_Load(sender As Object, e As EventArgs)
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
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Accessing the first column of the worksheet
			Dim column As GridColumn = sheet.Columns(0)

			' Creating a customized Font object
			Dim font As New Font("Arial", 10, FontStyle.Bold)

			' Setting the font of the column to the customized Font object
			'column.SetFont(font);

			' Setting the font color of the column to Blue
			'column.SetFontColor(Color.Blue);
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Accessing the first row of the worksheet
			Dim row As GridRow = sheet.Rows(0)

			' Creating a customized Font object
			Dim font As New Font("Arial", 10, FontStyle.Underline)

			' Setting the font of the column to the customized Font object
			'row.SetFont(font);

			' Setting the font color of the column to Green
			'row.SetFontColor(Color.Green);
		End Sub
	End Class
End Namespace
