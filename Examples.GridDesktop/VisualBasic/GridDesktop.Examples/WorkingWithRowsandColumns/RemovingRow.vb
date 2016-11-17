Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithRowsandColumns
	Public Partial Class RemovingRow
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:1
			' Accessing first worksheet of the Grid
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)

			' Removing the first row of the worksheet
			sheet.RemoveRow(0)
			' ExStart:1
			MessageBox.Show("Row has been removed.")
		End Sub
	End Class
End Namespace
