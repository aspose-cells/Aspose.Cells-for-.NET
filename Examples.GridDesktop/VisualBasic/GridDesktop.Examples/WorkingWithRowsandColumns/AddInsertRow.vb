Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithRowsandColumns
	Public Partial Class AddInsertRow
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:AddRow
			' Accessing first worksheet of the Grid
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)

			' Adding row to the worksheet
			sheet.AddRow()
			' ExEnd:AddRow
			MessageBox.Show("Row added.")
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:InsertRow
			' Accessing first worksheet of the Grid
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)

			' Inserting row to the worksheet to the first position.
			gridDesktop1.Worksheets(0).InsertRow(0)
			' ExEnd:InsertRow
			MessageBox.Show("Row Inserted.")
		End Sub
	End Class
End Namespace
