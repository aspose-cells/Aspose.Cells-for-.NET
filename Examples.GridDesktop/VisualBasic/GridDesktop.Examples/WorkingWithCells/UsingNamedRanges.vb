Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace WorkingWithCells
	Public Partial Class UsingNamedRanges
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:1
			' Clear the Worsheets first
			_grid.Clear()

			' The path to the documents directory.
			Dim dataDir As String = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

			' Specifying the path of Excel file using ImportExcelFile method of the control
			_grid.ImportExcelFile(dataDir & "book1.xlsx")

			' Apply a formula to a cell that refers to a named range "Rang1"
			_grid.Worksheets(0).Cells("G6").SetCellValue("=SUM(Range1)")

			' Add a new named range "MyRange" with based area A2:B5
			Dim index As Integer = _grid.Names.Add("MyRange", "Sheet1!A2:B5")

			' Apply a formula to G7 cell
			_grid.Worksheets(0).Cells("G7").SetCellValue("=SUM(MyRange)")

			' Calculate the results of the formulas
			_grid.RunAllFormulas()

			' Save the Excel file
			_grid.ExportExcelFile(dataDir & "ouputBook1_out.xlsx")
			' ExEnd:1
			MessageBox.Show("Sheet has been exported to output directory.")
		End Sub
	End Class
End Namespace
