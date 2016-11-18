Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithCells
	Public Partial Class AddingCellFormulas
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub AddingCellFormulas_Load(sender As Object, e As EventArgs)
			' ExStart:1
			' Accessing first worksheet of the Grid
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)

			' Adding numeric values to "B2" & "B3" cells
			sheet.Cells("B2").SetCellValue(3)
			sheet.Cells("B3").SetCellValue(4)

			' Adding a formula to "B4" cell multiplying the values of "B2" & "B3" cells
			sheet.Cells("B4").SetCellValue("=B2 * B3")

			' Running all formulas in the Grid
			gridDesktop1.RunAllFormulas()
			' ExEnd:1
		End Sub
	End Class
End Namespace
