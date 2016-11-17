Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithRowsandColumns
	Public Partial Class AddInsertColumn
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:AddColumn
			' Accessing first worksheet of the Grid
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)

			' Adding column to the worksheet
			sheet.AddColumn()
			' ExEnd:AddColumn
			MessageBox.Show("Column added.")
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:InsertColumn
			' Accessing first worksheet of the Grid
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)

			' Inserting column to the worksheet to the first position.
			gridDesktop1.Worksheets(0).InsertColumn(0)
			' ExEnd:InsertColumn
			MessageBox.Show("Column Inserted.")
		End Sub
	End Class
End Namespace
