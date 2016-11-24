Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithRowsandColumns
	Public Partial Class ApplyingStyleOnRowColumn
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:AddingColumnStyle
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Accessing the first column of the worksheet
			Dim column As Aspose.Cells.GridDesktop.Data.GridColumn = sheet.Columns(0)

			' Adding sample value to sheet cell
			Dim cell As GridCell = sheet.Cells("a1")
			cell.SetCellValue("Aspose")

			' Getting the Style object for the column
			Dim style As Style = column.GetStyle()

			' Setting Style properties i.e. border, alignment color etc.
			style.SetBorderLine(BorderType.Right, BorderLineType.Thick)
			style.SetBorderColor(BorderType.Right, Color.Blue)
			style.HAlignment = HorizontalAlignmentType.Centred

			' Setting the style of the column with the customized Style object
			column.SetStyle(style)
			' ExEnd:AddingColumnStyle
			gridDesktop1.Refresh()
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:AddingRowStyle
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Accessing the first row of the worksheet
			Dim row As Aspose.Cells.GridDesktop.Data.GridRow = sheet.Rows(0)

			' Getting the Style object for the row
            'Dim style As Style = row.GetStyle()

			' Setting Style properties i.e. border, color, alignment, background color etc.
            'style.SetBorderLine(BorderType.Right, BorderLineType.Thick)
            'style.SetBorderColor(BorderType.Right, Color.Blue)
            'style.HAlignment = HorizontalAlignmentType.Centred
            'style.Color = Color.Yellow

			' Setting the style of the row with the customized Style object
            'row.SetStyle(style)
			' ExEnd:AddingRowStyle
		End Sub
	End Class
End Namespace
